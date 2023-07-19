using KANOKO.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Transactions;

namespace KANOKO.Dto
{

    public class UserDto
    {
        public string Email { get; set; }
        /*[EnumDataType(typeof(TransactionStatus))]
        [JsonConverter(typeof(StringEnumConverter))]*/
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }

    public class CreateUserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class UpdateUserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginResponse
    {
        public string Token { get; set; }
        public UserDto Data { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }

    public class UserResponseModel: BaseResponse
    {
        public UserDto Data { get; set; }
    }

    public class UsersResponseModel : BaseResponse
    {
        public IList<UserDto> Data { get; set; } 
    }


}
