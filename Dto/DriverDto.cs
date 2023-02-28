namespace KANOKO.Dto
{
    public class DriverDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class DriverRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
    }

    public class UpadateDriverRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
    }

    public class DriverResponseModel: BaseResponse
    {
        public DriverDto Data { get; set; }
    }

    public class DriversResponseModel : BaseResponse
    {
        public ICollection<DriverDto> Data { get; set; }
    }



}
