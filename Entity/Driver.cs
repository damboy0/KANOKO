using KANOKO.Contract;
using KANOKO.Identity;

namespace KANOKO.Entity
{
    public class Driver: AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Wallet Wallet { get; set; }
        public bool IsApproved { get; set; }

    }
}
