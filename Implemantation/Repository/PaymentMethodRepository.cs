using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KANOKO.Implemantation.Repository
{
    public class PaymentMethodRepository: IPaymentMethodRepository
    {
        private readonly ApplicationContext _context;

        public PaymentMethodRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<PaymentMethod> CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            await _context.PaymentMethods.AddAsync(paymentMethod);
            await _context.SaveChangesAsync();
            return paymentMethod;
        }

        public async Task<PaymentMethod> UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            _context.Update(paymentMethod);
            await _context.SaveChangesAsync();
            return paymentMethod;
        }

        public async Task<PaymentMethod> DeletePaymentMethod(PaymentMethod paymentMethod)
        {
            _context.Remove(paymentMethod);
            await _context.SaveChangesAsync();
            return paymentMethod;
        }

        public async Task<PaymentMethod> GetPaymentMethod(int id)
        {
            return await _context.PaymentMethods.SingleOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);
        }

        public async Task<List<PaymentMethod>> GetAllPaymentMethod()
        {
            return await _context.PaymentMethods.Where(c => c.IsDeleted == false).ToListAsync();
        }

        public async Task<PaymentMethod> GetPaymentMethodByName(string name)
        {
            return await _context.PaymentMethods.Where(c => c.Name == name && c.IsDeleted == false).SingleOrDefaultAsync();
        }

    }
}
