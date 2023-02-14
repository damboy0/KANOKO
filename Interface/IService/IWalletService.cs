using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IWalletService
    {
        Task<BaseResponse<WalletDto>> Create(WalletRequestModel walletRequestModel);
        Task<BaseResponse<WalletDto>> Get(int id);
        Task<BaseResponse<IEnumerable<DriverDto>>> GetAll(); 
    }
}
