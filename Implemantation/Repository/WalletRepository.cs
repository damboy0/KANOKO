using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class WalletRepository: BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(ApplicationContext context) 
        {
            _context= context;
        }

        public async Task<IList<Wallet>> GetAllAsync()
        {
            return await _context.Wallets.Include(x=> x.Balance).ToListAsync();
        }

        public Task<Wallet> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> GetAsync(Expression<Func<Wallet, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
