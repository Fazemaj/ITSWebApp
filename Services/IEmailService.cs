using ITS_Web.Models;

namespace ITS_Web.Configuration
{
    public interface IEmailService
    {
        public bool SendEmailAsync(JobApply data);
        public bool ContactEmailAsync(Contact data);
    }
}