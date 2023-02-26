using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IUserService
    {
        Task<BaseResponse<UserDto>> Login(LoginRequestModel loginRequest);
        
    }
}
