using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SW.Services;

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
        internal static async Task<Dictionary<string, string>> SetupAuthHeaderAsync(Services.Services services)
        {
            var setup = await services.SetupAuthAsync();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", "bearer " + setup.Token);
            return headers;
        }
    }
}
