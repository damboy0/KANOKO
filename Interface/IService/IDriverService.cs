using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IDriverService
    {
        public Task<DriverResponseModel> RegisterDriver(DriverRequestModel model);
        public Task<BaseResponse> UpdateDriver(UpadateDriverRequestModel model, string email);
        public Task<BaseResponse> ActivateDriver(int id);
        public Task<BaseResponse> DeactivateDriver(int id);
        public Task<BaseResponse> GetDriverByLocation(string location);
        public Task<DriversResponseModel> GetAvailableDriver();


    }
}
