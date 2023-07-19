using KANOKO.Email;
using Microsoft.AspNetCore.Mvc;
using static KANOKO.Email.EmailDto;

namespace KANOKO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        IEmailSender _email;

        public EmailController(IEmailSender email)
        {
            _email = email;
        }
        [HttpPost("Send")]
        public IActionResult SendEmail(EmailRequestModel email)
        {
            _email.SendEmail(email);
            return Ok();

        }
    }
}
