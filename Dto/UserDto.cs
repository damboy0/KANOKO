using KANOKO.Identity;

namespace KANOKO.Dto
{
   
    public class UserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserResponseModel: BaseResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = new HashSet<RoleDto>();
    }

    public class LoginResponseModel
    {
        public string Token { get; set; }
        public UserResponseModel Data { get; set; } 
    }
}
