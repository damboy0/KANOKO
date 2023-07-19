/*using KANOKO.Dto;
using KANOKO.Entity;
using KANOKO.Interface.IRepository;
using KANOKO.Interface.IService;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Service
{
    public class WalletService : IWalletService

    {

        private readonly IAppUserRepository _appUserRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;

        public WalletService(IAppUserRepository appUserRepository, IUserRepository userRepository, IWalletRepository walletRepository)
        {
            _appUserRepository = appUserRepository;
            _userRepository = userRepository;
            _walletRepository = walletRepository;
        }


        public async Task<WalletsResponseModel> Create(WalletRequestModel walletRequestModel)
        {
            var findUser = _userRepository.GetUser(walletRequestModel.UserId);
            if (findUser == null)
            {
                return new WalletsResponseModel
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
            }

            

            var createWallet = await _walletRepository.CreateWallet(wallet);
            if (createWallet == null)
            {
                return new WalletsResponseModel
                {
                    IsSuccess = false,
                    Message = "Wallet Not Created"
                };
            }
            return new WalletsResponseModel
            {
                Message = "Wallet Created Created Successfully",
                IsSuccess = true
            };
        }

        public async Task<WalletsResponseModel> Get(int id)
        {
            var getWalletTask = _walletRepository.GetAsync(id);
            var getWallet = await getWalletTask;

            if (getWallet == null)
            {
                return new WalletsResponseModel 
                { 
                    IsSuccess = false, 
                    Message = "Wallet Not Found" 
                };
            }

            return new WalletsResponseModel
            {
                IsSuccess = true,
                Message = "Wallet Found Successfully",  
                Data = new WalletDto
                {
                    Balance = (decimal)getWallet.Balance,
                }
            };
        }

        public async Task<BaseResponse> Update(UpdateWalletModel updateWalletModel)
        {
            var getWallet = await _walletRepository.GetAsync(updateWalletModel.Id);
            if (getWallet == null)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "Wallet not found"
                };
            }

            getWallet.Balance = updateWalletModel.Balance;

            var updatedWallet = await _walletRepository.Update(getWallet);
            if (updatedWallet == null)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "Failed to update wallet"
                };
            }

            return new BaseResponse()
            {
                IsSuccess = true,
                Message = "Wallet updated successfully"
            };
        }

    }
}


*/