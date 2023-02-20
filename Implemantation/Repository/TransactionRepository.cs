using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepo
    {
        public TransactionRepository(ApplicationContext context)
        {
            _context = context; 
        }
        public async Task<IList<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.Include(x => x.transactionReference).ToListAsync();
        }

        public async Task<Transaction> GetAsync(int id)
        {
            return await _context.Transactions.Include(x => x.userId).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public Task<Transaction> GetAsync(Expression<Func<Transaction, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Transaction>> GetSelectedAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Transaction>> GetSelectedAsync(Expression<Func<Transaction, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
