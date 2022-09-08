using System.IO;
using NotinoHomework.Application.Factories.Interfaces;
using NotinoHomework.Application.Services.Implementation;
using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Application.Factories
{
    public class ConvertorFactory : IConvertorFactory
    {
        public  IConvertorService GetService(string contentType)
        {
            switch (contentType)
            {
                case "application/json":
                    return new JsonConvertorService();
                case "application/xml":
                    return new XmlConvertorService();

                default: throw new InvalidDataException();
            }
        }
    }
}
