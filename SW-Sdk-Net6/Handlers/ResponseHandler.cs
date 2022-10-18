using SW.Entities;
using SW.Helpers;
using SW.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SW.Handlers
{
    internal class ResponseHandler<T> where T : Response, new() 
    {
        private ResponseHandlerExtended<T> handler;
        internal ResponseHandler()
        {
            handler = new ResponseHandlerExtended<T>();
        }
        internal async Task<T> PostAsync(string url, string path, Dictionary<string, string> headers, HttpClientHandler proxy)
        {
            return await handler.PostResponseAsync(url, path, headers, null, proxy);
        }
        internal async Task<T> PostAsync(string url, string path, Dictionary<string, string> headers, HttpContent content, HttpClientHandler proxy)
        {
            return await handler.PostResponseAsync(url, path, headers, content, proxy);
        }
    }
}
