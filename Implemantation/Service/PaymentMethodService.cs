using KANOKO.Dto;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using KANOKO.Interface.IService;

namespace KANOKO.Implemantation.Service
{
    public class PaymentMethodService: IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<BaseResponse> CreatePaymentMethod(CreatePaymentMethodRequestModel _request)
        {
            var createPaymentMethod = new PaymentMethod
            {
                Name = _request.PaymentMethodName,
                Description = _request.PaymentMethodDescription,
                CreatedOn = new DateTime(),
                IsDeleted = false,
            };
            var create = await _paymentMethodRepository.CreatePaymentMethod(createPaymentMethod);
            if (create == null)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "Payment Method not created"
                };
            }
            return new BaseResponse
            {
                IsSuccess = true,
                Message = "Payment Method created successfully"
            };
        }

        public async Task<BaseResponse> UpdatePaymentMethod(UpdatePaymentMethodRequestModel _request, int id)
        {
            var getPayment = await _paymentMethodRepository.GetPaymentMethod(id);
            getPayment.Name = _request.PaymentMethodName;
            getPayment.Description = _request.PaymentMethodDescription;
            getPayment.UpdatedDate = new DateTime();
            var update = await _paymentMethodRepository.UpdatePaymentMethod(getPayment);
            if (update == null)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "Payment Method not updated"
                };
            }
            return new BaseResponse
            {
                IsSuccess = true,
                Message = "Payment Method updated successfully"
            };
        }

        public async Task<bool> DeletePaymentMethod(int id)
        {
            var getpayment = await _paymentMethodRepository.GetPaymentMethod(id);
            if (getpayment == null)
            {
                return false;
            }
            getpayment.IsDeleted = true;
            _paymentMethodRepository.UpdatePaymentMethod(getpayment);
            return true;
        }


        public async Task<PaymentMethodResponseModel> GetPaymentMethod(int id)
        {
            var getpayment = await _paymentMethodRepository.GetPaymentMethod(id);
            if (getpayment == null)
            {
                return new PaymentMethodResponseModel()
                {
                    Message = "PaymentMethod Not Found",
                    IsSuccess = false
                };
            }
            return new PaymentMethodResponseModel
            {
                PaymentMethod = new PaymentMethodDto()
                {
                    PaymentMethodName = getpayment.Name,
                    PaymentMethodDescription = getpayment.Description
                }
            };
        }


        public async Task<PaymentMethodResponsesModel> GetAllPaymentMethod()
        {
            var getall = await _paymentMethodRepository.GetAllPaymentMethod();
            return new PaymentMethodResponsesModel()
            {
                Message = "Found",
                IsSuccess = true,
                PaymentMethods = getall.Select(d => new PaymentMethodDto
                {
                    PaymentMethodName = d.Name,
                    PaymentMethodDescription = d.Description
                }).ToList()
            };
        }


        public async Task<PaymentMethodResponseModel> GetPaymentMethodByName(string name)
        {
            var getpayment = await _paymentMethodRepository.GetPaymentMethodByName(name);
            if (getpayment == null)
            {
                return new PaymentMethodResponseModel()
                {
                    Message = "PaymentMethod Not Found",
                    IsSuccess = false
                };
            }
            return new PaymentMethodResponseModel
            {
                PaymentMethod = new PaymentMethodDto()
                {
                    PaymentMethodName = getpayment.Name,
                    PaymentMethodDescription = getpayment.Description
                }
            };
        }
    }
}
