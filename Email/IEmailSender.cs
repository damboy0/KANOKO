using static KANOKO.Email.EmailDto;

namespace KANOKO.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailRequestModel email);
    }
}
