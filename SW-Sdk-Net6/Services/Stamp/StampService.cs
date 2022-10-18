using SW.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SW.Services.Stamp
{
    public class StampService : Services
    {
        string path = "/cfdi33";
        public StampService(string url, string token, int proxyPort, string proxy) : base (url, token, proxyPort, proxy)
        {
        }
        public StampService(string url, string user, string password, int proxyPort, string proxy) : base(url, user, password, proxyPort, proxy)
        {
        }
        internal async Task<StampResponseV1> StampV1Async(byte[] xml, bool isB64, StampAction action)
        {
            StampResponseHandlerV1 handler = new StampResponseHandlerV1();
            try
            {
                path = String.Format("{0}/{1}/{2}/{3}", path, action, "v1", isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV2> StampV2Async(byte[] xml, bool isB64, StampAction action)
        {
            StampResponseHandlerV2 handler = new StampResponseHandlerV2();
            try
            {
                path = String.Format("{0}/{1}/{2}/{3}", path, action, "v2", isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV3> StampV3Async(byte[] xml, bool isB64, StampAction action)
        {
            StampResponseHandlerV3 handler = new StampResponseHandlerV3();
            try
            {
                path = String.Format("{0}/{1}/{2}/{3}", path, action, "v3", isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV4> StampV4Async(byte[] xml, bool isB64, StampAction action)
        {
            StampResponseHandlerV4 handler = new StampResponseHandlerV4();
            try
            {
                path = String.Format("{0}/{1}/{2}/{3}", path, action, "v4", isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
