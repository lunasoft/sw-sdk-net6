using Newtonsoft.Json;
using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Cancelation
{
    public class CancelationService : Services
    {
        private CancelationResponseHandler _handler;
        private string path = "/cfdi33/cancel";
        public CancelationService(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxyPort, proxy)
        {
            _handler = new CancelationResponseHandler();
        }
        public CancelationService(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxyPort, proxy)
        {
            _handler = new CancelationResponseHandler();
        }
        internal async Task<CancelationResponse> CancelationAsync(CancelationRequest folio)
        {
            try
            {
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                path = String.Format("{0}/{1}/{2}/{3}/{4}", path, folio.Rfc, folio.Uuid.ToString(), folio.Motivo,
                    folio.FolioSustitucion != null ? folio.FolioSustitucion.ToString() : String.Empty);
                return await _handler.PostAsync(this.Url, path, headers, proxy);
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        internal async Task<CancelationResponse> CancelationAsync(CancelationRequest folio, byte[] cer, byte[] key, string password)
        {
            try
            {
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                path = String.Format("{0}/{1}", path, "csd");
                var body = CancelationRequestBody(folio, cer, key, null, password);
                return await _handler.PostAsync(this.Url, path, headers, proxy, JsonConvert.SerializeObject(body));
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        internal async Task<CancelationResponse> CancelationAsync(CancelationRequest folio, byte[] pfx, string password)
        {
            try
            {
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                path = String.Format("{0}/{1}", path, "pfx");
                var body = CancelationRequestBody(folio, null, null, pfx, password);
                return await _handler.PostAsync(this.Url, path, headers, proxy, JsonConvert.SerializeObject(body));
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        internal async Task<CancelationResponse> CancelationAsync(byte[] xml)
        {
            try
            {
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                path = String.Format("{0}/{1}", path, "xml");
                return await _handler.PostAsync(this.Url, path, headers, proxy, xml);
            }
            catch (Exception ex)
            {
                return _handler.HandleException(ex);
            }
        }
        private Object CancelationRequestBody(CancelationRequest folio, byte[] cer, byte[] key, byte[] pfx, string password)
        {
            return new
            {
                Rfc = folio.Rfc,
                Uuid = folio.Uuid,
                Motivo = folio.Motivo,
                FolioSustitucion = folio.FolioSustitucion,
                b64Cer = cer is null ? null : Convert.ToBase64String(cer),
                b64Key = key is null ? null : Convert.ToBase64String(key),
                b64Pfx = pfx is null ? null : Convert.ToBase64String(pfx),
                password = password,
            };
        }
    }
}
