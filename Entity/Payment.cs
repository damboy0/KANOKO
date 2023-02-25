using KANOKO.Contract;


namespace KANOKO.Entity
{
    public class Payment: AuditableEntity
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string OrderReference { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
