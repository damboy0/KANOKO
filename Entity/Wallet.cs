using KANOKO.Contract;
using KANOKO.Identity;

namespace KANOKO.Entity
{
    public class Wallet: AuditableEntity
    {
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        
    }
}
