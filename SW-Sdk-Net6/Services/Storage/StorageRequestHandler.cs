using SW.Entities;
using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Storage
{
    internal class StorageRequestHandler : RequestHandler<StorageResponse>
    {
        internal async Task<StorageResponse> GetResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            var result = await GetAsync(url, path, headers, proxy);
            return result.Data?.Records.Length <= 0 ? HandleException(new Exception("No se encuentra registro del timbrado.")) : result;
        }
    }
    internal class StorageExtraRequestHandler : RequestHandler<StorageExtraResponse>
    {
        internal async Task<StorageExtraResponse> GetResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            var result = await GetAsync(url, path, headers, proxy);
            return result.Data?.Records.Length <= 0 ? HandleException(new Exception("No se encuentra registro del timbrado.")) : result;
        }
    }
}