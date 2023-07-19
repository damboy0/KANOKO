using KANOKO.Entity;
using KANOKO.Identity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IAdminRepository
    {
        Task<Admin> CreateAdminAsync(Admin admin);
        Task<Admin> UpdateAdminAsync(Admin admin);
        Task<Admin> DeleteAdminAsync(Admin admin);
        Task<Admin> GetAdminAsync(int id);
        Task<Admin> GetAdminByEmailAsync(string email);
        Task<Admin> GetAdminByUserIdAsync(int userId);

    }
}
