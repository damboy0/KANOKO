using KANOKO.Contract;


namespace KANOKO.Entity
{
    public class Order: AuditableEntity
    {
        public Payment? Payment { get; set; }
        public Driver Driver { get; set; }
        public Customer Customer { get; set; }
        public int? DriverId { get; set; }
        public int CustomerId { get; set; }
        public int? PaymentId { get; set; }
        public string? OrderReference { get; set; }
        public string Destination { get; set; }
        public string? PickupLocation { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public decimal Price { get; set; }
        //Checkin if Driver has accepted order
        public bool IsAccepted { get; set; }
        
    }
}
