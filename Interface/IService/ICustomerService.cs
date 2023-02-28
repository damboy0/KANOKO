using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface ICustomerService
    {
        public Task<CustomerResponseModel> RegisterCustomer(CustomerRequestModel model);
        public Task<BaseResponse> UpdateCustomer(UpdateCustomerRequestModel model, int id);
        public Task<CustomerResponseModel> GetAllCustomers();
        public Task<CustomerResponseModel> GetCustomerById(int id);
        public Task<CustomerResponseModel> GetCustomerByEmail(string email);
        public Task<BaseResponse> DeactivateCustomer(int id);

        //public ICollection<CustomerResponseModel> GetAllCustomers();
    }
}
