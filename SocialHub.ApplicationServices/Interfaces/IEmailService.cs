using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialHub.ApplicationServices.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string from, string to, string title, string body);
    }
}
