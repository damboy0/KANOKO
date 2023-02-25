using KANOKO.Contract;


namespace KANOKO.Entity
{
    public class Transaction: AuditableEntity
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string transactionReference { get; set; }
    }
}
