using System.IO;
using NotinoHomework.Application.Interfaces;

namespace NotinoHomework.Infrastructure.Repositories
{
    internal class FileRepository : IFileRepository
    {
        public void SaveFile(string content, string path)
        {
            File.WriteAllText(path, content);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
