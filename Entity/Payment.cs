using KANOKO.Contract;


namespace KANOKO.Entity
{
    public class Payment: AuditableEntity
    {
        
        public string Reference { get; set; }
       // public Order Order { get; set; }
        public int OrderId { get; set; }
        public bool IsPayed { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
