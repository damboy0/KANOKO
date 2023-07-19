using KANOKO.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace KANOKO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController: Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IPaymentService _paymentService;
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentController(ITransactionService transactionService, IPaymentService paymentService, IPaymentMethodService paymentMethodService)
        {
            _transactionService = transactionService;
            _paymentService = paymentService;
            _paymentMethodService = paymentMethodService;
        }

        [HttpPost("MakePayment")]
        public async Task<IActionResult> MakePayment([FromQuery]string transactionReference)
        {
            var paymentMethodId = await _paymentMethodService.GetPaymentMethodByName("paystack");
            var transactionId = await _transactionService.GetTransactionByReferenceNumber(transactionReference);
            var paymentId = await _paymentService.CreatePayment(transactionId.Transaction.reference_id, paymentMethodId.PaymentMethod.PaymentMethodName);
            if (paymentId.status == false)
            {
                return BadRequest(paymentId);
            }
            return Ok(paymentId);
        }


        [HttpGet("VerifyPayment/{transactionReference}")]
        public async Task<IActionResult> VerifyPayment([FromRoute] string transactionReference)
        {
            var paymentId = await _paymentService.VerifyPayment(transactionReference);
            if (paymentId.IsSuccess == false)
            {
                return BadRequest(paymentId);
            }
            return Ok(paymentId);
        }

    }
}
