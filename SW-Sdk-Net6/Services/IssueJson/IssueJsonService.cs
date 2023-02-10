using SW.Entities;
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
                var request = await IssueJsonServiceAsync(version, StampResponseVersion.V1, _path, customId, email, pdf);
                return await handler.PostAsync(Url, request.Path, request.Headers, request.Proxy, json, _contentType);
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
                var request = await IssueJsonServiceAsync(version, StampResponseVersion.V2, _path, customId, email, pdf);
                return await handler.PostAsync(Url, request.Path, request.Headers, request.Proxy, json, _contentType);
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
                var request = await IssueJsonServiceAsync(version, StampResponseVersion.V3, _path, customId, email, pdf);
                return await handler.PostAsync(Url, request.Path, request.Headers, request.Proxy, json, _contentType);
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
                var request = await IssueJsonServiceAsync(version, StampResponseVersion.V4, _path, customId, email, pdf);
                return await handler.PostAsync(Url, request.Path, request.Headers, request.Proxy, json, _contentType);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        private async Task<Request> IssueJsonServiceAsync(StampVersion stampVersion, StampResponseVersion responseVersion, string path, string customId, string[] email, bool pdf)
        {
            var request = await RequestHelper.SetupRequestAsync(this);
            request.Path = String.Format("{0}/{1}/{2}", stampVersion, path, responseVersion);
            if (stampVersion.Equals(StampVersion.V4))
            {
                if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                {
                    throw new Exception(message);
                }
                request.Headers = RequestHelper.SetupHeaders(request.Headers, customId, email, pdf);
            }
            return request;
        }
    }
}