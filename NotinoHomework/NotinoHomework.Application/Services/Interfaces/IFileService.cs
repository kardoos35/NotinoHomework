using NotinoHomework.Application.Models;

namespace NotinoHomework.Application.Services.Interfaces
{
    public interface IFileService
    {
        void SaveData(Document document, string contentType);

        void DeleteDocument(string title);

        void UpdateDocument(Document document, string contentType);

        Document GetDocument(string title, string contentType);
    }
}
