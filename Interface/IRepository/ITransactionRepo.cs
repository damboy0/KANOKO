using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface ITransactionRepo: IBaseRepository<Transaction>
    {
        Task<Transaction> GetAsync(int id);
        Task<IList<Transaction>> GetAllAsync();
        Task<Transaction> GetAsync(Expression<Func<Transaction, bool>> expression);
        Task<IList<Transaction>> GetSelectedAsync(List<int> ids);
        Task<IList<Transaction>> GetSelectedAsync(Expression<Func<Transaction, bool>> expression);
    }
}
