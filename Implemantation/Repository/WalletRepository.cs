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

        public async Task<Wallet> GetAsync(int id)
        {
            return await _context.Wallets.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Wallet> GetAsync(Expression<Func<Wallet, bool>> expression)
        {
            return await _context.Wallets.Include(x => x.User).FirstOrDefaultAsync(expression);
        }
    }
}
