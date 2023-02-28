using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IUserService
    {
        Task<UserResponseModel> Login(UserRequestModel model);
        
    }
}
