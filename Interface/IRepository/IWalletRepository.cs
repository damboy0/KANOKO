using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IWalletRepository: IBaseRepository<Wallet>
    {
        Task<Wallet> GetAsync(int id);
        Task<IList<Wallet>> GetAllAsync();
        Task<Wallet> GetAsync(Expression<Func<Wallet, bool>> expression);

    }
}
