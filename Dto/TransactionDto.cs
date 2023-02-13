namespace KANOKO.Dto
{
    public interface TransactionDto
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string transactionReference { get; set; }
    }
    public interface TransactionRequestModel
    {
        public int UserId { get; set; }
    }
}
