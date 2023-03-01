using KANOKO.Context;
using KANOKO.Dto;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class DriverRepository: BaseRepository<Driver>, IDriverRepository
    {
        public DriverRepository (ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Driver>> GetActivesAsync()
        {
            return await _context.Drivers.Include(p => p.User).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Driver>> GetAllAsync()
        {
            return await _context.Drivers.Include(x => x.User).ToListAsync();
        }

        public async Task<Driver> GetAsync(int id)
        {
            return await _context.Drivers.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Driver> GetAsync(Expression<Func<Driver, bool>> expression)
        {
            return await _context.Drivers.Include(x => x.User).FirstOrDefaultAsync(expression);
        }

        public async Task<Driver> GetAsync(string email)
        {
            return await _context.Drivers.Where(p => p.User.Email.ToLower() == email.ToLower()).SingleOrDefaultAsync();
        }

        public async Task<IList<Driver>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Drivers.Include(x => x.User).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Driver>> GetSelectedAsync(Expression<Func<Driver, bool>> expression)
        {
            return await  _context.Drivers.Include(x => x.User).Where(expression).ToListAsync();
        }


    }
}
