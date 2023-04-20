using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Security.AccessControl;

namespace KemerburgazPetShop.WebUI.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private const string SendGridKey = "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";
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(SendGridKey, subject, htmlMessage, email);
        }

        private Task Execute(string sendGridApiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridApiKey);

            var msg = new SendGridMessage() 
            {
                From = new EmailAddress("info@kemerburgazpet.com","Kemerburgaz PetShop"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
