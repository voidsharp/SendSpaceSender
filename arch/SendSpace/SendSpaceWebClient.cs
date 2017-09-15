using System;
using System.Net;

namespace arch.SendSpace
{
    public class SendSpaceWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var timeout = 60 * 1000;
            var r = base.GetWebRequest(address);
            r.Timeout = timeout;
            return r;
        }
    }
}
