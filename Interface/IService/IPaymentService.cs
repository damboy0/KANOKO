using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IPaymentService
    {
        public Task<PayStackResponse> CreatePaymentAsync(int userId);
    }
}
