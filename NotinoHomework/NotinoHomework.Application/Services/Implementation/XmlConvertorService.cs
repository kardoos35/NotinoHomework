using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NotinoHomework.Application.Models;
using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Application.Services.Implementation
{
    internal class XmlConvertorService : IConvertorService
    {
        public string Serialize(Document document)
        {
            var serializer = new XmlSerializer(document.GetType());

            using var sww = new StringWriter();
            using var writer = XmlWriter.Create(sww);

            serializer.Serialize(writer, document);
            return sww.ToString();
        }

        public Document Deserialize(string content)
        {
            var serializer = new XmlSerializer(typeof(Document));
            using var reader = new StringReader(content);

            return (Document)serializer.Deserialize(reader);
        }
    }
}
