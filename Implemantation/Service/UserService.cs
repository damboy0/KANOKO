using KANOKO.Dto;
using KANOKO.Implemantation.Repository;
using KANOKO.Interface.IRepository;
using KANOKO.Interface.IService;

namespace KANOKO.Implemantation.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDto> GetUser(int userId)
        {
            var getUser = await _userRepo.GetUser(userId);
            if (getUser == null)
            {
                return null;
            }

            return new UserDto
            {
                Email = getUser.Email,
                Role = getUser.Role,
            };

        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var getUser = await _userRepo.GetUserByEmail(email);
            if  (getUser == null)
            {
                return null;
            }
            return new UserDto
            {
                Email = getUser.Email,
                Role = getUser.Role,
                FirstName = getUser.FirstName,
                Address = getUser.Address,
                LastName = getUser.LastName,
                PhoneNumber = getUser.PhoneNumber,
            };

        }

        public async Task<UserDto> UpdateUser(UpdateUserRequestModel user, int id)
        {
            var getUser = await _userRepo.GetUser(id);
            var updateUser = await _userRepo.UpdateUser(getUser);
            if (updateUser == null)
            {
                return null;
            }

            return new UserDto
            {
                Email = updateUser.Email,
                Role = updateUser.Role,
            };

        }


        public async Task<UserResponseModel> Login(UserLoginRequest _request)
        {
            var getEmail = await _userRepo.GetUserByEmail(_request.Email);
            if (getEmail != null && getEmail.Password == _request.Password)
            {
                return new UserResponseModel
                {
                    Data = new UserDto()
                    {
                        Role = getEmail.Role,
                        Email = getEmail.Email,
                    },

                    IsSuccess = true,
                    Message = "Login Successfully",
                };
            }
            return new UserResponseModel()
            {
                IsSuccess = false,
                Message = "Invalid Email or Password",

            };

        }
    }
}
