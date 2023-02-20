using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface ILocationRepository: IBaseRepository<Location>
    {
       
        Task<IList<Location>> GetAllAsync();
      
    } 
}
