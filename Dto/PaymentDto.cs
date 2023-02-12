using KANOKO.Entity;
using KANOKO.Enum;

namespace KANOKO.Dto
{
    public class PaymentDto
    {
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public string transactionReference { get; set; }
    }
    public class PaymentRequestModel
    {
        public int UserId { get; set; }
    }
}
