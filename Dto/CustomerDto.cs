using KANOKO.Entity;

namespace KANOKO.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
    public class CustomerRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class UpdatePassengerRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CustomerResponseModel : BaseResponse
    {
        public CustomerDto Data { get; set; }
    }

    public class CustomersResponseModel 
    {
        public ICollection<Customer> CustomerDtos { get; set; }
    }
}
 