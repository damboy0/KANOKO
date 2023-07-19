using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IPaymentRepository
    {
        public Task<Payment> CreatePayment(Payment payment);
        public Task<Payment> GetPayment(int paymentId);
        public Task<Payment> UpdatePayment(Payment payment);
        public Task<Payment> GetPaymentByReferenceNumber(string referenceNumber);
        public Task<Payment> GetPaymentByTransactionReferenceNumber(string referenceNumber);
        public Task<IList<Payment>> GetPaymentByPaymentStatus(PaymentStatus paymentStatus);
       // public Task<Payment> GetPaymentByPaymentMethod(string paymentMethod);
        public Task<IList<Payment>> GetAllSuccessfulPaymentByStatus(string transactionId);
        public Task<IList<Payment>> GetAllPendingPaymentByStatus(string transactionId);
    }
}
