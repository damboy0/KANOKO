using static KANOKO.Email.EmailDto;

namespace KANOKO.Email
{
    public interface IEmailSender
    {
        public void SendEmail(EmailRequestModel email);
    }
}
