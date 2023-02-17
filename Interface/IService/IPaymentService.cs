using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IPaymentService
    {
        public Task<PayStackResponse> CreatePaymentAsync(int userId);
        public Task<BaseResponse<CustomerDto>> Get(int id);
    }
}
