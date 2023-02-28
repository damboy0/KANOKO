using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) 
        {
            _context= context;
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _context.Customers.Include(x => x.User).ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await _context.Customers.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            return await _context.Customers.Include(x => x.User).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Customer>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Customers.Include(x => x.User).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Customer>> GetSelectedAsync(Expression<Func<Customer, bool>> expression)
        {
            return await _context.Customers.Include(x => x.User).Where(expression).ToListAsync();
        }

        public async Task<IList<Customer>> GetDeactivatedAsync()
        {
            return await _context.Customers.Include(x=> x.User).Where(y=> y.IsDeleted == false).ToListAsync();
        }

        public async Task<Customer> GetAsync(string email)
        {
           return await _context.Customers.Where(p => p.User.Email.ToLower() == email.ToLower()).SingleOrDefaultAsync();
        }

        public async Task<IList<Customer>> GetActivesAsync()
        {
            return await _context.Customers.Include(p => p.User).Where(x => x.IsDeleted == false).ToListAsync();
        }

        //


    }
}
