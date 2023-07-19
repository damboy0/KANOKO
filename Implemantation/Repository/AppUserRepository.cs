using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class AppUserRepository: IAppUserRepository
    {
        private readonly ApplicationContext _context;
        
        public AppUserRepository(ApplicationContext context) 
        {
            _context= context;
        }

        public async Task<AppUser> CreateAppUserAsync(AppUser appUser)
        {
            await _context.AppUser.AddAsync(appUser);
            await _context.SaveChangesAsync();
            return appUser;
        }

        public async Task<AppUser> DeleteAppUserAsync(AppUser appUser)
        {
             _context.AppUser.Remove(appUser);
            await _context.SaveChangesAsync();
            return appUser;
        }

        public async Task<IList<AppUser>> GetAllAppUserAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _context.AppUser.Include(x => x.User).Where(c => c.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<AppUserTransaction>> GetAllAppUserInTransaction(string referenceNumber)
        {
            var getTransaction = await _context.AppUserTransactions.Include(v => v.AppUserTransactionId).Where(c => c.Transaction.ReferenceNumber == referenceNumber).ToListAsync();
            return getTransaction;
        }

        public async Task<AppUser> GetAppUserAsync(int id)
        {
            return await _context.AppUser.Include(c => c.User).FirstOrDefaultAsync(i => i.Id == id && i.IsDeleted == false);
        }

        

        public async Task<AppUser> GetAppUserByEmailAsync(string email)
        {
            var getEmail = await _context.AppUser.Include(x => x.User).FirstOrDefaultAsync(x => x.Email == email && x.IsDeleted == false);
            return getEmail;
        }

        public async Task<AppUser> GetAppUserByUserIdAsync(int userId)
        {
            return await _context.AppUser.FirstOrDefaultAsync(a => a.UserId == userId && a.IsDeleted == false);
        }

        public async Task<AppUser> UpdateAppUserAsync(AppUser appUser)
        {
            _context.AppUser.Update(appUser);
            await _context.SaveChangesAsync();
            return appUser;
        }
    }
}
