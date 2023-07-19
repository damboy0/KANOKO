using KANOKO.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KANOKO.Interface.IService
{
    public interface IPaymentMethodService
    {
        Task<BaseResponse> CreatePaymentMethod(CreatePaymentMethodRequestModel _request);
        Task<BaseResponse> UpdatePaymentMethod(UpdatePaymentMethodRequestModel _request, int id);
        Task<bool> DeletePaymentMethod(int id);
        Task<PaymentMethodResponseModel> GetPaymentMethod(int id);
        Task<PaymentMethodResponsesModel> GetAllPaymentMethod();
        Task<PaymentMethodResponseModel> GetPaymentMethodByName(string name);
    }
}
