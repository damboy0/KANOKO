using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KANOKO.Implemantation.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationContext _context;
        
        public LocationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Location> CreateLocation(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> GetLocation(int locationId)
        {
            return await _context.Locations.Include(c => c.From).Include(d => d.To).FirstOrDefaultAsync(i => i.Id == locationId && i.IsDeleted == false);
        }

        public async Task<Location> UpdateLocation(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
            return location;
        }
    }
}
