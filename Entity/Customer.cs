using KANOKO.Contract;
using KANOKO.Identity;

namespace KANOKO.Entity
{
    public class Customer: AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
