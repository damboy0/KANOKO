/*using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KANOKO.Implemantation.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationContext _context;
        public WalletRepository(ApplicationContext context) 
        {
            _context= context;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            _context.Wallets.AddRange(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }
       
        public async Task<IList<Wallet>> GetAllAsync()
        {
            return await _context.Wallets.ToListAsync();
        }


        public async Task<Wallet> GetAsync(int id)
        {
            return await _context.Wallets.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id );
        }

        public async Task<Wallet> GetAsync(Expression<Func<Wallet, bool>> expression)
        {
            return await _context.Wallets.Include(x => x.User).FirstOrDefaultAsync(expression);
        }

        

        public async Task<Wallet> Update(Wallet wallet)
        {
            _context.Entry(wallet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return wallet;
        }

       public async Task<bool> DeleteWallet(Wallet wallet)
{
    _context.Wallets.Remove(wallet);
    int affectedRows = await _context.SaveChangesAsync();
    return affectedRows > 0;
}


    }
}
*/