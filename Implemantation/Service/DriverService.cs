using KANOKO.Dto;
using KANOKO.Interface.IRepository;
using Microsoft.AspNetCore.Identity;
using KANOKO.Identity;
using KANOKO.Context;
using KANOKO.Entity;
using static KANOKO.Email.EmailDto;
using KANOKO.Email;

namespace KANOKO.Implemantation.Service
{
    public class DriverService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ApplicationContext _context;
        private readonly IEmailSender _emailSender;

        public DriverService(IUserRepository userRepository, IDriverRepository driverRepository, IRoleRepository roleRepository, ApplicationContext context, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _driverRepository = driverRepository;
            _roleRepository = roleRepository;
            _context = context;
            _emailSender = emailSender;
        }

        public async Task<DriverResponseModel> RegisterDriver(DriverRequestModel model)
        {
            var d = _driverRepository.GetAsync(x => x.User.Email == model.Email);
            if (d != null)
            {
                return new DriverResponseModel
                {
                    Message = "Driver Already Exist",
                    Status = false,
                };
            }
            var user = new User
            {
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            };
            var addUser = await _userRepository.Create(user);
            var role = await _roleRepository.GetAsync(x => x.Name == "Driver");
            if (role == null)
            {
                return new DriverResponseModel
                {
                    Message = "Role Not Found",
                    Status = false,
                };
            }
            var userRoles = new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id,
            };
            _context.Add(userRoles);
            await _userRepository.Update(user);
            var driver = new Driver
            {
                PhoneNumber = model.PhoneNumber,
                UserId = addUser.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            var DriverDto = new DriverDto
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.User.Email,
                PhoneNumber = driver.PhoneNumber,

            };

            var addDriver = await _driverRepository.Create(driver);
            driver.CreatedBy = driver.Id;
            driver.LastModifiedBy = driver.Id;
            driver.IsDeleted = false;
            
            await _driverRepository.Update(driver);

            var emailRequest = new EmailRequestModel
            {
                ReceiverName = $"{driver.FirstName + " " + driver.LastName} ",
                ReceiverEmail = driver.User.Email,
                Message = $"Hello {driver.FirstName}\n Thanks for registering on KANAKO. You would enjoy using our service",
                Subject = "Driver Registration",
            };
            await _emailSender.SendEmail(emailRequest);

            return new DriverResponseModel
            {
                Message = "",
                Status = true,
                Data = DriverDto

            };

        }

    }
}
