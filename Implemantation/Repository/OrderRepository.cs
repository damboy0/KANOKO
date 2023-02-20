using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context)
        {
            _context = context; 
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            return await _context.Order.Include(x => x.OrderReference).ToListAsync();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _context.Order.Include(x => x.OrderReference).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            return await _context.Order.Include(x => x.OrderReference).FirstOrDefaultAsync(expression);
        }
    }
}
