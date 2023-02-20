using KANOKO.Contract;
using KANOKO.Entity;
using System.Linq.Expressions;

namespace KANOKO.Identity
{
    public class User: AuditableEntity
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public Admin Admin { get; set; }    
        public Customer Customer { get; set; }
        public Driver Driver { get; set; }
        public List<UserRole> UserRole { get; set; } = new List<UserRole>();
        public List<Wallet> Wallets { get; set; }
    }
}
