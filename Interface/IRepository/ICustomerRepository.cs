using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IRepository
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        Task<Customer> GetAsync(int id);
        Task<Customer> GetAsync(string email);
        Task<IList<Customer>> GetAllAsync();
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression);
        Task<IList<Customer>> GetSelectedAsync(List<int> ids);
        Task<IList<Customer>> GetSelectedAsync(Expression<Func<Customer, bool>> expression);
         Task<IList<Customer>> GetActivesAsync();
    }
}
