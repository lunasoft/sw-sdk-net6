using SW.Entities;

namespace SW.Services.Resend
{
    public class Resend : ResendService
    {
        /// <summary>
        /// Crear una instancia de la clase Resend.
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="url">URL Base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contrasena.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Resend(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base(urlApi, url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Resend.
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="token">Token de autenticacion.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Resend(string urlApi, string token, int proxyPort = 0, string proxy = null) 
            : base(urlApi, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio para realizar el reenvío del XML y/o PDF a los correos especificados. El PDF se envia si fue generado en el proceso de timbrado.
        /// </summary>
        /// <param name="uuid">Folio del comprobante timbrado.</param>
        /// <param name="email">Listado de correos a los que se har el reenvío. (Max. 5).</param>
        /// <returns><see cref="Response"/></returns>
        public async Task<Response> ResendEmail(Guid uuid, string[] email)
        {
            return await ResendEmailServiceAsync(uuid, email);
        }
    }
}