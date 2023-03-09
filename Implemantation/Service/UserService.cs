using KANOKO.Dto;
using KANOKO.Implemantation.Repository;
using KANOKO.Interface.IRepository;
using KANOKO.Interface.IService;

namespace KANOKO.Implemantation.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ICustomerRepository _customerRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IDriverRepository driverRepository, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _driverRepository = driverRepository;
            _customerRepository = customerRepository;

        }

        public async Task<UserResponseModel> Login(UserRequestModel model)
        {
            var user = await _userRepository.GetAsync(a=> a.Email ==model.Email && a.Password == model.Password);
            if (user == null)
            {
                return new UserResponseModel
                {
                    Message = "Incorrect Email or Password",
                    Status = false,
                };
            }


            if (user.IsDeleted)
            {
                return new UserResponseModel
                {
                    Message = "Your account has been deactivated so you can't log-in.",
                    Status = false
                };
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return new UserResponseModel
                {
                    Message = "Invalid email or password",
                    Status = false
                };
            }

            var userRoles = await _roleRepository.GetUserRolesByUserid(user.Id);
            foreach (var item in userRoles)
            {
                var role = await _roleRepository.GetAsync(item.RoleId);
                if (role.Name == "Driver")
                {
                    var driver = await _driverRepository.GetAsync(x=> x.User.Email == model.Email);
                    if (!driver.IsApproved)
                    {
                        return new UserResponseModel
                        {
                            Id = user.Id,
                            Message = "You have not been approved, so you can't log-in yet.",
                            Status = false
                        };
                    }
                }
                else if (role.Name == "Admin")
                {
                    return new UserResponseModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Roles = user.UserRole.Select(x => new RoleDto
                        {
                            Id = x.RoleId,
                            Name = x.Role.Name,
                            //Description = x.Role.Description,
                        }).ToList(),
                        Message = "Successfully logged in as an Admin",
                        Status = true
                    };
                }
                else if (role.Name == "Customer")
                {
                    return new UserResponseModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Roles = user.UserRole.Select(x => new RoleDto
                        {
                            Id = x.RoleId,
                            Name = x.Role.Name,
                            //Description = x.Role.Description
                        }).ToList(),
                        Message = "Successfully logged in as a Customer",
                        Status = true
                    };
                }
            }

            return new UserResponseModel
            {
                Message = "You do not have access to log in as any user type",
                Status = false
            };
        }
    }
}
