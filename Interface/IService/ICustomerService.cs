using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface ICustomerService
    {
        Task<BaseResponse<CustomerDto>> Create(CustomerRequestModel customerRequestModel);
        Task<BaseResponse<CustomerDto>> Get(int id);
        Task<BaseResponse<IEnumerable<CustomerDto>>> GetAll();
    }
}
