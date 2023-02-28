using KANOKO.Entity;
using KANOKO.Identity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IAdminRepository: IBaseRepository<Admin>
    {
        Task<Admin>GetAsync(int id);

        Task<IList<Admin>> GetAllAsync();
        Task<Admin> GetAsync(Expression<Func<Admin, bool>> expression);
        Task<IList<Admin>> GetSelectedAsync(List<int> ids);
        Task<IList<Admin>> GetSelectedAsync(Expression<Func<Admin, bool>> expression);

    }
}
