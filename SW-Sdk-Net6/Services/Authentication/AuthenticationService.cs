using SW.Helpers;

namespace SW.Services.Authentication
{
    public class AuthenticationService : Services
    {
        private readonly AuthenticationResponseHandler _handler;
        public AuthenticationService(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxyPort, proxy)
        {
            _handler = new AuthenticationResponseHandler();
        }
        internal async Task<AuthenticationResponse> GetTokenAsync()
        {
            try
            {
                var headers = RequestHelper.SetupHeaders(User, Password);
                var proxy = RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.PostAsync(Url, "security/authenticate", headers, proxy);
            }
            catch(Exception e)
            {
                return _handler.HandleException(e);
            }
        }
    }
}