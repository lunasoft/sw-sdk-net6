using SW.Entities;
using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Stamp
{
    public class StampService : Services
    {
        private readonly string _path = "/cfdi33";
        protected StampService(string url, string token, int proxyPort, string proxy)
            : base(url, token, proxyPort, proxy)
        {
        }
        protected StampService(string url, string user, string password, int proxyPort, string proxy)
            : base(url, user, password, proxyPort, proxy)
        {
        }
        internal async Task<StampResponseV1> StampServiceV1Async(byte[] xml, StampAction action, StampVersion stampVersion, bool isB64, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV1> handler = new();
            try
            {
                var request = await StampServiceAsync(action, stampVersion, StampResponseVersion.V1, _path, isB64, customId, email, pdf);
                return await handler.PostAsync(Url, request.Path, request, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV2> StampServiceV2Async(byte[] xml, StampAction action, StampVersion stampVersion, bool isB64, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV2> handler = new();
            try
            {
                var request = await StampServiceAsync(action, stampVersion, StampResponseVersion.V2, _path, isB64, customId, email, pdf);
                return await handler.PostAsync(Url, request.Path, request, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV3> StampServiceV3Async(byte[] xml, StampAction action, StampVersion stampVersion, bool isB64, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV3> handler = new();
            try
            {
                var request = await StampServiceAsync(action, stampVersion, StampResponseVersion.V3, _path, isB64, customId, email, pdf);
                return await handler.PostAsync(Url, request.Path, request, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampResponseV4> StampServiceV4Async(byte[] xml, StampAction action, StampVersion stampVersion, bool isB64, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV4> handler = new();
            try
            {
                var request = await StampServiceAsync(action, stampVersion, StampResponseVersion.V4, _path, isB64, customId, email, pdf);
                return await handler.PostAsync(Url, request.Path, request, xml);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        private async Task<Request> StampServiceAsync(StampAction action, StampVersion stampVersion, StampResponseVersion responseVersion, string path, bool isB64, string customId, string[] email, bool pdf)
        {
            var request = await RequestHelper.SetupRequestAsync(this, customId, email, pdf);
            request.Path = String.Format("{0}/{1}/{2}/{3}", path, action, responseVersion, isB64 ? "b64" : String.Empty);
            if (stampVersion.Equals(StampVersion.V4))
            {
                if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                {
                    throw new Exception(message);
                }
                request.Path = String.Format("{0}/{1}", stampVersion, request.Path);
            }
            return request;
        }
    }
}