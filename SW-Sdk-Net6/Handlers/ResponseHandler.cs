using SW.Entities;
using SW.Helpers;
using System.Net;

namespace SW.Handlers
{
    internal class ResponseHandler<T> where T : Response, new()
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
        internal T GetExceptionResponse(Exception ex)
        {
            return new T()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = ResponseHelper.GetErrorDetail(ex)
            };
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