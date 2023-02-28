using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IDriverRepository: IBaseRepository<Driver>
    {
        Task<Driver> GetAsync(int id);
        Task<Driver> GetAsync(string email);
        Task<IList<Driver>> GetAllAsync();
        Task<Driver> GetAsync(Expression<Func<Driver, bool>> expression);
        Task<IList<Driver>> GetSelectedAsync(List<int> ids);
        Task<IList<Driver>> GetSelectedAsync(Expression<Func<Driver, bool>> expression);
        Task<IList<Driver>> GetActivesAsync();
    }
}
