using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting.Server;
using ITS_Web.Models;
using System.IO;

namespace ITS_Web.Configuration
{
    public class EmailService : IEmailService
    {
        EmailSettings _emailSettings = null;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public bool SendEmailAsync(JobApply data)
        {
            if(data != null)
            {
                SmtpClient MyServer = new SmtpClient("smtp-mail.outlook.com");
                MyServer.UseDefaultCredentials = false;
                MyServer.EnableSsl = true;
                //Server Credentials
                NetworkCredential NC = new NetworkCredential();
                NC.UserName = "testweb202323@hotmail.com";
                NC.Password = "ivKCyN88ViuBP@f";
                //assigned credetial details to server
                MyServer.Credentials = NC;

                //create sender address
                MailAddress from = new MailAddress("testweb202323@hotmail.com", "Website");

                //create receiver address
                MailAddress to = new MailAddress("fazemaj@itechsolutions.al", "Customer");

                MailMessage Mymessage = new MailMessage(from, to);
                Mymessage.Subject = "Job application";
                Mymessage.Body = $"Name: {data.Name} " + Environment.NewLine +
                                $"Email: {data.Email}" + Environment.NewLine +
                                $"Phone: {data.Phone} " + Environment.NewLine +
                                $"Position: {data.Position}";

                Mymessage.IsBodyHtml = false;

                try
                {
                    string fileName = Path.GetFileName(data.CvFile.FileName);

                    Mymessage.Attachments.Add(new Attachment(data.CvFile.OpenReadStream(), fileName));

                    MyServer.Send(Mymessage);
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
            
        }

        public bool ContactEmailAsync(Contact data)
        {
            if(data != null)
            {
                //created object of SmtpClient details and provides server details
                SmtpClient MyServer = new SmtpClient("smtp-mail.outlook.com");
                MyServer.UseDefaultCredentials = false;
                MyServer.EnableSsl = true;
                //Server Credentials
                NetworkCredential NC = new NetworkCredential();
                NC.UserName = "testweb202323@hotmail.com";
                NC.Password = "ivKCyN88ViuBP@f";
                //assigned credetial details to server
                MyServer.Credentials = NC;

                //create sender address
                MailAddress from = new MailAddress("testweb202323@hotmail.com", "Name want to display");

                //create receiver address
                MailAddress to = new MailAddress("testweb202323@hotmail.com", "Name want to display");

                MailMessage Mymessage = new MailMessage(from, to);
                Mymessage.Subject = "Contact from website";
                Mymessage.Body = $"Name: {data.Name} " + Environment.NewLine +
                                $"Email: {data.Email}" + Environment.NewLine +
                                $"Phone: {data.Phone} " + Environment.NewLine +
                                $"Position: {data.Message}";

                Mymessage.IsBodyHtml = false;

                try
                {
                    MyServer.Send(Mymessage);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }
    }
}