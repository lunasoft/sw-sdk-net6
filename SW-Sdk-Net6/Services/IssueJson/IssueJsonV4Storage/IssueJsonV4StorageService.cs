using SW.Handlers;
using SW.Helpers;
using SW.Services.Stamp;

namespace SW.Services.IssueJson
{
    public class IssueJsonV4StorageService : Services
    {
        private readonly string _urlApi;
        private readonly string _path = "/v4/cfdi33/issue/json";
        private readonly string _contentType = "application/jsontoxml";
        protected IssueJsonV4StorageService(string urlApi, string url, string user, string password, int proxyPort, string proxy) 
            : base(url, user, password, proxyPort, proxy)
        {
            _urlApi = urlApi;
        }
        protected IssueJsonV4StorageService(string urlApi, string url, string token, int proxyPort, string proxy) 
            : base(url, token, proxyPort, proxy)
        {
            _urlApi = urlApi;
        }
        internal async Task<StampResponseV2> IssueJsonStorageServiceV2Async(string json, string customId = null, string[] email = null, bool pdf = false)
        {
            RequestHandler<StampResponseV2> handler = new();
            try
            {
                string path = String.Format("{0}/{1}", _path, StampResponseVersion.V2);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                if (!ValidationHelper.ValidateCustomHeaders(customId, email, out string message))
                {
                    throw new Exception(message);
                }
                headers = RequestHelper.SetupHeaders(headers, customId, email);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var response = await handler.PostAsync(Url, path, headers, proxy, json, _contentType);
                if (response.Status.Equals("error") && response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado.")
                    && String.IsNullOrEmpty(response.Data.Cfdi) && ConvertionHelper.TryGetUuid(response.Data.Tfd, out Guid uuid))
                {
                    Storage.Storage storage = new(_urlApi, Token, ProxyPort, Proxy);
                    var result = await storage.GetXmlAsync(uuid);
                    return await ConvertionHelper.ToStampResponseV2(response, result, proxy);
                }
                return response;
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}