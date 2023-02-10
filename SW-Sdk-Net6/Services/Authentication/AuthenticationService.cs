using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Authentication
{
    public class AuthenticationService : Services
    {
        private readonly RequestHandler<AuthenticationResponse> _handler;
        private readonly string _path = "/security/authenticate";
        protected AuthenticationService(string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base(url, user, password, proxyPort, proxy)
        {
            _handler = new();
        }
        internal async Task<AuthenticationResponse> GetTokenAsync()
        {
            try
            {
                var headers = RequestHelper.SetupHeaders(User, Password);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.PostAsync(Url, _path, headers, proxy);
            }
            catch(Exception e)
            {
                return _handler.HandleException(e);
            }
        }
    }
}