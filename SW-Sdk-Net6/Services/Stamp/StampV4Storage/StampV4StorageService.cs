using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Stamp
{
    public class StampV4StorageService : Services
    {
        private readonly RequestHandler<StampResponseV2> _handler;
        private readonly string _urlApi;
        private readonly string _path = "/v4/cfdi33";
        protected StampV4StorageService(string urlApi, string url, string user, string password, int proxyPort, string proxy) 
            : base(url, user, password, proxyPort, proxy)
        {
            _urlApi = urlApi;
            _handler = new();
        }
        protected StampV4StorageService(string urlApi, string url, string token, int proxyPort, string proxy) 
            : base(url, token, proxyPort, proxy)
        {
            _urlApi = urlApi;
            _handler = new();
        }
        internal async Task<StampResponseV2> StampStorageServiceV2Async(byte[] xml, bool isB64, StampAction action, string customId = null, string[] email = null, bool pdf = false)
        {
            try
            {
                string path = String.Format("{0}/{1}/{2}/{3}", _path, action, StampResponseVersion.V2, isB64 ? "b64" : String.Empty);
                if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                {
                    throw new Exception(message);
                }
                var request = await RequestHelper.SetupRequestAsync(this, customId, email, pdf);
                var response = await _handler.PostAsync(this.Url, path, request, xml);
                if (response.Status.Equals("error") && response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.") 
                    && String.IsNullOrEmpty(response.Data.Cfdi) && ConvertionHelper.TryGetUuid(response.Data.Tfd, out Guid uuid, isB64))
                {
                    Storage.Storage storage = new(_urlApi, Token, ProxyPort, Proxy);
                    var result = await storage.GetXmlAsync(uuid);
                    return await ConvertionHelper.ToStampResponseV2(response, result, request.Proxy, isB64);
                }
                return response;
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
    }
}