using KANOKO.Contract;

namespace KANOKO.Identity
{
    public class UserRole: AuditableEntity
    {
        public User User { get; set; }
        public int UsertId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}
