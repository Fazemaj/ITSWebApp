using ITS_Web.Models;

namespace ITS_Web.Configuration
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }
}