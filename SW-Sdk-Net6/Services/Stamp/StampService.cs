using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Stamp
{
    public class StampService : Services
    {
        private readonly string _path = "/cfdi33";
        public StampService(string url, string token, int proxyPort, string proxy) 
            : base (url, token, proxyPort, proxy)
        {
        }
        public StampService(string url, string user, string password, int proxyPort, string proxy) 
            : base(url, user, password, proxyPort, proxy)
        {
        }
        internal async Task<StampResponseV1> StampServiceV1Async(byte[] xml, bool isB64, StampAction action, StampVersion version, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV1> handler = new();
            try
            {
                string path = String.Format("{0}/{1}/{2}/{3}", _path, action, StampResponseVersion.V1, isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                if (version.Equals(StampVersion.V4))
                {
                    if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                    {
                        throw new Exception(message);
                    }
                    headers = RequestHelper.SetupHeaders(headers, customId, email);
                    path = String.Format("{0}/{1}", version, path);
                }
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV2> StampServiceV2Async(byte[] xml, bool isB64, StampAction action, StampVersion version, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV2> handler = new();
            try
            {
                string path = String.Format("{0}/{1}/{2}/{3}", _path, action, StampResponseVersion.V2, isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                if (version.Equals(StampVersion.V4))
                {
                    if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                    {
                        throw new Exception(message);
                    }
                    headers = RequestHelper.SetupHeaders(headers, customId, email);
                    path = String.Format("{0}/{1}", version, path);
                }
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV3> StampServiceV3Async(byte[] xml, bool isB64, StampAction action, StampVersion version, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV3> handler = new();
            try
            {
                string path = String.Format("{0}/{1}/{2}/{3}", _path, action, StampResponseVersion.V3, isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                if (version.Equals(StampVersion.V4))
                {
                    if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                    {
                        throw new Exception(message);
                    }
                    headers = RequestHelper.SetupHeaders(headers, customId, email);
                    path = String.Format("{0}/{1}", version, path);
                }
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV4> StampServiceV4Async(byte[] xml, bool isB64, StampAction action, StampVersion version, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV4> handler = new();
            try
            {
                string path = String.Format("{0}/{1}/{2}/{3}", _path, action, StampResponseVersion.V4, isB64 ? "b64" : String.Empty);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                if (version.Equals(StampVersion.V4))
                {
                    if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                    {
                        throw new Exception(message);
                    }
                    headers = RequestHelper.SetupHeaders(headers, customId, email);
                    path = String.Format("{0}/{1}", version, path);
                }
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