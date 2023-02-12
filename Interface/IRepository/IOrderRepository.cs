using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IOrderRepository: IBaseRepository<Order>
    {
        Task<Order> GetAsync(int id);
        Task<IList<Order>> GetAllAsync();
        Task<Order> GetAsync(Expression<Func<Order, bool>> expression);

    }
}
