using NotinoHomework.Application.Models;

namespace NotinoHomework.Application.Services.Interfaces
{
    public interface IConvertorService
    {
        string Serialize(Document document);

        Document Deserialize(string content);
    }
}
