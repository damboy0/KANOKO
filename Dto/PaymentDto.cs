using KANOKO.Entity;

namespace KANOKO.Dto
{
    public class PaymentDto
    {
        public string PaymentMethodName { get; set; }
        public decimal Amount { get; set; }
        public string ReferenceNumber { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionReferenceNumber { get; set; }
    }

    public class CreatePaymentDto
    {
        public string TransactionReferenceNumber { get; set; }
    }

    public class PaymentResponseDto : BaseResponse
    {
        public PaymentDto Payment { get; set; }
    }

    public class PaymentListResponseDto : BaseResponse
    {
        public IList<PaymentDto> Payments { get; set; } 
    }
}
