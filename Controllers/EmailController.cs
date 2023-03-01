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
        [HttpGet("Create")]
        public async Task<IActionResult> SendEmail(EmailRequestModel email)
        {
            var send = await _email.SendEmail(email);
            if (send == true) return Ok(send);
            return BadRequest(send);

        }
    }
}
