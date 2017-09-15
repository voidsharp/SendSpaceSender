using System.Xml.Serialization;

namespace arch.SendSpace.Anonymous
{

    [XmlRoot(ElementName = "upload")]
    public class FileUploadInfo
    {
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlAttribute(AttributeName = "progress_url")]
        public string ProgressUrl { get; set; }

        [XmlAttribute(AttributeName = "max_file_size")]
        public string MaxFileSize { get; set; }

        [XmlAttribute(AttributeName = "upload_identifier")]
        public string UploadIdentifier { get; set; }

        [XmlAttribute(AttributeName = "extra_info")]
        public string ExtraInfo { get; set; }
    }




}
