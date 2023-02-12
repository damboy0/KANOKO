namespace KANOKO.Entity
{
    public class Wallet
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int DriverID { get; set; }   
        public Driver? Driver { get; set; }
    }
}
