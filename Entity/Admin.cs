using KANOKO.Contract;
using KANOKO.Identity;

namespace KANOKO.Entity
{
    public class Admin: AuditableEntity
    {
        public string AdminId { get; set; }
        public string? Image { get; set; } // is it needed?
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
       // public Wallet Wallet { get; set; }
        //public IEnumerable<Dispute> Disputes { get; set; }

    }
}
