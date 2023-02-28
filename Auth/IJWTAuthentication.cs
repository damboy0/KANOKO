using KANOKO.Dto;

namespace KANOKO.Auth
{
    public interface IJWTAuthentication
    {
        public string GenerateToken(UserResponseModel model);
    }
}
