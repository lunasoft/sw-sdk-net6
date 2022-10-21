using SW.Helpers;
using SW.Services.Stamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.IssueJson
{
    public class IssueJsonService : Services
    {
        private string _path = "/v3/cfdi33/issue/json";
        private string _contentType = "application/jsontoxml";
        public IssueJsonService(string url, string user, string password, int proxyPort, string proxy) : base (url, user, password, proxyPort, proxy)
        {
        }
        public IssueJsonService(string url, string token, int proxyPort, string proxy) : base (url, token, proxyPort, proxy)
        {
        }
        internal async Task<StampResponseV1> IssueJsonV1Async(string json)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, String.Format("{0}/{1}", _path, "v1"), headers, proxy, json, _contentType);

            }
            catch(Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV2> IssueJsonV2Async(string json)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2();
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, String.Format("{0}/{1}", _path, "v2"), headers, proxy, json, _contentType);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV3> IssueJsonV3Async(string json)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3();
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, String.Format("{0}/{1}", _path, "v3"), headers, proxy, json, _contentType);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV4> IssueJsonV4Async(string json)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4();
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, String.Format("{0}/{1}", _path, "v4"), headers, proxy, json, _contentType);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
