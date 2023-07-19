namespace KANOKO.Dto
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class CreateAdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UpdateAdminRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class AdminResponseModel : BaseResponse
    {
        public AdminDto Admin { get; set; }
    }

    public class AdminsResponseModel : BaseResponse
    {
        public IList<AdminDto> Admins { get; set; } 
    }
}
