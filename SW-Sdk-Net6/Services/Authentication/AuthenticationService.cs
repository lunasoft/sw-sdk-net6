using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Authentication
{
    public class AuthenticationService : Services
    {
        private AuthenticationResponseHandler _handler;
        public AuthenticationService(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxyPort, proxy)
        {
            _handler = new AuthenticationResponseHandler();
        }
        internal async Task<AuthenticationResponse> GetTokenAsync()
        {
            try
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("user", this.User);
                headers.Add("password", this.Password);
                var proxy = Helpers.RequestHelper.ProxySettings(this.Proxy, this.ProxyPort);
                return await _handler.PostAsync(Url, "security/authenticate", headers, proxy);
            }
            catch(Exception e)
            {
                return _handler.HandleException(e);
            }
        }
    }
}
