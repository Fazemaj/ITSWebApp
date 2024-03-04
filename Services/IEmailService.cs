using ITS_Web.Models;

namespace ITS_Web.Configuration
{
    public interface IEmailService
    {
        public Task SendEmailAsync(JobApply data);
        public Task ContactEmailAsync(Contact data);
    }
}