using KANOKO.Contract;

namespace KANOKO.Interface.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
        {
            Task<T> Create(T entity);
            Task<T> Update(T entity);
            Task<bool> SaveChanges();
        }  
}
