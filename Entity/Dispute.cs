using KANOKO.Contract;
using System.Reflection;

namespace KANOKO.Entity
{
    public class Dispute: AuditableEntity
    {
       public Customer Customer { get; set; }
       public Admin Admin { get; set; }    
       public int? AdminId { get; set; }
       public int CustomerId { get; set; }
       public string DisputeMessage { get; set; }
    }
}
