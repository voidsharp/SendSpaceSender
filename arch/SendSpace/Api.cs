using arch.SendSpace.Anonymous;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using xNet;

namespace arch.SendSpace
{
    public class Api
    {

        private const string SendSpaceAnonymousSendFileInitialAddress =
            "http://api.sendspace.com/rest/";

        private readonly string sendSpaceApiKey;



        public Api(string apiKey)
        {
            sendSpaceApiKey = apiKey;
        }

        static void ConfigureRequest(HttpRequest reqToConfigure, ProxySettings proxySettingsToSet)
        {
            if (proxySettingsToSet == null) return;
            var proxyClient = Socks5ProxyClient.Parse($"{proxySettingsToSet.ProxyHost}:{proxySettingsToSet.ProxyPort}");
            proxyClient.ReadWriteTimeout = 10000;
            reqToConfigure.Proxy = proxyClient;
        }

        string GetInitAddr()
        {
            return SendSpaceAnonymousSendFileInitialAddress;
        }

        private T DeserializeFromXml<T>(string objectToDeserialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(objectToDeserialize));
            var reader = XmlReader.Create(stream);
            return (T)xmlSerializer.Deserialize(reader);
        }

        public FileSendResult GetFileUploadInfo(ProxySettings stng)
        {
            string content;
            using (var request = new HttpRequest())
            {
                var urlParams = new RequestParams
                {
                    new KeyValuePair<string, string>("method", "anonymous.uploadGetInfo"),
                    new KeyValuePair<string, string>("api_version", "1.2"),
                    new KeyValuePair<string, string>("api_key", sendSpaceApiKey)
                };

                request.UserAgent = "Mozilla 6.0";
                // Отправляем запрос.
                content = request.Get(GetInitAddr(), urlParams).ToString();
            }
            return DeserializeFromXml<FileSendResult>(content);
        }

        public void Zoo(FileUploadInfo fInfo, Stream fileStream)
        {
            using (var request = new HttpRequest())
            {
                //$"_++_______=-++++=-=-=-=--=-{DateTime.Now}--="
                var mForm = new MultipartContent();

                mForm.Add(new StringContent(fInfo.MaxFileSize), "MAX_FILE_SIZE");
                mForm.Add(new StringContent(fInfo.UploadIdentifier), "UPLOAD_IDENTIFIER");
                mForm.Add(new StringContent(fInfo.ExtraInfo), "extra_info");
                //mForm.Add(new StringContent(fInfo.Url), "url");

                //mForm.Add(new StringContent("method"), "anonymous.uploadGetInfo");
                //mForm.Add(new StringContent("api_version"), "1.2");

                mForm.Add(new StreamContent(fileStream), "userfile", "userfile");

                var s = request.Post(fInfo.Url, mForm).ToString();
                int a = 90;
            }
        }

        private FileUploadInfo RetrieveUploadInfo()
        {
            throw new NotImplementedException();
        }







        private static SendSpaceWebClient InitWebClient(ProxySettings sendSpaceAppProxySettings)
        {
            var wc = new SendSpaceWebClient();
            if (sendSpaceAppProxySettings != null)
                wc.Proxy = new WebProxy(new Uri($"{sendSpaceAppProxySettings.ProxyHost}:{sendSpaceAppProxySettings.ProxyPort}"));

            return wc;
        }

        private static SendSpaceWebClient InitWebClientToUploadFile(ProxySettings sendSpaceAppProxySettings)
        {
            var cli = InitWebClient(sendSpaceAppProxySettings);
            cli.Headers.Add("Method", "POST");
            cli.Headers.Add("content-type", "application/octet-stream");
            cli.Headers.Add("enctype", "multipart/form-data");
            return cli;
        }




    }



    public class ErrorRequestAnonymousUploadInfo : Exception
    {
        public ErrorRequestAnonymousUploadInfo()
        {
        }

        public ErrorRequestAnonymousUploadInfo(string message) : base(message)
        {
        }

        public ErrorRequestAnonymousUploadInfo(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ErrorRequestAnonymousUploadInfo(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
