using SocialHub.ApplicationServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace SocialHub.ApplicationServices
{
    public class EmailService : IEmailService
    {
        public Task SendEmail(string from, string to, string title, string body)
        {
            return Task.CompletedTask;
        }
    }
}
