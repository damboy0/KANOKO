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
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public Task<BaseResponse> ActivateAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminResponseModel> Create(AdminRequestModel model)
        {
            var admin = await _adminRepository.GetAsync(x => x.User.Email == model.Email);
            if (admin != null)
            {
                return new AdminResponseModel
                {
                    Message = "Admin Already Exist",
                    Status = false
                };
            }
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
            };
            var role = await _roleRepository.GetAsync(x => x.Name == "Admin");
            var userRole = new UserRole
            {
                User = user,
                UserId = user.Id,
                Role = role,
                RoleId = role.Id,
            };
            user.UserRole.Add(userRole);

            var admins = new Admin
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                User = user,
                UserId = user.Id,
            };
            await _userRepository.Create(user);
            var adminss = await _adminRepository.Create(admins);
            return new AdminResponseModel
            {
                Message = "Admin Created Successful",
                Status = true,
                Data = new AdminDto
                {
                    Id = admins.Id,
                    FirstName = admins.FirstName,
                    LastName = admins.LastName,
                    PhoneNumber = admins.PhoneNumber,
                    Email = admins.User.Email,
                }
            };
        }

        public Task<BaseResponse> DeActivateAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminResponseModel> Get(int id)
        {
            var getAdmin = await _adminRepository.GetAsync(id);
            if (getAdmin != null) 
            {
                return new AdminResponseModel
                {
                    Message = "Failed",
                    Status = false,
                };
            }
            return new AdminResponseModel
            {
                Data = new AdminDto
                {
                    Id = getAdmin.Id,
                    FirstName = getAdmin.FirstName,
                    LastName = getAdmin.LastName,
                    PhoneNumber = getAdmin.PhoneNumber,
                    Email = getAdmin.User.Email,
                }
            };
        }

        public Task<AdminResponseModel> GetAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AdminResponseModel> GetAdminByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AdminsResponseModel> GetAllActiveAdmins()
        {
            throw new NotImplementedException();
        }

        public async Task<AdminsResponseModel> GetAllAdmins()
        {
            var admins = await _adminRepository.GetAllAsync();
            if (admins.Count == 0)
            {
                return new AdminsResponseModel
                {
                    Message = "No admin found",
                    Status = false
                };
            }

            var adminDtos = admins.Select(a => new AdminDto
            {
                Id = a.Id,
                FirstName= a.FirstName,
                LastName= a.LastName,
                PhoneNumber = a.PhoneNumber,
                Email = a.User.Email,
            }).ToList();

            return new AdminsResponseModel
            {
                Message = "admin retrieved successfully",
                Status = true,
                AdminDtos = adminDtos
            };
        }

        public Task<AdminsResponseModel> GetAllDeactivatedAdmins()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> RegisterAdmin(AdminRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateAdmin(UpdateAdminRequestModel model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
