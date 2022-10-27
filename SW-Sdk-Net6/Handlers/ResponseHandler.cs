using SW.Entities;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SW.Handlers
{
    internal class ResponseHandler<T> where T : Response, new() 
    {
        private ResponseHandlerExtended<T> _handler;
        internal ResponseHandler()
        {
            _handler = new ResponseHandlerExtended<T>();
        }
        private async Task<T> PostResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy,
            HttpContent? content = null)
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

                return await _handler.TryGetResponseAsync(result);
            }
            catch (HttpRequestException ex)
            {
                return _handler.GetExceptionResponse(ex);
            }
        }
        private async Task<T> GetResponseAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
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
                    result = await client.GetAsync(path);
                }

                return await _handler.TryGetResponseAsync(result);
            }
            catch (HttpRequestException ex)
            {
                return _handler.GetExceptionResponse(ex);
            }
        }
        /// <summary>
        /// POST No Body.
        /// </summary>
        /// <param name="url">Base Url.</param>
        /// <param name="path">Path.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="proxy">Proxy settings.</param>
        /// <returns></returns>
        internal async Task<T> PostAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            return await PostResponseAsync(url, path, headers, proxy);
        }
        /// <summary>
        /// POST JSON, accepts custom Content-Type.
        /// </summary>
        /// <param name="url">Base Url.</param>
        /// <param name="path">Path.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="proxy">Proxy settings.</param>
        /// <param name="content">Json String.</param>
        /// <param name="contentType">Custom Content-Type, default: application/json</param>
        /// <returns></returns>
        internal async Task<T> PostAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy, string content, string contentType = null)
        {
            var setContent = new StringContent(content, Encoding.UTF8, contentType ?? Application.Json);
            return await PostResponseAsync(url, path, headers, proxy, setContent);
        }
        /// <summary>
        /// POST Multipart Form.
        /// </summary>
        /// <param name="url">Base Url.</param>
        /// <param name="path">Path.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="proxy">Proxy settings.</param>
        /// <param name="content">File Bytes.</param>
        /// <returns></returns>
        internal async Task<T> PostAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy, byte[] content)
        {
            var setContent = new MultipartFormDataContent();
            var data = new ByteArrayContent(content);
            setContent.Add(data, "xml", "xml");
            return await PostResponseAsync(url, path, headers, proxy, setContent);
        }
        /// <summary>
        /// GET
        /// </summary>
        /// <param name="url">Base Url.</param>
        /// <param name="path">Path.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="proxy">Proxy settings.</param>
        /// <returns></returns>
        internal async Task<T> GetAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            return await GetResponseAsync(url, path, headers, proxy);
        }
    }
}