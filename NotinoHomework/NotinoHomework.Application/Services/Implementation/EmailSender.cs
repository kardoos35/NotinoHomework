using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using NotinoHomework.Application.Models;
using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Application.Services.Implementation
{
    public class EmailSender : IEmailSender
    {
        private readonly string _smptHost;
        private readonly string _smptPort;
        private readonly string _smptUsername;
        private readonly string _smptPassword;

        public EmailSender(IConfiguration configuration)
        {
            _smptHost = configuration[Constants.SmptHost];
            _smptPort = configuration[Constants.SmptPort];
            _smptUsername = configuration[Constants.SmptUsername];
            _smptPassword = configuration[Constants.SmptPassword];
        }

        public void SendEmail(EmailMessage email)
        {
            var client = GetClient();

            client.Send(new MailMessage
            {
                From = email.From,
                Body = email.Body,
                IsBodyHtml = email.IsBodyHtml,
                Subject = email.Subject
            });
        }

        private SmtpClient GetClient()
        {
            return new SmtpClient(_smptHost)
            {
                Port = int.Parse(_smptPort),
                Credentials = new NetworkCredential(_smptUsername, _smptPassword),
                EnableSsl = true,
            };
        }
    }
}
