using KANOKO.Dto;
using KANOKO.Entity;
using KANOKO.Identity;
using KANOKO.Interface.IRepository;
using KANOKO.Interface.IService;
using System.Linq.Expressions;

namespace KANOKO.Implemantation.Service
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepo;

        public AdminService(IAdminRepository adminRepository, IUserRepository userRepo)
        {
            _adminRepository = adminRepository;
            _userRepo = userRepo;
        }

        public async Task<BaseResponse> CreateAdminAsync(CreateAdminRequestModel requestModel)
        {
            //check email if exist
            var get = await _userRepo.EmailExistsAsync(requestModel.Email);
            if (get)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = "Email already exists"
                };
            }
            var genertateId = $"AdminId{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";
            var user = new User
            {
                Email = requestModel.Email,
                Password = requestModel.Password,
                Role = Role.Admin,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                PhoneNumber = requestModel.PhoneNumber,
            };
            var createUser = await _userRepo.CreateUser(user);
            var admin = new Admin
            {
                UserId = user.Id,
                User = user,
                CreatedOn = DateTime.Now,
                Role = Role.Admin,
                AdminId = genertateId
            };
            var createAdmin = await _adminRepository.CreateAdminAsync(admin);
            if (createAdmin == null)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "Admin not created"
                };
            }

            return new BaseResponse()
            {
                IsSuccess = true,
                Message = "Admin created"
            };
        }

        public async Task<BaseResponse> UpdateAdminAsync(UpdateAdminRequestModel requestModel, string email)
        {
            var admin = await _adminRepository.GetAdminByEmailAsync(email);
            if (admin == null)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "Admin not found"
                };
            }
            var getuser = await _userRepo.GetUser(admin.UserId);
            if (getuser == null)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }
            getuser.Email = requestModel.Email;
            getuser.Password = requestModel.Password;
            var updateUser = await _userRepo.UpdateUser(getuser);
            getuser.FirstName = requestModel.FirstName;
            getuser.LastName = requestModel.LastName;
            getuser.PhoneNumber = requestModel.PhoneNumber;
            getuser.Email = requestModel.Email;
            getuser.Password = requestModel.Password;
            var updateAdmin = await _adminRepository.UpdateAdminAsync(admin);
            if (updateAdmin == null)
            {
                return new BaseResponse()
                {
                    IsSuccess = false,
                    Message = "Admin not updated"
                };
            }
            return new BaseResponse()
            {
                IsSuccess = true,
                Message = "Admin updated"
            };
        }

        public async Task<bool> DeleteAdminAsync(string email)
        {
            var getAdmin = await _adminRepository.GetAdminByEmailAsync(email);
            if (getAdmin == null)
            {
                return false;
            }
            var deleteAdmin = await _adminRepository.DeleteAdminAsync(getAdmin);
            if (deleteAdmin == null)
            {
                return false;
            }
            return true;
        }

        public async Task<AdminResponseModel> GetAdminAsync(int id)
        {
            var admin = await _adminRepository.GetAdminAsync(id);
            if (admin == null)
            {
                return new AdminResponseModel()
                {
                    IsSuccess = false,
                    Message = "Admin not found"
                };
            }

            return new AdminResponseModel()
            {
                Admin = new AdminDto()
                {
                    Id = admin.Id,
                    FirstName = admin.User.FirstName,
                    LastName = admin.User.LastName,
                    PhoneNumber = admin.User.PhoneNumber,
                    Email = admin.User.Email,
                    AdminId = admin.AdminId
                },
                IsSuccess = true,
                Message = "Admin found"
            };
        }

        
        public async Task<AdminResponseModel> GetAdminByEmailAsync(string email)
        {
            var getAdmin = await _adminRepository.GetAdminByEmailAsync(email);
            if (getAdmin == null)
            {
                return new AdminResponseModel()
                {
                    IsSuccess = false,
                    Message = "Admin not found"
                };
            }
            return new AdminResponseModel()
            {
                Admin = new AdminDto()
                {
                    Id = getAdmin.Id,
                    FirstName = getAdmin.User.FirstName,
                    LastName = getAdmin.User.LastName,
                    PhoneNumber = getAdmin.User.PhoneNumber,
                    Email = getAdmin.User.Email,
                    AdminId = getAdmin.AdminId
                },
                IsSuccess = true,
                Message = "Admin found"
            };
        }

        public async Task<AdminResponseModel> GetAdminByUserIdAsync(int userId)
        {
            var getAdmin = await _adminRepository.GetAdminByUserIdAsync(userId);
            if (getAdmin == null)
            {
                return new AdminResponseModel()
                {
                    IsSuccess = false,
                    Message = "Admin not found"
                };
            }
            return new AdminResponseModel()
            {
                Admin = new AdminDto()
                {
                    Id = getAdmin.Id,
                    FirstName = getAdmin.User.FirstName,
                    LastName = getAdmin.User.LastName,
                    PhoneNumber = getAdmin.User.PhoneNumber,
                    Email = getAdmin.User.Email,
                    AdminId = getAdmin.AdminId
                },
                IsSuccess = true,
                Message = "Admin found"
            };
        }

       
    }
}
