using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderCampsMentor.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var SendGridKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            Execute(SendGridKey, email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string apiKey, string subject, string msg, string email)
        {
            var client = new SendGridClient(apiKey);
            var myMsg = new SendGridMessage()
            {
                From = new EmailAddress("codercampsmentor.com", "Example User"),
                Subject = "Sending with SendGrid is Fun",
                PlainTextContent = "and easy to do anywhere, even with C#",
                HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
            };
            myMsg.AddTo(new EmailAddress(email));
            var response = await client.SendEmailAsync(myMsg);

        }
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}