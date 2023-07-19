using KANOKO.Context;
using KANOKO.Dto;
using KANOKO.Email;
using KANOKO.Entity;
using KANOKO.Identity;
using KANOKO.Interface.IRepository;
using KANOKO.Interface.IService;
using System.Linq.Expressions;
using static KANOKO.Email.EmailDto;

namespace KANOKO.Implemantation.Service
{
    public class AppUserService: IAppUserService
    {
        public readonly IAppUserRepository _appUserRepo;
        private readonly IUserRepository _userRepo;
        //private readonly IWalletRepository _walletRepository;
        //private readonly ITransactionRepository _transactionRepo;

        public AppUserService(IAppUserRepository appUserRepo, IUserRepository userRepo )
        {
            _appUserRepo = appUserRepo;
            _userRepo = userRepo;
           // _walletRepository = walletRepository;
           // _transactionRepo = transactionRepo;
        }

        public async Task<BaseResponse> CreateAppUserAsync(CreateAppUserRequestModel requestModel)
        {
            var checkEmail = await _userRepo.EmailExistsAsync(requestModel.Email);
            if (checkEmail)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "Email already exists"
                };
            }

            var user = new User()
            {
                Password = requestModel.Password,
                Email = requestModel.Email,
                Role = Role.AppUser,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Address = requestModel.Address,
                PhoneNumber = requestModel.PhoneNumber,
            };

            

            var response = await _userRepo.CreateUser(user);
            if (response == null)
            {
                return new BaseResponse()
                {
                    Message = "Failed",
                    IsSuccess = false
                };
            }

            var appUser = new AppUser()
            {
                User = user,
                Email = requestModel.Email,
                Role = requestModel.Role,
            };

            var createAppUserResponse = await _appUserRepo.CreateAppUserAsync(appUser);
            if (createAppUserResponse == null)
            {

                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "AppUser Not Created"
                };
            }

            return new BaseResponse()
            {
                IsSuccess = true,
                Message = "AppUser Created Successfully"
            };
        }




        public async Task<BaseResponse> UpdateAppUserAsync(UpdateAppUserRequestModel requestModel, int id)
        {
            var appUser = await _appUserRepo.GetAppUserByEmailAsync(requestModel.Email);
            if (appUser == null)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "AppUser Not Found"
                };
            }
            var user = await _userRepo.GetUser(appUser.UserId);
            if (user == null)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
            }

            user.Email = requestModel.Email;
            user.Password = requestModel.Password;
            await _userRepo.UpdateUser(user);
            user.FirstName = requestModel.FirstName;
            user.LastName = requestModel.LastName;
            user.PhoneNumber = requestModel.PhoneNumber;
            appUser.Email = requestModel.Email;
            var update = await _appUserRepo.UpdateAppUserAsync(appUser);

            if (update == null)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "AppUser Not Updated"
                };
            }
            return new BaseResponse()
            {
                IsSuccess = true,
                Message = "AppUser Updated Successfully"
            };
        }


        public async Task<bool> DeleteAppUserAsync(int id)
        {
            var getAppUser = await _appUserRepo.GetAppUserAsync(id);
            if (getAppUser == null)
            {
                return false;
            }
            var getUser = await _userRepo.GetUser(getAppUser.UserId);
            if (getUser == null)
            {
                return false;
            }
            getAppUser.IsDeleted = true;
            getUser.IsDeleted = true;
            var delete = await _appUserRepo.UpdateAppUserAsync(getAppUser);
            return true;
        }

        public async Task<AppUserResponseModel> GetAppUserAsync(int id)
        {
            var appUser = await _appUserRepo.GetAppUserAsync(id);
            if (appUser == null)
            {
                return new AppUserResponseModel()
                {
                    IsSuccess = false,
                    Message = "AppUSer Not Found"
                };
            }
            return new AppUserResponseModel()
            {
                AppUser = new AppUsersDto()
                {
                    FirstName = appUser.User.FirstName,
                    LastName = appUser.User.LastName,
                    PhoneNumber = appUser.User.PhoneNumber,
                    Email = appUser.Email,
                },
                Message = "Success",
                IsSuccess = true
            };
        }

        public async Task<AppUserResponsesModel> GetAllAppUserAsync()
        {
            var getall = await _appUserRepo.GetAllAppUserAsync(d => d.IsDeleted == false);
            return new AppUserResponsesModel()
            {
                Message = "Found",
                IsSuccess = true,
                AppUsers = getall.Select(y => new AppUsersDto
                {
                    FirstName = y.User.FirstName,
                    LastName = y.User.LastName,
                    PhoneNumber = y.User.PhoneNumber,
                    Email = y.Email,
                }).ToList()
            };
        }

        public async Task<AppUserResponseModel> GetAppUserByEmailAsync(string email)
        {
            var getbyEmail = await _appUserRepo.GetAppUserByEmailAsync(email);
            if (getbyEmail == null)
            {
                return new AppUserResponseModel()
                {
                    IsSuccess = false,
                    Message = "Customer Not Found"
                };
            }
            return new AppUserResponseModel()
            {
                AppUser = new AppUsersDto()
                {
                    FirstName = getbyEmail.User.FirstName,
                    LastName = getbyEmail.User.LastName,
                    PhoneNumber = getbyEmail.User.PhoneNumber,
                    Email = getbyEmail.Email,
                },
                Message = "Success",
                IsSuccess = true
            };
        }

        /*public async Task<AppUserResponsesModel> GetAllAppUserInTransaction(string referenceNumber)
        {
            var getAllAppUsersInTransaction = await _appUserRepo.GetAllAppUserInTransaction(referenceNumber);
            return new AppUserResponsesModel()
            {
                AppUsers = getAllAppUsersInTransaction.Select(y => new AppUsersDto()
                {
                   
                    FirstName = y.AppUser.FirstName,
                    LastName = y.AppUser.LastName,
                    PhoneNumber = y.AppUser.PhoneNumber,
                    Email = y.AppUser.Email,
                }).ToList(),
                Message = "Success",
                IsSuccess = true
            };
        }*/


       

        public Task<AppUserResponseModel> GetAppUserByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
