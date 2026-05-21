namespace SW.Services
{
    public class Services
    {
        private string _token;
        private readonly string _url;
        private readonly string _urlApi;
        private readonly string _user;
        private readonly string _password;
        private readonly string? _proxy;
        private readonly int _proxyPort;
        private DateTime _expirationDate;
        private readonly int _timeSession = 2;

        internal string Token { get { return _token; } }
        internal string Url { get { return _url; } }
        internal string UrlApi { get { return _urlApi; } }
        internal string User { get { return _user; } }
        internal string Password { get { return _password; } }
        internal string? Proxy { get { return _proxy; } }
        internal int ProxyPort { get { return _proxyPort; } }
        internal DateTime ExpirationDate { get { return _expirationDate; } }

        protected Services(string url, string token, int proxyPort, string proxy)
        {
            _url = url;
            _token = token;
            _expirationDate = DateTime.Now.AddHours(_timeSession);
            _proxy = proxy;
            _proxyPort = proxyPort;
        }
        protected Services(string url, string user, string password, int proxyPort, string proxy)
        {
            _url = url;
            _user = user;
            _password = password;
            _proxy = proxy;
            _proxyPort = proxyPort;
        }
        protected Services(string urlApi, string url, string user, string password, int proxyPort, string proxy)
        {
            _url = url;
            _urlApi = urlApi;
            _user = user;
            _password = password;
            _proxyPort = proxyPort;
            _proxy = proxy;
        }
        internal async Task<Services> SetupAuthAsync()
        {
            if(String.IsNullOrEmpty(Token) || DateTime.Now > ExpirationDate)
            {
                Authentication.Authentication authentication = new(Url, User, Password, ProxyPort, Proxy);
                var result = await authentication.GenerateTokenAsync();

                if(result != null && result.Status.Equals("success"))
                {
                    _token = result.Data.Token;
                    _expirationDate = DateTime.Now.AddHours(_timeSession);
                }
            }
            return this;
        }
    }
}
