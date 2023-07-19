using KANOKO.Interface.IRepository;
using KANOKO.Dto;
using KANOKO.Entity;
using KANOKO.Identity;
using KANOKO.Interface.IService;

namespace KANOKO.Implemantation.Service
{
    public class TransactionService: ITransactionService
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly ITransactionRepository _transactionRepo;
        private readonly IAppUserRepository _appUserRepo;

        public TransactionService(IPaymentRepository paymentRepo, ITransactionRepository transactionRepo, IAppUserRepository appUserRepo)
        {
            _paymentRepo = paymentRepo;
            _transactionRepo = transactionRepo;
            _appUserRepo = appUserRepo;
        }

        public async Task<TransactionResponseModel> CreateTransaction(CreateTransactionDto transaction)
        {
           
            var findCustomer = await _appUserRepo.GetAppUserByEmailAsync(transaction.Email);
            if (findCustomer == null)
            {
                return new TransactionResponseModel
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }
            /*var findDriver = await _appUserRepo.GetAppUserByEmailAsync(transaction.DriverId);
            if (findDriver == null)
            {
                return new TransactionResponseModel
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }*/
            var generateReferencenumber = $"Ref{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";

            var transactionResponse = new Transaction()
            {
                AppUserId = findCustomer.Id,
                Status = TransactionStatus.isIntialized,
                CreatedOn = DateTime.UtcNow,
                ItemTitle = transaction.ItemTitle,
                ReferenceNumber = generateReferencenumber,
                DeliveryAddress = transaction.DeliveryAddress,
                ReceiverPhone = transaction.ReceiverPhone,
                PresentLocation = transaction.PresentLocation,
                ReceiverEmail = transaction.ReceiverEmail,
                ReceiverName = transaction.ReceiverName,
                DriverId = transaction.DriverId, // Review
                //Duration .Addhours  //matrix
                //Durat

            };
            var createTransaction = await _transactionRepo.CreatTransaction(transactionResponse);
            if (createTransaction==null)
            {
                return new TransactionResponseModel()
                {
                    IsSuccess = false,
                    Message = "Transaction Failed"
                };
            }

            var appUserTransaction = new AppUserTransaction()
            {
                AppUserId = findCustomer.Id,
                TransactionId = createTransaction.Id,
                
            };
            
            createTransaction.AppUserTransactions.Add(appUserTransaction);
            var createjoinertable = await _transactionRepo.UpdateTransaction(transactionResponse);
            if (createjoinertable==null)
            {
                return new TransactionResponseModel()
                {
                    IsSuccess = false,
                    Message = "Transaction Failed"
                };
            }
            return new TransactionResponseModel
            {
                IsSuccess = true,
                Message = "Transaction created Successfully",
                Transaction = new TransactionDto()
                {
                    reference_id = createTransaction.ReferenceNumber,
                    TotalPrice = createTransaction.TotalPrice
                }
            };
        }

        public async Task<TransactionResponseModel> GetTransaction(int transactionId)
        {
           var getTransaction = await _transactionRepo.GetTransaction(transactionId);
            if (getTransaction==null)
            {
                return new TransactionResponseModel()
                {
                    IsSuccess = false,
                    Message = "Transaction not found"
                };
            }
            return new TransactionResponseModel()
            {
                IsSuccess = true,
                Message = "Transaction found",
                Transaction = new TransactionDto()
                {
                    reference_id = getTransaction.ReferenceNumber,
                    transaction_status = getTransaction.Status,
                    AppUserId = getTransaction.AppUserId,
                    DeliveryAddress = getTransaction.DeliveryAddress,
                    ItemTitle = getTransaction.ItemTitle,
                    DriverId = getTransaction.DriverId,
                    TotalPrice = getTransaction.TotalPrice,
                    CreatedDate = getTransaction.CreatedOn,
                }
            };  
        }

        public async Task<TransactionsResponseModel> GetAllTransaction()
        {
          var getAll = await _transactionRepo.GetAllTransaction();
          return new TransactionsResponseModel()
          {
              TransactionList = getAll.Select(getTransaction => new TransactionDto()
              {
                  reference_id = getTransaction.ReferenceNumber,
                  transaction_status = getTransaction.Status,
                  AppUserId = getTransaction.AppUserId,
                  DeliveryAddress = getTransaction.DeliveryAddress,
                  ItemTitle = getTransaction.ItemTitle,
                  DriverId = getTransaction.DriverId,
                  TotalPrice = getTransaction.TotalPrice,
                  CreatedDate = getTransaction.CreatedOn,
              }).ToList(),
              Message = "Transaction found",
              IsSuccess = true
          };

        }


        public async Task<TransactionResponseModel> GetTransactionByReferenceNumber(string referenceNumber)
        {
            var getTransaction = await _transactionRepo.GetTransactionByReferenceNumber(referenceNumber);
            if (getTransaction == null)
            {
                return new TransactionResponseModel()
                {
                    IsSuccess = false,
                    Message = "Transaction not found"
                };
            }

            return new TransactionResponseModel()
            {
                IsSuccess = true,
                Message = "Transaction found",
                Transaction = new TransactionDto()
                {
                    reference_id = getTransaction.ReferenceNumber,
                    transaction_status = getTransaction.Status,
                    DriverId = getTransaction.DriverId,
                    DeliveryAddress = getTransaction.DeliveryAddress,
                    ItemTitle = getTransaction.ItemTitle,
                    TotalPrice = getTransaction.TotalPrice,
                    AppUserId = getTransaction.AppUserId,
                    CreatedDate = getTransaction.CreatedOn,
                }
            };
        }




    }
}
