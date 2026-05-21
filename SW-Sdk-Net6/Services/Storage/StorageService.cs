using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Storage
{
    public class StorageService : Services
    {
        private readonly string _path = "/datawarehouse/v1/live";
        protected StorageService(string urlApi, string url, string user, string password, int proxyPort, string proxy) 
            : base(urlApi, url, user, password, proxyPort, proxy)
        {
        }
        protected StorageService(string urlApi, string token, int proxyPort, string proxy) 
            : base(urlApi, token, proxyPort, proxy)
        {
        }
        internal async Task<StorageResponse> RetrieveXmlAsync(Guid uuid)
        {
            StorageRequestHandler handler = new();
            try
            {
                var request = await RequestHelper.SetupRequestAsync(this);
                var path = String.Format("{0}/{1}", _path, uuid.ToString());
                return await handler.GetResponseAsync(UrlApi ?? Url, path, request);
            }
            catch(Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StorageExtraResponse> RetrieveXmlExtrasAsync(Guid uuid)
        {
            StorageExtraRequestHandler handler = new();
            try
            {
                var request = await RequestHelper.SetupRequestAsync(this);
                var path = String.Format("{0}/{1}", _path, uuid.ToString());
                return await handler.GetResponseAsync(UrlApi ?? Url, path, request);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
