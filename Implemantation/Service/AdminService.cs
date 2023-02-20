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

        public async Task<BaseResponse<AdminDto>> Create(AdminRequestModel model)
        {
            var admin = await _adminRepository.GetAsync(x => x.User.Email == model.Email);
            if (admin != null)
            {
                return new BaseResponse<AdminDto> 
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
            return new BaseResponse<AdminDto>
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

        public async Task<BaseResponse<AdminDto>> Get(int id)
        {
            var getAdmin = await _adminRepository.GetAsync(id);
            if (getAdmin != null) 
            {
                return new BaseResponse<AdminDto>
                {
                    Message = "Failed",
                    Status = false,
                };
            }
            return new BaseResponse<AdminDto>
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

        public async Task<BaseResponse<IEnumerable<AdminDto>>> GetAll()
        {
            var getAll = await _adminRepository.GetAllAsync();
            if (getAll != null)
            {
                return new BaseResponse<IEnumerable<AdminDto>>
                {
                    Message = "failed",
                    Status = false,
                };
            }
            var getAllAdmin = getAll.ToList().Select(x => new AdminDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Email = x.User.Email,
            });
            return new BaseResponse<IEnumerable<AdminDto>>
            {
                Data = getAllAdmin,
                Message = "Success",
                Status = true,
            };
        }
    }
}
