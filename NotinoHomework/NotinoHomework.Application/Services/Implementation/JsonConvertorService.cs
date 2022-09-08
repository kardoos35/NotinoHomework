using Newtonsoft.Json;
using NotinoHomework.Application.Models;
using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Application.Services.Implementation
{
    internal class JsonConvertorService : IConvertorService
    {
        public string Serialize(Document document)
        {
            return JsonConvert.SerializeObject(document);
        }

        public Document Deserialize(string content)
        {
            return JsonConvert.DeserializeObject<Document>(content);
        }
    }
}
