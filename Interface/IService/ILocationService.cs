using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface ILocationService
    {
        Task<LocationResponseModel> CreateLocation(CreateLocationRequestModel _request);
        Task<LocationResponseModel> UpdateLocation(UpdateLocationRequestModel _request, int id);
        Task<LocationResponseModel> GetLocationAsync(int id);
    }
}
