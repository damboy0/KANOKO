using KANOKO.Dto;
using KANOKO.Interface.IService;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using Coinbase.Models;

namespace KANOKO.Implemantation.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<LocationResponseModel> CreateLocation(CreateLocationRequestModel _request)
        {
            var locationResponse = new Location()
            {
                From = _request.From,
                To = _request.To,
                Price = _request.Price,
                Status = LocationStatus.Initiated
            };

            var createLocation = await _locationRepository.CreateLocation(locationResponse);

            if (createLocation == null)
            {
                return new LocationResponseModel()
                {
                    IsSuccess = false,
                    Message = "Location Creation Failed"
                };
            }

            return new LocationResponseModel
            {
                IsSuccess = true,
                Message = "Location created Successfully",
            };

        }

        public async Task<LocationResponseModel> GetLocationAsync(int id)
        {
            var location = await _locationRepository.GetLocation(id);
            
            if (location == null)
            {
                return new LocationResponseModel()
                {
                    IsSuccess = false,
                    Message = "Failed to get Location"
                };
            }

            return new LocationResponseModel()
            {
                Location = new LocationDto()
                {
                    From = location.From,
                    To = location.To,
                    Price = location.Price,
                    Status = location.Status,
                },

                IsSuccess = true,
                Message = "Location created Successfully",
            };
        }

        public async Task<LocationResponseModel> UpdateLocation(UpdateLocationRequestModel _request, int id)
        {
            var location = await _locationRepository.GetLocation(id);
            if (location == null)
            {
                return new LocationResponseModel()
                {
                    IsSuccess = false,
                    Message = "Failed to get Location"
                };
            }

            location.Status = _request.Status;
            location.Price = _request.Price;
            location.To = _request.To;
            location.From = _request.From;
            var update = await _locationRepository.UpdateLocation(location);
            if (update == null)
            {
                return new LocationResponseModel()
                {
                    IsSuccess = false,
                    Message = "Location Not Updated"
                };
            }

            return new LocationResponseModel()
            {
                IsSuccess = true,
                Message = "Location Updated Successfully"
            };

        }
    }
}
