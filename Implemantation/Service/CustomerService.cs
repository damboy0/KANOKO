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
    public class CustomerService: ICustomerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationContext _context;

        public CustomerService (IUserRepository userRepository, IRoleRepository roleRepository, ICustomerRepository customerRepository, IEmailSender emailSender, ApplicationContext context)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _customerRepository = customerRepository;
            _emailSender = emailSender;
            _context = context;
        }

        public Task<BaseResponse> DeactivateCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseModel> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseModel> GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseModel> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerResponseModel> RegisterCustomer(CustomerRequestModel model)
        {
            var c = await _customerRepository.GetAsync(x => x.User.Email == model.Email);
            if (c!= null)
            {
                return new CustomerResponseModel
                {
                    Message = "Email Already Exist",
                    Status = false,
                };
            }
            var user = new User
            {
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            };
            var addUser = await _userRepository.Create(user);
            var role = await _roleRepository.GetAsync(x=> x.Name == "Customer");
            if (role == null)
            {
                return new CustomerResponseModel
                {
                    Message = "Role Not Found",
                    Status = false
                };
            }
            var userRoles = new UserRole
            {
                UserId = addUser.Id,
                RoleId = role.Id
            };
            _context.Add(userRoles);
            await _userRepository.Update(user);

            var customer = new Customer
            {
                PhoneNumber = model.PhoneNumber,
                UserId = addUser.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            var customerDto = new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName= customer.LastName,
                Email = customer.User.Email,
                PhoneNumber = customer.PhoneNumber,
            };
            var addCustomer = await _customerRepository.Create(customer);
            customer.CreatedBy = customer.Id;
            customer.LastModifiedBy= customer.Id;
            customer.IsDeleted = false;
            await _customerRepository.Update(customer);
            var emailRequest = new EmailRequestModel
            {
                ReceiverName = $"{customer.FirstName + " " + customer.LastName} ",
                ReceiverEmail = customer.User.Email,
                Message = $"Hello {customer.FirstName}\n Thanks for registering on KANAKO. You would enjoy using our service",
                Subject = "Customer Registration",
            };
            await _emailSender.SendEmail(emailRequest);
            return new CustomerResponseModel
            {
                Message = " Customer Successfully Registered ",
                Status = true,
                Data = customerDto,
            };


        }

        public async Task<BaseResponse> UpdateCustomer(UpdateCustomerRequestModel model, int id)
        {
            var customer = await _customerRepository.GetAsync(id);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Message = "User Not Found",
                    Status = false,
                };
            }
            var getUser = await _userRepository.GetAsync(id);
            if(getUser == null)
            {
                return new BaseResponse
                {
                    Message = "",
                    Status = false,
                };
            }
            getUser.Email = model.Email;
            await _userRepository.Update(getUser);
            customer.User.Email = model.Email ?? customer.User.Email;
            customer.FirstName = customer.FirstName ;
            customer.LastName = customer.LastName;
            customer.PhoneNumber = model.PhoneNumber ?? customer.PhoneNumber;
            await _customerRepository.Update (customer);
            return new BaseResponse
            {
                Message = "User updated successfully",
                Status = true,
            };
        }
    }
}
