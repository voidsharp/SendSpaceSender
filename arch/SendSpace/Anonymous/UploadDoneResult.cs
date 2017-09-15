using System.Xml.Serialization;

namespace arch.SendSpace.Anonymous
{
    [XmlRoot(ElementName = "upload_done")]
    public class UploadDoneResult
    {
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "download_url")]
        public string DownloadUrl { get; set; }
        [XmlElement(ElementName = "delete_url")]
        public string DeleteUrl { get; set; }
        [XmlElement(ElementName = "file_id")]
        public string FileId { get; set; }
    }
}
