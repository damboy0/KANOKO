using KANOKO.Dto;
using KANOKO.Entity;

namespace KANOKO.Interface.IService
{
    public interface IOrderService
    {
        public Task<OrderResponseModel> Create(OrdersResponseModel model, int userId);
        public Task<OrderResponseModel> GetOrderByReferenceNumber(string referenceNumber);
        public Task<BaseResponse> AcceptOrder(int driverId, int id); //Driver Accepts Order
        public Task<OrdersResponseModel> GetOrderByStatus(OrderStatus status);
        public Task<OrdersResponseModel> GetAllCreatedOrderByDestination(string location);

    }
}
