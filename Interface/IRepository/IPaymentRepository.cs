using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task<Payment> GetAsync(int id);
        Task<IList<Payment>> GetAllAsync();
        Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression);
        Task<IList<Payment>> GetSelectedAsync(List<int> ids);
        Task<IList<Payment>> GetSelectedAsync(Expression<Func<Payment, bool>> expression);
    }
}
