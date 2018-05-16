using SocialHub.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SocialHub.ApplicationServices.Interfaces
{
    public static class EmailSenderExtensions
    {        
        public static Task SendEmailNewUserConfirmation(this IEmailService emailService, string to, string confirmationLink)
        {
            return emailService.SendEmail("admin@socialhub.com", to, 
                "Confirm your email", $@"Please confirm your account by click on this link:
                 <a href='{HtmlEncoder.Default.Encode(confirmationLink)}'></a>");
        }
    }
}
