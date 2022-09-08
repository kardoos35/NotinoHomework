using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace NotinoHomework.Application.Providers
{
    internal class FileProvider : IFileProvider
    {
        private const string DefaultFolder = "Files";
        private readonly string _startFolder;

        public FileProvider(IConfiguration configuration)
        {
            _startFolder = configuration["FolderKey"];

            if (string.IsNullOrEmpty(_startFolder))
            {
                _startFolder = DefaultFolder;
            }

            Directory.CreateDirectory(_startFolder);
        }

        public string PathCombine(params string[] paths)
        {
            string path1 = _startFolder;

            return paths.Aggregate(path1, Path.Combine);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
