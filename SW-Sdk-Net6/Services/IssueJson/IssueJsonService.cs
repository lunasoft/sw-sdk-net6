using SW.Handlers;
using SW.Helpers;
using SW.Services.Stamp;

namespace SW.Services.IssueJson
{
    public class IssueJsonService : Services
    {
        private readonly string _path = "cfdi33/issue/json";
        private readonly string _contentType = "application/jsontoxml";
        protected IssueJsonService(string url, string user, string password, int proxyPort, string proxy) 
            : base (url, user, password, proxyPort, proxy)
        {
        }
        protected IssueJsonService(string url, string token, int proxyPort, string proxy) 
            : base (url, token, proxyPort, proxy)
        {
        }
        internal async Task<StampResponseV1> IssueJsonV1Async(string json, StampVersion version, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV1> handler = new();
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                if (version.Equals(StampVersion.V4))
                {
                    if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                    {
                        throw new Exception(message);
                    }
                    headers = RequestHelper.SetupHeaders(headers, customId, email);
                }
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, String.Format("{0}/{1}/{2}", version, _path, StampResponseVersion.V1), headers, proxy, json, _contentType);
            }
            catch(Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV2> IssueJsonV2Async(string json, StampVersion version, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV2> handler = new();
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                if (version.Equals(StampVersion.V4))
                {
                    if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                    {
                        throw new Exception(message);
                    }
                    headers = RequestHelper.SetupHeaders(headers, customId, email);
                }
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, String.Format("{0}/{1}/{2}", version, _path, StampResponseVersion.V2), headers, proxy, json, _contentType);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV3> IssueJsonV3Async(string json, StampVersion version, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV3> handler = new();
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                if (version.Equals(StampVersion.V4))
                {
                    if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                    {
                        throw new Exception(message);
                    }
                    headers = RequestHelper.SetupHeaders(headers, customId, email);
                }
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, String.Format("{0}/{1}/{2}", version, _path, StampResponseVersion.V3), headers, proxy, json, _contentType);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV4> IssueJsonV4Async(string json, StampVersion version, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV4> handler = new();
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                if (version.Equals(StampVersion.V4))
                {
                    if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                    {
                        throw new Exception(message);
                    }
                    headers = RequestHelper.SetupHeaders(headers, customId, email);
                }
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await handler.PostAsync(this.Url, String.Format("{0}/{1}/{2}", version, _path, StampResponseVersion.V4), headers, proxy, json, _contentType);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}