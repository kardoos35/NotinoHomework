using System;
using System.IO;
using NotinoHomework.Application.Factories.Interfaces;
using NotinoHomework.Application.Interfaces;
using NotinoHomework.Application.Models;
using NotinoHomework.Application.Providers;
using NotinoHomework.Application.Services.Implementation;
using NotinoHomework.Application.Services.Interfaces;
using NSubstitute;
using Xunit;

namespace NotinoHomework.Tests
{
    public class FileTests
    {
        [Fact]
        public void SaveFile_ToJson_ValidData()
        {
            ////arrange
            var convertorMock = Substitute.For<IConvertorFactory>();
            var fileProviderMock = Substitute.For<IFileProvider>();
            var fileRepositoryMock = Substitute.For<IFileRepository>();
            var jsonConvertorMock = Substitute.For<IConvertorService>();
            var contentType = "application/json";
            var document = new Document()
            {
                Title = "Title",
                Text = "Text"
            };
            var json = "{\"Title\":\"Title\",\"Text\":\"Text\"}";

            convertorMock.GetService(contentType).Returns(new JsonConvertorService());
            fileProviderMock.PathCombine(Arg.Any<string>()).Returns("path");
            fileProviderMock.FileExists(Arg.Any<string>()).Returns(false);
            jsonConvertorMock.Serialize(document).Returns(json);
            var service = new FileService(convertorMock, fileProviderMock, fileRepositoryMock);

            //act
            service.SaveData(document, contentType);

            //assert
            fileRepositoryMock.Received().SaveFile(json, Arg.Any<string>());
        }

        [Fact]
        public void SaveFile_JsonNonValidData_ExceptionExpected()
        {
            ////arrange
            var convertorMock = Substitute.For<IConvertorFactory>();
            var fileProviderMock = Substitute.For<IFileProvider>();
            var fileRepositoryMock = Substitute.For<IFileRepository>();
            var contentType = "application/json";
            var document = new Document()
            {
                Title = "Title",
                Text = "Text"
            };

            convertorMock.GetService(contentType).Returns(new JsonConvertorService());
            fileProviderMock.PathCombine(Arg.Any<string>()).Returns("path");
            fileProviderMock.FileExists(Arg.Any<string>()).Returns(true);
            var service = new FileService(convertorMock, fileProviderMock, fileRepositoryMock);

            //act & assert
            Assert.Throws<Exception>(() => service.SaveData(document, contentType));
        }

        [Fact]
        public void GetDocument_FromJson_ValidData()
        {
            ////arrange
            var convertorMock = Substitute.For<IConvertorFactory>();
            var fileProviderMock = Substitute.For<IFileProvider>();
            var fileRepositoryMock = Substitute.For<IFileRepository>();
            var jsonConvertorMock = Substitute.For<IConvertorService>();
            var contentType = "application/json";
            var document = new Document()
            {
                Title = "Title",
                Text = "Text"
            };
            var json = "{\"Title\":\"Title\",\"Text\":\"Text\"}";

            convertorMock.GetService(contentType).Returns(new JsonConvertorService());
            fileProviderMock.PathCombine(Arg.Any<string>()).Returns("path");
            fileProviderMock.FileExists(Arg.Any<string>()).Returns(true);
            jsonConvertorMock.Deserialize(json).Returns(document);
            var service = new FileService(convertorMock, fileProviderMock, fileRepositoryMock);

            //act
            service.GetDocument(document.Title, contentType);

            //assert
            fileRepositoryMock.Received().ReadFile(Arg.Any<string>());
        }

        [Fact]
        public void GetFile_JsonNonValidData_ExceptionExpected()
        {
            ////arrange
            var convertorMock = Substitute.For<IConvertorFactory>();
            var fileProviderMock = Substitute.For<IFileProvider>();
            var fileRepositoryMock = Substitute.For<IFileRepository>();
            var contentType = "application/json";
            var document = new Document()
            {
                Title = "Title",
                Text = "Text"
            };

            convertorMock.GetService(contentType).Returns(new JsonConvertorService());
            fileProviderMock.PathCombine(Arg.Any<string>()).Returns("path");
            fileProviderMock.FileExists(Arg.Any<string>()).Returns(false);
            var service = new FileService(convertorMock, fileProviderMock, fileRepositoryMock);

            //act & assert
            Assert.Throws<FileNotFoundException>(() => service.GetDocument(document.Title, contentType));
        }
    }
}
