using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Application.Factories.Interfaces
{
    public interface IConvertorFactory
    {
        public IConvertorService GetService(string contentType);
    }
}
