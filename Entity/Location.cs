using KANOKO.Contract;

namespace KANOKO.Entity
{
    public class Location: AuditableEntity
    {
        public string Address { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}
