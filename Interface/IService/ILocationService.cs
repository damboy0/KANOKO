using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface ILocationService
    {
        Task<BaseResponse<LocationDto>> Create(LocationRequestModel locationRequestModel);
        Task<BaseResponse<LocationDto>> Get(int id);
        Task<BaseResponse<IEnumerable<DriverDto>>> GetAll();
    }
}
