using SW.Entities;
using System.Net;

namespace SW.Helpers
{
    internal class RequestHelper
    {
        internal static Request SetupRequest(Services.Services services, string user, string password)
        {
            return new()
            {
                Headers = new() { { "user", user }, { "password", password } },
                Proxy = SetProxy(services.Proxy, services.ProxyPort)
            };
        }
        internal static async Task<Request> SetupRequestAsync(Services.Services services)
        {
            return new()
            {
                Headers = await SetAuthenticationAsync(services),
                Proxy = SetProxy(services.Proxy, services.ProxyPort)
            };
        }
        internal static async Task<Request> SetupRequestAsync(Services.Services services, string customId, string[] emails = null, bool pdf = false)
        {
            var headers = await SetAuthenticationAsync(services);
            headers.Add("customid", customId);
            if (emails != null)
            {
                headers.Add("email", String.Join(',', emails).Trim());
            }
            if (pdf)
            {
                headers.Add("pdf", String.Empty);
            }
            return new()
            {
                Headers = headers,
                Proxy = SetProxy(services.Proxy, services.ProxyPort)
            };
        }
        private static HttpClientHandler SetProxy(string proxy, int proxyPort)
        {
            return !string.IsNullOrEmpty(proxy) ? new() 
            {
                Proxy = new WebProxy(string.Format("{0}:{1}", proxy, proxyPort), false),
                UseProxy = true
            } : new();
        }
        private static async Task<Dictionary<string, string>> SetAuthenticationAsync(Services.Services services)
        {
            var setup = await services.SetupAuthAsync();
            return new()
            {
                { "Authorization", "bearer " + setup.Token }
            };
        }
    }
}