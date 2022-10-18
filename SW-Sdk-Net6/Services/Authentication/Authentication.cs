using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Authentication
{
    public class Authentication : AuthenticationService
    {
        /// <summary>
        /// Crear una instancia de la clase Authentication.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="proxyPort"></param>
        /// <param name="proxy"></param>
        public Authentication(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio para obtener el token de autenticación.
        /// </summary>
        /// <returns></returns>
        public async Task<AuthenticationResponse> ObtenerTokenAsync()
        {
            return await GetToken();
        }
    }
}
