using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Cancellation
{
    public class CancellationService : Services
    {
        private readonly RequestHandler<CancellationResponse> _handler;
        private readonly string _path = "/cfdi33/cancel";
        protected CancellationService(string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base(url, user, password, proxyPort, proxy)
        {
            _handler = new();
        }
        protected CancellationService(string url, string token, int proxyPort = 0, string proxy = null) 
            : base(url, token, proxyPort, proxy)
        {
            _handler = new();
        }
        internal async Task<CancellationResponse> CancellationAsync(CancellationRequest folio)
        {
            try
            {
                if(!ValidationHelper.ValidateCancellationRequest(folio, out string message))
                    throw new Exception(message);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                string path = String.Format("{0}/{1}/{2}/{3}/{4}", _path, folio.Rfc, folio.Uuid.ToString(), folio.Motivo,
                    folio.FolioSustitucion != null ? folio.FolioSustitucion.ToString() : String.Empty);
                return await _handler.PostAsync(this.Url, path, headers, proxy);
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        internal async Task<CancellationResponse> CancellationAsync(CancellationRequest folio, byte[] cer, byte[] key, string password)
        {
            try
            {
                if (!ValidationHelper.ValidateCancellationRequest(folio, out string message))
                    throw new Exception(message);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                string path = String.Format("{0}/{1}", _path, "csd");
                return await _handler.PostAsync(this.Url, path, headers, proxy, JsonBodyHelper.SerializeCancellation(folio, password, cer, key, null));
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        internal async Task<CancellationResponse> CancellationAsync(CancellationRequest folio, byte[] pfx, string password)
        {
            try
            {
                if (!ValidationHelper.ValidateCancellationRequest(folio, out string message))
                    throw new Exception(message);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                string path = String.Format("{0}/{1}", _path, "pfx");
                return await _handler.PostAsync(this.Url, path, headers, proxy, JsonBodyHelper.SerializeCancellation(folio, password, null, null, pfx));
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        internal async Task<CancellationResponse> CancellationAsync(byte[] xml)
        {
            try
            {
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                string path = String.Format("{0}/{1}", _path, "xml");
                return await _handler.PostAsync(this.Url, path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
    }
}