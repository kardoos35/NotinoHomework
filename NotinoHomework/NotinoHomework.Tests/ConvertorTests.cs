using Newtonsoft.Json;
using NotinoHomework.Application.Models;
using NotinoHomework.Application.Services.Implementation;
using Xunit;

namespace NotinoHomework.Tests
{
    public class ConvertorTests
    {
        [Fact]
        public void SerializeDocument_ToJson_ValidData()
        {
            //arrange
            var document = new Document()
            {
                Title = "Title",
                Text = "Text"
            };
            var json = "{\"Title\":\"Title\",\"Text\":\"Text\"}";
            var service = new JsonConvertorService();

            //act
            var result = service.Serialize(document);

            //assert
            Assert.Equal(json, result);
        }

        [Fact]
        public void SerializeDocument_ToXml_ValidData()
        {
            //arrange
            var document = new Document()
            {
                Title = "Title",
                Text = "Text"
            };
            var xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Title>Title</Title><Text>Text</Text></Document>";
            var service = new XmlConvertorService();

            //act
            var result = service.Serialize(document);

            //assert
            Assert.Equal(xml, result);
        }

        [Fact]
        public void DeserializeJson_ToDocument_ValidData()
        {
            //arrange
            var document = new Document()
            {
                Title = "Title",
                Text = "Text"
            };
            var json = "{\"Title\":\"Title\",\"Text\":\"Text\"}";
            var service = new JsonConvertorService();

            //act
            var result = service.Deserialize(json);
            var doc1 = JsonConvert.SerializeObject(document);
            var doc2 = JsonConvert.SerializeObject(result);

            //assert
            Assert.Equal(doc1, doc2);
        }

        [Fact]
        public void DeserializeXml_ToDocument_ValidData()
        {
            //arrange
            var document = new Document()
            {
                Title = "Title",
                Text = "Text"
            };
            var xml = "<Document><Title>Title</Title><Text>Text</Text></Document>";
            var service = new XmlConvertorService();

            //act
            var result = service.Deserialize(xml);
            var doc1 = JsonConvert.SerializeObject(document);
            var doc2 = JsonConvert.SerializeObject(result);

            //assert
            Assert.Equal(doc1, doc2);
        }
    }
}
