using KANOKO.Context;
using KANOKO.Contract;
using KANOKO.Interface.IRepository;

namespace KANOKO.Implemantation.Repository
{
    public class BaseRepository<T>: IBaseRepository<T> where T : AuditableEntity, new()
    {
        protected ApplicationContext _context;
        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> SaveChanges()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

