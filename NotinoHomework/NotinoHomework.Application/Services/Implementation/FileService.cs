using System;
using System.IO;
using NotinoHomework.Application.Factories.Interfaces;
using NotinoHomework.Application.Interfaces;
using NotinoHomework.Application.Models;
using NotinoHomework.Application.Providers;
using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Application.Services.Implementation
{
    internal class FileService : IFileService
    {
        private readonly IConvertorFactory _convertorFactory;
        private readonly IFileProvider _fileProvider;
        private readonly IFileRepository _fileRepository;

        public FileService(IConvertorFactory convertorFactory, IFileProvider fileProvider, IFileRepository fileRepository)
        {
            _convertorFactory = convertorFactory;
            _fileProvider = fileProvider;
            _fileRepository = fileRepository;
        }

        public void SaveData(Document document, string contentType)
        {
            var service = _convertorFactory.GetService(contentType);
            var documentName = $"{document.Title}{GetPostfix(contentType)}";
            var path = _fileProvider.PathCombine(documentName);

            if (_fileProvider.FileExists(path))
            {
                throw new Exception();
            }

            var content = service.Serialize(document);

            _fileRepository.SaveFile(content, path);
        }

        public void DeleteDocument(string title)
        {
            var path = _fileProvider.PathCombine(title);

            if (!_fileProvider.FileExists(path))
            {
                _fileRepository.DeleteFile(path);
            }
        }

        public void UpdateDocument(Document document, string contentType)
        {
            var service = _convertorFactory.GetService(contentType);
            var documentName = $"{document.Title}{GetPostfix(contentType)}";
            var path = _fileProvider.PathCombine(documentName);

            if (!_fileProvider.FileExists(path))
            {
                throw new FileNotFoundException();
            }

            var content = service.Serialize(document);

            _fileRepository.SaveFile(content, path);
        }

        public Document GetDocument(string title, string contentType)
        {
            var service = _convertorFactory.GetService(contentType);
            var path = _fileProvider.PathCombine(title);

            if (!_fileProvider.FileExists(path))
            {
                throw new FileNotFoundException();
            }

            var content = _fileRepository.ReadFile(path);

            return service.Deserialize(content);
        }

        private string GetPostfix(string contentType)
        {
            if (contentType.Contains("xml"))
            {
                return ".xml";
            }

            return ".json";
        }
    }
}
