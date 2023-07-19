using KANOKO.Contract;
using KANOKO.Entity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.Json.Serialization;


namespace KANOKO.Identity
{
    public class User : AuditableEntity
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public Admin Admin { get; set; }
        //public Wallet Wallet { get; set; }
        public AppUser AppUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
