using KANOKO.Dto;
using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Interface.IService
{
    public interface IAppUserService
    {
        Task<BaseResponse> CreateAppUserAsync(CreateAppUserRequestModel requestModel);
        Task<BaseResponse> UpdateAppUserAsync(UpdateAppUserRequestModel requestModel, int id);
        // Task<BaseResponse> UpdateTransaction(UpdateTransaction updateTransaction);
        Task<bool> DeleteAppUserAsync(int id);
        Task<AppUserResponseModel> GetAppUserAsync(int id);
        Task<AppUserResponsesModel> GetAllAppUserAsync();
        Task<AppUserResponseModel> GetAppUserByEmailAsync(string email);
        //public Task<AppUserResponseModel> GetAllAppUserInTransaction(string referenceNumber);
        Task<AppUserResponseModel> GetAppUserByUserIdAsync(int userId);
    }
}
