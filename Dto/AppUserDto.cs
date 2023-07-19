using KANOKO.Entity;
using KANOKO.Identity;

namespace KANOKO.Dto
{
    public class AppUsersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
       // public int UserId { get; set; }
    }
    public class CreateAppUserRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }
       // public Wallet Wallet { get; set; }

    }
    public class UpdateAppUserRequestModel
    {
        
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class AppUserResponseModel : BaseResponse
    {
        public AppUsersDto AppUser { get; set; }
    }

    public class AppUserResponsesModel : BaseResponse
    {
        public IEnumerable<AppUsersDto> AppUsers { get; set; }
    }
}
 