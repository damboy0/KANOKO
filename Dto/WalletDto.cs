namespace KANOKO.Dto
{
    public class WalletDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
    }
    
    public class WalletRequestModel
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }

    public class WalletsResponseModel 
    {
        public WalletDto Data { get; set; }
    }
}
