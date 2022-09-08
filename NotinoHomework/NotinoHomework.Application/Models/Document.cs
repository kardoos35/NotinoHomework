using System.Xml.Serialization;

namespace NotinoHomework.Application.Models
{
    [XmlRoot(ElementName = "Document")]
    public class Document
    {
        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Text")]
        public string Text { get; set; }
    }
}
