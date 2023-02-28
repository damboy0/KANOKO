using KANOKO.Entity;

namespace KANOKO.Dto
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public bool IsPayed { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderId { get; set; }
    }
    public class PaymentRequestModel
    {
        public string OrderReference { get; set; }
        public decimal Amount { get; set; }
    }

    public class PaymentResponseModel
    {
        public PaymentDto Data { get; set; }
    }

    public class PaymentsResponseModel
    {
        public ICollection<PaymentDto> Data { get; set; }
    }
    public class PaymentRequestModel<T>
    {

    }
}
