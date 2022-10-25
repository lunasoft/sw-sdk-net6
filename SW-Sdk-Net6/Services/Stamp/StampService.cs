using SW.Helpers;

namespace SW.Services.Stamp
{
    public class StampService : Services
    {
        string _path = "/cfdi33";
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
                _path = String.Format("{0}/{1}/{2}/{3}", _path, action, "v1", isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, _path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV2> StampV2Async(byte[] xml, bool isB64, StampAction action)
        {
            StampResponseHandlerV2 handler = new ();
            try
            {
                _path = String.Format("{0}/{1}/{2}/{3}", _path, action, "v2", isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, _path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV3> StampV3Async(byte[] xml, bool isB64, StampAction action)
        {
            StampResponseHandlerV3 handler = new ();
            try
            {
                _path = String.Format("{0}/{1}/{2}/{3}", _path, action, "v3", isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, _path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV4> StampV4Async(byte[] xml, bool isB64, StampAction action)
        {
            StampResponseHandlerV4 handler = new ();
            try
            {
                _path = String.Format("{0}/{1}/{2}/{3}", _path, action, "v4", isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, _path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}