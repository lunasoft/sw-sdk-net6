using SW.Entities;
using SW.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services
{
    public class Services
    {
        private string _token;
        private string _url;
        private string _user;
        private string _password;
        private string? _proxy;
        private int _proxyPort;
        private DateTime _expirationDate;
        private int _timeSession = 2;

        internal string Token { get { return _token; } }
        internal string Url { get { return _url; } }
        internal string User { get { return _user; } }
        internal string Password { get { return _password; } }
        internal string? Proxy { get { return _proxy; } }
        internal int ProxyPort { get { return _proxyPort; } }
        internal DateTime ExpirationDate { get { return _expirationDate; } }
        public Services(string url, string token, int proxyPort, string proxy)
        {
            _url = url;
            _token = token;
            _expirationDate = DateTime.Now.AddHours(_timeSession);
            _proxy = proxy;
            _proxyPort = proxyPort;
        }
        public Services(string url, string user, string password, int proxyPort, string proxy)
        {
            _url = url;
            _user = user;
            _password = password;
            _proxy = proxy;
            _proxyPort = proxyPort;
        }
        internal async Task<Services> SetupAuthAsync()
        {
            if(String.IsNullOrEmpty(Token) || DateTime.Now > ExpirationDate)
            {
                Authentication.Authentication authentication = new Authentication.Authentication(Url, User, Password, ProxyPort, Proxy);
                var result = await authentication.GenerateTokenAsync();

                if(result != null && result.status.Equals("success"))
                {
                    _token = result.data.token;
                    _expirationDate = DateTime.Now.AddHours(_timeSession);
                }
            }
            return this;
        }
    }
}
