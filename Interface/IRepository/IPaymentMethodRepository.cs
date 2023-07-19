using KANOKO.Entity;

namespace KANOKO.Interface.IRepository
{
    public interface IPaymentMethodRepository
    {
        Task<PaymentMethod> CreatePaymentMethod(PaymentMethod paymentMethod);
        Task<PaymentMethod> UpdatePaymentMethod(PaymentMethod paymentMethod);
        Task<PaymentMethod> DeletePaymentMethod(PaymentMethod paymentMethod);
        Task<PaymentMethod> GetPaymentMethod(int id);
        Task<List<PaymentMethod>> GetAllPaymentMethod();
        Task<PaymentMethod> GetPaymentMethodByName(string name);
    }
}
