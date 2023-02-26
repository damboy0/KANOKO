using KANOKO.Contract;


namespace KANOKO.Entity
{
    public class Payment: AuditableEntity
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public string OrderReference { get; set; }
        public bool IsPayed { get; set; }
        public PaymentMethod PaymentStatus { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
