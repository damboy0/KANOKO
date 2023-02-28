using KANOKO.Identity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetAsync(int id);
        Task<Role> GetAsync(Expression<Func<Role, bool>> expression);
        Task<IList<Role>> GetSelectedAsync(List<int> ids);
        Task<IList<Role>> GetSelectedAsync(Expression<Func<Role, bool>> expression);
        Task<IList<Role>> GetAllAsync();
    }
}
