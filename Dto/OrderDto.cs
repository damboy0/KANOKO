using KANOKO.Entity;

namespace KANOKO.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public OrderStatus Status { get; set; }
        public string OrderId { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
        public string? PickupLocation { get; set; }
        public string DriverId { get; set; }
        public string CustomerId { get; set; }

    }
    public class UpdateOrderRequestModel
    {
        public OrderStatus Status { get; set; }
        public int? DriverId { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
    }

    public class OrderResponseModel : BaseResponse
    {
        public OrderDto OrderDto { get; set; }
    }

    public class OrdersResponseModel : BaseResponse
    {
        public ICollection<OrderDto> OrderDto { get; set; }
    }
}
