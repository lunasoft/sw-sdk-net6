using SW.Entities;
using SW.Helpers;

namespace SW.Services.Pdf
{
    public class PdfService : Services
    {
        private readonly PdfResponseHandler _handler;
        private readonly string _path = "/pdf/v1/api";
        public PdfService(string urlApi, string url, string user, string password, int proxyPort, string proxy) : base(urlApi, url, user, password, proxyPort, proxy)
        {
            _handler = new();
        }
        public PdfService(string urlApi, string token, int proxyPort, string proxy) : base(urlApi, token, proxyPort, proxy)
        {
            _handler = new();
        }
        internal async Task<PdfResponse> GeneratePdfServiceAsync(string xml, string template, Dictionary<string, string> extras, string logo, bool isB64)
        {
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(Proxy, ProxyPort);
                var content = JsonBodyHelper.SerializePdf(!isB64 ? xml : xml.ConvertFromB64(), template, extras, logo); ; ;
                var path = String.Format("{0}/{1}", _path, "GeneratePdf");
                return await _handler.PostAsync(UrlApi ?? Url, path, headers, proxy, content);
            }
            catch(Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        internal async Task<Response> RegeneratePdfServiceAsync(Guid uuid)
        {
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(Proxy, ProxyPort);
                var path = String.Format("{0}/{1}/{2}", _path, "regeneratepdf", uuid.ToString());
                return await _handler.PostAsync(UrlApi ?? Url, path, headers, proxy);
            }
            catch(Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
    }
}