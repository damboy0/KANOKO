using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Repository
{
    public class LocationRepository: BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationContext context) 
        {
            _context= context;
        }

        public async Task<IList<Location>> GetAllAsync()
        {
            return await _context.Locations.Include(x=> x.Address).ToListAsync();
        }

       

        
    }
}
