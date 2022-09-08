using NotinoHomework.Application.Models;

namespace NotinoHomework.Application.Services.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage email);
    }
}
