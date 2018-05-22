using SocialHub.ApplicationServices.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SocialHub.ApplicationServices
{
    public class EmailService : IEmailService
    {
        public Task SendEmail(string from, string to, string title, string body)
        {
            return Task.CompletedTask;

            //var smtpClient = new SmtpClient()
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    Credentials = new NetworkCredential("", "")
            //};

            //using (var message = new MailMessage("from@gmail.com", "to@mail.com")
            //{
            //    Subject = "Subject",
            //    Body = "Body"
            //})
            //{
            //    await smtpClient.SendMailAsync(message);
            //};
        }
    }
}
