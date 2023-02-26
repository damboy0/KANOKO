using KANOKO.Entity;

namespace KANOKO.Dto
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public bool IsPayed { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderReference { get; set; }
    }
    public class PaymentRequestModel
    {
        public string OrderReference { get; set; }
        public decimal Amount { get; set; }
    }
}
