using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Storage
{
    internal class StorageResponseHandler : ResponseHandler<StorageResponse>
    {
        internal async Task<StorageResponse> GetStorageResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            var result = await GetAsync(url, path, headers, proxy);
            return result.Data?.Records.Length <= 0 ? HandleException(new Exception("No se encuentra registro del timbrado.")) : result;
        }
        internal StorageResponse HandleException(Exception ex)
        {
            return ResponseHelper.ToStorageResponse(ex);
        }
    }
    internal class StorageExtraResponseHandler : ResponseHandler<StorageExtraResponse>
    {
        internal async Task<StorageExtraResponse> GetStorageExtrasResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            var result = await GetAsync(url, path, headers, proxy);
            return result.Data?.Records.Length <= 0 ? HandleException(new Exception("No se encuentra registro del timbrado.")) : result;
        }
        internal StorageExtraResponse HandleException(Exception ex)
        {
            return ResponseHelper.ToStorageExtraResponse(ex);
        }
    }
}