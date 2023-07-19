using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IAppUserRepository
    {
        Task<AppUser> CreateAppUserAsync(AppUser appUser);
        Task<AppUser> UpdateAppUserAsync(AppUser appUser);
        Task<AppUser> DeleteAppUserAsync(AppUser appUser);
        Task<AppUser> GetAppUserAsync(int id);
        Task<IList<AppUser>> GetAllAppUserAsync(Expression<Func<AppUser, bool>> expression);
        Task<AppUser> GetAppUserByEmailAsync(string email);
        public Task<IList<AppUserTransaction>> GetAllAppUserInTransaction(string referenceNumber);
        Task<AppUser> GetAppUserByUserIdAsync(int userId);
    }
}
