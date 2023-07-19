using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IWalletService
    {
        Task<WalletsResponseModel> Create(WalletRequestModel walletRequestModel);
        Task<WalletsResponseModel> Get(int id);
        Task<BaseResponse> Update(UpdateWalletModel updateWalletModel);  

       // Task<BaseResponse<IEnumerable<DriverDto>>> GetAll(); 
    }
}
