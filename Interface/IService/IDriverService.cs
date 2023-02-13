using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IDriverService
    {
        Task<BaseResponse<DriverDto>> Create(DriverRequestModel driverRequestModel);
        Task<BaseResponse<DriverDto>> Get(int id);
        Task<BaseResponse<IEnumerable<DriverDto>>> GetAll();
    }
}
