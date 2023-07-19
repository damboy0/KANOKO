using KANOKO.Entity;

namespace KANOKO.Interface.IRepository
{
    public interface ILocationRepository
    {
        public Task<Location> CreateLocation(Location location);
        public Task<Location> UpdateLocation(Location location);
        public Task<Location> GetLocation(int locationId);


    }
}
