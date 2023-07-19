using KANOKO.Contract;
using KANOKO.Identity;

namespace KANOKO.Entity
{
    public class AppUser: AuditableEntity
    {
        public string Email { get; set; }
        public string? Image { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool IsApproved { get; set; }
        public IEnumerable<AppUserTransaction> AppUserTransactions { get; set; } = new List<AppUserTransaction>();
    }
}
