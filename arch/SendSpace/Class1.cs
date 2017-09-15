using xNet;

namespace arch.SendSpace
{
    public class Class1
    {
        public void S()
        {
            using (var request = new HttpRequest())
            {

                var proxyClient = Socks5ProxyClient.Parse("127.0.0.1:9151");
                proxyClient.ReadWriteTimeout = 1000;
                request.Proxy = proxyClient;

                var multipartContent = new MultipartContent()
                {
                    {new StringContent("Bill Gates"), "login"},
                    {new StringContent("qwerthahaha"), "password"},
                    {new FileContent(@"r:\p1.py"), "file1", "1.rar"}
                };

                var s = request.Post("http://api.sendspace.com/rest/?method=anonymous.uploadGetInfo&api_key={ApiKey}&api_version=1.2", multipartContent);
            }
        }
    }
}
