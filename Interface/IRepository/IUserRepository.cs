using KANOKO.Identity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User> GetAsync(int id);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<IList<User>> GetSelectedAsync(List<int> ids);
        Task<IList<User>> GetSelectedAsync(Expression<Func<User, bool>> expression);
        Task<IList<User>> GetAllAsync();
    }
}
