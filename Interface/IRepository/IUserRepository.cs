using KANOKO.Identity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser(int userId);
        Task<User> GetUserByEmail(string email);
        Task<bool> EmailExistsAsync(string email);
        Task<User> UpdateUser(User user);
    }
}
