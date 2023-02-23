using KANOKO.Context;
using KANOKO.Identity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Role>> GetAllAsync()
        {
            return await _context.Roles.Include(x => x.UserRoles).ThenInclude(y => y.User).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Role> GetAsync(int id)
        {
            return await _context.Roles.Include(x => x.UserRoles).ThenInclude(y => y.User).FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == id);
        }

        public async Task<Role> GetAsync(Expression<Func<Role, bool>> expression)
        {
            return await _context.Roles.Include(x => x.UserRoles).ThenInclude(y => y.User).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Role>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Roles.Include(x => x.UserRoles).ThenInclude(y => y.User).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Role>> GetSelectedAsync(Expression<Func<Role, bool>> expression)
        {
            return await _context.Roles.Include(x => x.UserRoles).ThenInclude(y => y.User).Where(expression).ToListAsync();
        }
    }
}
