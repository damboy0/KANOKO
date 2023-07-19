using KANOKO.Dto;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using KANOKO.Interface.IService;
using KANOKO.Paystack;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
//using static KANOKO.Implemantation.Service.CoinbasePaymentService;

namespace KANOKO.Implemantation.Service
{
    public class PaymentService: IPaymentService
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly ITransactionRepository _transactionRepo;
        private readonly IConfiguration _configuration;
        private readonly IAppUserRepository _appUserRepo;
       // private readonly CoinbasePaymentService _coinbasePaymentService;
        private readonly IPaymentMethodRepository _paymentMethodRepo;

        public PaymentService(IPaymentRepository paymentRepo, ITransactionRepository transactionRepo, IAppUserRepository appUserRepo, IConfiguration configuration/* CoinbasePaymentService coinbasePaymentService*/)
        {
            _paymentRepo = paymentRepo;
            _transactionRepo = transactionRepo;
            _appUserRepo = appUserRepo;
            _configuration = configuration;
           // _coinbasePaymentService = coinbasePaymentService;
        }



        public async Task<PayStackResponse> CreatePayment(string transactionReference, string paymentMethod)
        {
            var generateId = $"PaymentId{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";
            var gettransaction = await _transactionRepo.GetTransactionByReferenceNumber(transactionReference);
            if (gettransaction.Status == TransactionStatus.isIntialized)
            {
                var getpaymentmethod = await _paymentMethodRepo.GetPaymentMethodByName(paymentMethod);
                var makePayment = new Payment
                {
                    TransactionId = gettransaction.Id,
                   PaymentMethodId = getpaymentmethod.Id,
                    PaymentDate = DateTime.UtcNow,
                    Status = PaymentStatus.Pending,
                    ReferenceNumber = generateId,
                    Amount = SetAmount(gettransaction.TotalPrice)
                };

                var result = await _paymentRepo.CreatePayment(makePayment);
                if (result == null)
                {
                    return new PayStackResponse()
                    {

                        status = false,
                        message = "Payment Failed",
                    };
                }
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.BaseAddress = new Uri("https://api.paystack.co/transaction/initialize");
                httpClient.DefaultRequestHeaders.Authorization =
       new AuthenticationHeaderValue("Bearer", _configuration.GetValue<string>("PaystackSettings:ApiKey"));
                var content = new StringContent(JsonConvert.SerializeObject(new
                {
                    amount = makePayment.Amount * 100,
                    email = gettransaction.DriverId,
                    reference = makePayment.ReferenceNumber,
                    metadata = new
                    {
                        transaction_id = makePayment.TransactionId,
                        payment_method = makePayment.PaymentMethodId
                    }
                }), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://api.paystack.co/transaction/initialize", content);
                var responseString = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<PayStackResponse>(responseString);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (responseObject.status)
                    {
                        return new PayStackResponse()
                        {
                            status = true,
                            message = responseObject.data.authorization_url,
                            data = new TransactionInitialize()
                            {
                                authorization_url = responseObject.data.authorization_url,
                                reference = makePayment.ReferenceNumber
                            }
                        };
                    }
                

            }
            else
                {
                    return new PayStackResponse()
                    {
                        status = false,
                        message = responseObject.message
                    };
                }

            }

            {
                return new PayStackResponse()
                {
                    status = false,
                    message = "Cannot make payment, transaction is not agreed"
                };
            }
        }

        public async Task<BaseResponse> VerifyPayment(string transactionReference)
        {
            var getTransactionReference = await _paymentRepo.GetPaymentByTransactionReferenceNumber(transactionReference);
            if (getTransactionReference == null)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "Transaction not found"
                };
            }

            var getHttpClient = new HttpClient();
            getHttpClient.DefaultRequestHeaders.Accept.Clear();
            getHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var baseUri = getHttpClient.BaseAddress = new Uri("https://api.paystack.co/transaction/verify/" + getTransactionReference.ReferenceNumber);
            getHttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _configuration.GetValue<string>("Paystack:ApiKey"));
            var response =
                await getHttpClient.GetAsync(baseUri);
            var responseString = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseObject = JsonConvert.DeserializeObject<PayStackResponse>(responseString);
                if (responseObject.status)
                {
                    var getPayment = await _paymentRepo.GetPaymentByReferenceNumber(getTransactionReference.ReferenceNumber);
                    if (getPayment.Status == PaymentStatus.Pending)
                    {
                        getPayment.Status = PaymentStatus.Success;
                        getPayment.PaymentDate = DateTime.UtcNow;
                        getTransactionReference.Transaction.Status = TransactionStatus.isActive;
                        var updatetransaction = await _transactionRepo.UpdateTransaction(getTransactionReference.Transaction);
                        var result = await _paymentRepo.UpdatePayment(getPayment);
                        if (result == null)
                        {
                            return new BaseResponse
                            {
                                IsSuccess = false,
                                Message = responseObject.message
                            };
                        }
                        return new BaseResponse
                        {
                            IsSuccess = true,
                            Message = responseObject.message
                        };
                    }
                    return new BaseResponse
                    {
                        IsSuccess = false,
                        Message = "Payment already verified"
                    };
                }
            }

            return new BaseResponse
            {
                IsSuccess = false,
                Message = "Verification Failed"
            };

        }

       
        public async Task<PaymentResponseDto> GetPaymentByReferenceNumber(string referenceNumber)
        {
            var get = await _paymentRepo.GetPaymentByReferenceNumber(referenceNumber);
            if (get == null)
            {
                return new PaymentResponseDto
                {
                    IsSuccess = false,
                    Message = "Payment not found"
                };
            }
            return new PaymentResponseDto
            {
                IsSuccess = true,
                Payment = new PaymentDto()
                {
                    Amount = get.Amount,
                    PaymentDate = get.PaymentDate,
                    //PaymentMethodName = get.PaymentMethod.Name,
                    ReferenceNumber = get.ReferenceNumber,
                    TransactionReferenceNumber = get.Transaction.ReferenceNumber,
                    PaymentStatus = get.Status.ToString(),
                }
            };
        }

        public async Task<MakeATransfer> MakeTransfer(decimal amounts, string recipientId)
        {
            var getHttpClient = new HttpClient();
            getHttpClient.DefaultRequestHeaders.Accept.Clear();
            getHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var baseUri = getHttpClient.BaseAddress = new Uri($"https://api.paystack.co/transfer");
            getHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "sk_test_6483775b59a2152f947af8583a987e98eb5c7af2");
            var response = await getHttpClient.PostAsJsonAsync(baseUri, new
            {

                recipient = recipientId,
                amount = amounts * 100,
                currency = "NGN",
                source = "balance"
            });
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<MakeATransfer>(responseString);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (!responseObject.status)
                {
                    return new MakeATransfer()
                    {
                        status = false,
                        message = responseObject.message
                    };
                }
                return new MakeATransfer()
                {
                    status = true,
                    message = responseObject.message,
                    data = responseObject.data
                };
            }
            return new MakeATransfer()
            {
                status = false,
                message = responseObject.message
            };
        }

        public async Task<GenerateRecipient> GenerateRecipients(VerifyBank verifyBank)
        {
            var getHttpClient = new HttpClient();
            getHttpClient.DefaultRequestHeaders.Accept.Clear();
            getHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var baseUri = getHttpClient.BaseAddress = new Uri($"https://api.paystack.co/transferrecipient");
            getHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "sk_test_769b0bb3a453c0dd7b7ce993fd9b6d393cde0047");
            var response = await getHttpClient.PostAsJsonAsync(baseUri, new
            {
                type = "nuban",
                name = verifyBank.data.account_name,
                account_number = verifyBank.data.account_number,
                bank_code = verifyBank.data.bank_code,
                currency = "NGN",
            });
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<GenerateRecipient>(responseString);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                if (!responseObject.status)
                {
                    return new GenerateRecipient()
                    {
                        status = false,
                        message = responseObject.message
                    };
                }
                return new GenerateRecipient()
                {
                    status = true,
                    message = "Recipient Generated",
                    data = responseObject.data
                };
            }
            return new GenerateRecipient()
            {
                status = false,
                message = responseObject.message
            };
        }

        public async Task<PaymentResponseDto> GetPayment(int paymentId)
        {
            var getPayment = await _paymentRepo.GetPayment(paymentId);
            if (getPayment == null)
            {
                return new PaymentResponseDto
                {
                    IsSuccess = false,
                    Message = "Payment not found"
                };
            }
            return new PaymentResponseDto
            {
                IsSuccess = true,
                Payment = new PaymentDto()
                {
                    Amount = getPayment.Amount,
                    PaymentDate = getPayment.PaymentDate,
                   // PaymentMethodName = getPayment.PaymentMethod.Name,
                    ReferenceNumber = getPayment.ReferenceNumber,
                    TransactionReferenceNumber = getPayment.Transaction.ReferenceNumber,
                    PaymentStatus = getPayment.Status.ToString(),
                }
            };
        }

        public async Task<PaymentListResponseDto> GetPaymentByPaymentStatus(PaymentStatus paymentStatus)
        {
            var get = await _paymentRepo.GetPaymentByPaymentStatus(paymentStatus);
            if (get == null)
            {
                return new PaymentListResponseDto
                {
                    IsSuccess = false,
                    Message = "Payment not found"
                };
            }
            return new PaymentListResponseDto
            {
                IsSuccess = true,
                Payments = get.Select(x => new PaymentDto()
                {
                    Amount = x.Amount,
                    PaymentDate = x.PaymentDate,
                   // PaymentMethodName = x.PaymentMethod.Name,
                    ReferenceNumber = x.ReferenceNumber,
                    TransactionReferenceNumber = x.Transaction.ReferenceNumber,
                    PaymentStatus = x.Status.ToString(),
                }).ToList()
            };
        }

        public async Task<PaymentListResponseDto> GetSuccessfulPaymentByPaymentStatus(string transactionReference)
        {
            var get = await _paymentRepo.GetAllSuccessfulPaymentByStatus(transactionReference);
            if (get == null)
            {
                return new PaymentListResponseDto
                {
                    IsSuccess = false,
                    Message = "Payment not found"
                };
            }
            return new PaymentListResponseDto
            {
                IsSuccess = true,
                Payments = get.Select(x => new PaymentDto()
                {
                    Amount = x.Amount,
                    PaymentDate = x.PaymentDate,
                    //PaymentMethodName = x.PaymentMethod.Name,
                    ReferenceNumber = x.ReferenceNumber,
                    TransactionReferenceNumber = x.Transaction.ReferenceNumber,
                    PaymentStatus = x.Status.ToString(),
                }).ToList()
            };
        }

        public async Task<PaymentListResponseDto> GetPendingPaymentByPaymentStatus(string transactionReference)
        {
            var get = await _paymentRepo.GetAllPendingPaymentByStatus(transactionReference);
            if (get == null)
            {
                return new PaymentListResponseDto
                {
                    IsSuccess = false,
                    Message = "Payment not found"
                };
            }
            return new PaymentListResponseDto
            {
                IsSuccess = true,
                Payments = get.Select(x => new PaymentDto()
                {
                    Amount = x.Amount,
                    PaymentDate = x.PaymentDate,
                   // PaymentMethodName = x.PaymentMethod.Name,
                    ReferenceNumber = x.ReferenceNumber,
                    TransactionReferenceNumber = x.Transaction.ReferenceNumber,
                    PaymentStatus = x.Status.ToString(),
                }).ToList()
            };
        }


        public Task<PaymentListResponseDto> GetPaymentByPaymentMethod(string paymentMethod)
        {
            throw new System.NotImplementedException();
        }

        private decimal SetAmount(decimal amount)
        {

            if (amount <= 5000)
            {
                throw new Exception("Amount must be greater than 5000");
            }
            else if (amount < 1000000)
            {
                amount += (amount * 0.005m);
            }
            else if (amount < 1000000)
            {
                amount += (amount * 0.003m);
            }
            else if (amount < 5000000)
            {
                amount += (amount * 0.002m);
            }
            else
            {
                amount += (amount * 0.001m);
            }
            return amount;
        }

        public Task<VerifyBank> VerifyAccountNumber(int subTransaction)
        {
            throw new NotImplementedException();
        }


        /*public async Task<CoinbaseResponse> CreateCoinbasePayment(string transactionReference, decimal amount, string currency)
        {
            var gettransaction = await _transactionRepo.GetTransactionByReferenceNumber(transactionReference);

            if (gettransaction.Status == TransactionStatus.isIntialized)
            {
                var getpaymentmethod = await _paymentMethodRepo.GetPaymentMethodByName("Coinbase");

                if (getpaymentmethod != null)
                {
                    var coinbasePaymentService = new CoinbasePaymentService("YOUR_API_KEY", "YOUR_API_SECRET");

                    try
                    {
                        // Create the payment with Coinbase
                        var paymentId = await coinbasePaymentService.CreatePayment(amount, currency);

                        // Update your application's payment record with the Coinbase payment ID
                        var makePayment = new Payment
                        {
                            TransactionId = gettransaction.Id,
                            PaymentMethodId = getpaymentmethod.Id, // Use the fetched PaymentMethodId
                            PaymentMethod = getpaymentmethod, // Set the PaymentMethod entity
                            PaymentDate = DateTime.UtcNow,
                            Status = PaymentStatus.Pending,
                            ReferenceNumber = paymentId, // Use Coinbase payment ID as the reference number
                            Amount = amount
                        };

                        var result = await _paymentRepo.CreatePayment(makePayment);

                        if (result != null)
                        {
                            return new CoinbaseResponse
                            {
                                Success = true,
                                Message = "Payment created successfully",
                                CoinbasePaymentId = paymentId,
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occurred during payment creation
                        // Log the exception or perform any necessary error handling
                        // ...
                        return new CoinbaseResponse
                        {
                            Success = false,
                            Message = "Payment creation failed: " + ex.Message,
                            CoinbasePaymentId = null,
                            AuthorizationUrl = null
                        };
                    }
                }
            }

            return new CoinbaseResponse
            {
                Success = false,
                Message = "Cannot create payment or invalid transaction",
                CoinbasePaymentId = null,
                AuthorizationUrl = null
            };
        }*/

    }

}
