using SW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SW.Handlers
{
    internal class ResponseHandlerExtended<T> where T : Response, new()
    {
        internal async Task<T> PostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpContent? content, HttpClientHandler proxy)
        {
            HttpResponseMessage result;
            try
            {
                using (HttpClient client = new HttpClient(proxy, false))
                {
                    client.BaseAddress = new Uri(url);
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                    result = await client.PostAsync(path, content);
                }

                return await TryGetResponseAsync(result);
            }
            catch (HttpRequestException ex)
            {
                return GetExceptionResponse(ex);
            }
        }
        private async Task<T> TryGetResponseAsync(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
                return GetExceptionResponse(response);
            }
            catch
            {
                return GetExceptionResponse(response);
            }
        }
        private T GetExceptionResponse(HttpRequestException ex)
        {
            return new T()
            {
                message = ex.Message,
                status = "error",
                messageDetail = ex.StackTrace
            };
        }
        private T GetExceptionResponse(HttpResponseMessage response)
        {
            return new T()
            {
                message = ((int)response.StatusCode).ToString(),
                status = "error",
                messageDetail = response.ReasonPhrase
            };
        }
    }
}
