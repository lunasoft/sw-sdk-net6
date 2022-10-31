using SW.Entities;
using SW.Helpers;
using SW.Services.Stamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SW.Handlers
{
    internal class DownloadHandler<T> where T : Response, new()
    {
        private ResponseHandlerExtended<T> _handler = new();
        internal async Task<T> DownloadFileAsync(string url, HttpClientHandler proxy)
        {
            try
            {
                using (HttpClient client = new(proxy))
                {
                    var response = await client.GetAsync(url);
                    return await TryGetContentAsync(response);
                }
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