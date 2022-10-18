using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SW.Helpers
{
    internal class RequestHelper
    {
        internal static HttpClientHandler ProxySettings(string proxy, int proxyPort)
        {
            if (!string.IsNullOrEmpty(proxy))
            {
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = new WebProxy(string.Format("{0}:{1}", proxy, proxyPort), false),
                    UseProxy = true
                };
                return httpClientHandler;
            }
            else
            {
                return new HttpClientHandler();
            }
        }
    }
}
