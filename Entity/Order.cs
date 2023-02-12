using KANOKO.Contract;

namespace KANOKO.Entity
{
    public class Order: AuditableEntity
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string OrderReference { get; set; }
        public string Description { get; set; }
    }
}
