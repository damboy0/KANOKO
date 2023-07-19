using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IAdminService
    {
        Task<BaseResponse> CreateAdminAsync(CreateAdminRequestModel requestModel);
        Task<BaseResponse> UpdateAdminAsync(UpdateAdminRequestModel requestModel, string email);
        Task<bool> DeleteAdminAsync(string email);
        Task<AdminResponseModel> GetAdminAsync(int id);
        Task<AdminResponseModel> GetAdminByEmailAsync(string email);
        Task<AdminResponseModel> GetAdminByUserIdAsync(int userId);
    }
}
