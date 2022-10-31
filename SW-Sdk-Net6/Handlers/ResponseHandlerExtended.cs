using SW.Entities;
using System.Net;

namespace SW.Handlers
{
    internal class ResponseHandlerExtended<T> where T : Response, new()
    {
        internal async Task<T> TryGetResponseAsync(HttpResponseMessage response)
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
        internal T GetExceptionResponse(HttpRequestException ex)
        {
            return new T()
            {
                Message = ex.Message,
                Status = "error",
                MessageDetail = ex.StackTrace
            };
        }
        private T GetExceptionResponse(HttpResponseMessage response)
        {
            return new T()
            {
                Message = ((int)response.StatusCode).ToString(),
                Status = "error",
                MessageDetail = response.ReasonPhrase
            };
        }
    }
}