using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface ILocationRepository: IBaseRepository<Location>
    {
        Task<Location> GetAsync(int id);
        Task<IList<Location>> GetAllAsync();
        Task<Location> GetAsync(Expression<Func<Location, bool>> expression);
        Task<IList<Location>> GetSelectedAsync(List<int> ids);
        Task<IList<Location>> GetSelectedAsync(Expression<Func<Location, bool>> expression);
    }
}
