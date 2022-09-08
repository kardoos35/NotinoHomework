using System.Net.Mail;

namespace NotinoHomework.Application.Models
{
    public class EmailMessage
    {
        public MailAddress From { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsBodyHtml { get; set; }
    }
}
