using SW.Entities;
using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Resend
{
    public class ResendService : Services
    {
        private readonly ResponseHandler<Response> _handler;
        public ResendService(string urlApi, string url, string user, string password, int proxyPort, string proxy) : base(urlApi, url, user, password, proxyPort, proxy)
        {
            _handler = new();
        }
        public ResendService(string urlApi, string token, int proxyPort, string proxy) : base(urlApi, token, proxyPort, proxy)
        {
            _handler = new();
        }
        internal async Task<Response> ResendEmailServiceAsync(Guid uuid, string[] email)
        {
            try
            { 
                if (email is null || email.Length <= 0 || email.Length > 5 || !ValidationHelper.ValidateEmail(email))
                {
                    throw new Exception("El listado de correos no tiene un formato válido o contiene mas de 5 correos.");
                }
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(Proxy, ProxyPort);
                var content = JsonBodyHelper.SerializeResend(uuid, email);
                return await _handler.PostAsync(UrlApi ?? Url, "comprobante/resendemail", headers, proxy, content);
            }
            catch(Exception ex)
            {
                return _handler.HandleException(ex);
            }
        } 
    }
}