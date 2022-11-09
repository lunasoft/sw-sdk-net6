using SW.Entities;
using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Balance
{
    internal class BalanceResponseHandler : ResponseHandler<BalanceResponse>
    {
        internal async Task<BalanceResponse> GetBalanceResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            var result = await GetAsync(url, path, headers, proxy);
            return result.Status.Equals("success") && !Guid.TryParse(result.Data?.IdSaldoCliente, out _) 
                    ? HandleException(new Exception("No se encuentra registro de usuario.")) : result;
        } 
        internal BalanceResponse HandleException(Exception ex)
        {
            return (BalanceResponse)ResponseHelper.ToErrorResponse(ex);
        }
    }
    internal class StampBalanceResponseHandler : ResponseHandler<StampBalanceResponse>
    {
        internal StampBalanceResponse HandleException(Exception ex)
        {
            return (StampBalanceResponse)ResponseHelper.ToErrorResponse(ex);
        }
    } 
}
