using SW.Entities;
using SW.Helpers;

namespace SW.Services.Balance
{
    public class BalanceService : Services
    {
        private readonly string _path = "/management/api/balance";
        public BalanceService(string urlApi, string url, string user, string password, int proxyPort, string proxy) : base(urlApi, url, user, password, proxyPort, proxy)
        {
        }
        public BalanceService(string urlApi, string token, int proxyPort, string proxy) : base(urlApi, token, proxyPort, proxy)
        {
        }
        internal async Task<BalanceResponse> BalanceAsync(Guid? idUser)
        {
            BalanceResponseHandler handler = new();
            try
            {
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(Proxy, ProxyPort);
                return await handler.GetBalanceResponseAsync(Url, idUser is null ? _path : String.Format("/{0}/{1}", _path, idUser), headers, proxy);
            }
            catch(Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
        internal async Task<StampBalanceResponse> StampBalanceAsync(Guid idUser, BalanceAction action, int stampCount, string? comment)
        {
            StampBalanceResponseHandler handler = new();
            try
            {   
                if (!ValidationHelper.ValidateBalanceRequest(idUser, stampCount, out string message)) throw new Exception(message);
                var headers = await RequestHelper.SetupAuthHeaderAsync(this);
                var proxy = RequestHelper.ProxySettings(Proxy, ProxyPort);
                return await handler.GetAsync(Url, String.Format("/{0}/{1}/{2}", idUser, action, stampCount), headers, proxy);
            }
            catch (Exception ex)
            {
                return handler.HandleException(ex);
            }
        }
    }
}
