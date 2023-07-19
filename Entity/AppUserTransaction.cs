namespace KANOKO.Entity
{
    public class AppUserTransaction
    {
        public int? AppUserTransactionId { get; set; }
        public int AppUserId { get; set; }
        public int? DriverId { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public AppUser AppUser { get; set; }
    }
}
