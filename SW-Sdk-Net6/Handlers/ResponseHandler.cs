using SW.Entities;
using SW.Helpers;
using System.Net;
using System.Text.Json;

namespace SW.Handlers
{
    internal class ResponseHandler<T> where T : Response, new()
    {
        internal async Task<T> TryGetResponseAsync(HttpResponseMessage response)
        {
            try
            {
                if (IsSuccessStatusCode(response.StatusCode))
                {
                    return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), 
                                                                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                return GetExceptionResponse(response);
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex);
            }
        }
        private static bool IsSuccessStatusCode(HttpStatusCode statusCode)
        {
            return statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.BadRequest || statusCode == HttpStatusCode.Unauthorized;
        }
        internal T GetExceptionResponse(Exception ex)
        {
            return new T
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = ResponseHelper.GetErrorDetail(ex)
            };
        }
        private T GetExceptionResponse(HttpResponseMessage response)
        {
            return new T
            {
                Message = ((int)response.StatusCode).ToString(),
                Status = "error",
                MessageDetail = response.ReasonPhrase
            };
        }
    }
}