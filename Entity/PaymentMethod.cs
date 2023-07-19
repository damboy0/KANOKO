using KANOKO.Contract;

namespace KANOKO.Entity
{
    public class PaymentMethod : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
