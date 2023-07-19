using KANOKO.Contract;

namespace KANOKO.Dto
{
    public class WalletDto
    {
        public decimal Balance { get; set; }
    }

    public class WalletRequestModel
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }

    public class WalletsResponseModel : BaseResponse
    {
        public WalletDto Data { get; set; }
    }

    public class UpdateWalletModel
    {
        public int Id { get; set; }
        public decimal Balance  { get; set; }
        public decimal Amount{ get; set; }
    }
}
