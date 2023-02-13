using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IOrderService
    {
        Task<BaseResponse<OrderDto>> Create(OrderRequestModel model, int userId);
        Task<BaseResponse<OrderDto>> Get(int id);
        Task<BaseResponse<IEnumerable<OrderDto>>> GetAll();
    }
}
