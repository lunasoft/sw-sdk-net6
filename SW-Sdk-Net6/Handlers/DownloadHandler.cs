using SW.Entities;
using SW.Helpers;
using SW.Services.Stamp;
using System.Net;

namespace SW.Handlers
{
    internal class DownloadHandler<T> where T : Response, new()
    {
        private readonly ResponseHandler<T> _handler = new();
        internal async Task<T> DownloadFileAsync(string url, HttpClientHandler proxy)
        {
            try
            {
                using HttpClient client = new(proxy);
                var response = await client.GetAsync(url);
                return await TryGetContentAsync(response);
            }
            catch (HttpRequestException ex)
            {
                return _handler.GetExceptionResponse(ex);
            }
        }
        private async Task<T> TryGetContentAsync(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return new T()
                {
                    Status = "success",
                    Message = await response.Content.ReadAsStringAsync()
                };
            }
            return new()
            {
                Status = "error",
                Message = "No se pudo completar la descarga.",
                MessageDetail = response.ReasonPhrase
            };
        }
    }
}