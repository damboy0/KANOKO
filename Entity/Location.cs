using KANOKO.Contract;

namespace KANOKO.Entity
{
    public class Location: AuditableEntity
    {

        public decimal Price { get; set; }
        public string From { get; set; }    
        public string To { get; set; }
        public LocationStatus Status { get; set; }
        
    }
}
