using System.Xml.Serialization;

namespace arch.SendSpace.Anonymous
{

    [XmlRoot(ElementName = "result")]
    public class FileSendResult
    {
        [XmlElement(ElementName = "upload")]
        public FileUploadInfo UploadInfo { get; set; }
        [XmlAttribute(AttributeName = "method")]
        public string Method { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
    }

}
