using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int userId);
        Task<UserDto> GetUserByEmail(string email);
        Task<UserDto> UpdateUser(UpdateUserRequestModel user, int id);
        Task<UserResponseModel> Login(UserLoginRequest _request);

    }
}
