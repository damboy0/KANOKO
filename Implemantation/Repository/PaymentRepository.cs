using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class PaymentRepository: BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext context) 
        {
            _context= context;
        }

        public async Task<IList<Payment>> GetAllAsync()
        {
            return await _context.Payments.Include(x => x.Id).ToListAsync();
        }

        public async Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression)
        {
            return await _context.Payments.Include(x => x.Id).FirstOrDefaultAsync(expression);
        }

        public async Task<Payment> GetAsync(int id)
        {
            return await _context.Payments.Include(x => x.Id).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<IList<Payment>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Payments.Include(x => x.Id).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Payment>> GetSelectedAsync(Expression<Func<Payment, bool>> expression)
        {
            return await _context.Payments.Include(x => x.Id).Where(expression).ToListAsync();
        }
    }
}
