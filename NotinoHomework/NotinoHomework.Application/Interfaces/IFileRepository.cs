namespace NotinoHomework.Application.Interfaces
{
    public interface IFileRepository
    {
        void SaveFile(string content, string path);

        void DeleteFile(string path);

        string ReadFile(string path);
    }
}
