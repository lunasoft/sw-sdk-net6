using SW.Entities;
using SW.Helpers;

namespace SW.Services.Pdf
{
    public class Pdf : PdfService
    {
        /// <summary>
        /// Crear una instancia de la clase Pdf.
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="url">URL Base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contrasena.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Pdf(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null)
            : base(urlApi, url, user, password, proxyPort, proxy) { }
        /// <summary>
        /// Crear una instancia de la clase Pdf.
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="token">Token de autenticacion.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Pdf(string urlApi, string token, int proxyPort = 0, string proxy = null)
            : base(urlApi, token, proxyPort, proxy) { }
        /// <summary>
        /// Servicio de generación de PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="template">Identificador del template.</param>
        /// <param name="extras">Agrega datos adicionales en el PDF.</param>
        /// <param name="logo">Logo en B64.</param>
        /// <param name="isB64">Especifica si el string del CFDI se envía en B64.</param>
        /// <returns>PdfResponse</returns>
        public async Task<PdfResponse> GeneratePdfAsync(string xml, PdfTemplate template, Dictionary<string, string> extras = null, string logo = null, bool isB64 = false)
        {
            return await GeneratePdfServiceAsync(xml, template.ToString().ToLower(), extras, logo, isB64);
        }
        /// <summary>
        /// Servicio de generación de PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="template">Identificador del template.</param>
        /// <param name="extras">Agrega datos adicionales en el PDF.</param>
        /// <param name="logo">Logo en B64.</param>
        /// <param name="isB64">Especifica si el string del CFDI se envía en B64.</param>
        /// <returns>PdfResponse</returns>
        public async Task<PdfResponse> GeneratePdfAsync(string xml, string template, Dictionary<string, string> extras = null, string logo = null, bool isB64 = false)
        {
            return await GeneratePdfServiceAsync(xml, template, extras, logo, isB64);
        }
        /// <summary>
        /// Servicio de regeneración de PDF. 
        /// </summary>
        /// <param name="uuid">Folio del comprobante timbrado al cual se le intentará regenerar el PDF.</param>
        /// <returns>Response</returns>
        public async Task<Response> RegeneratePdfAsync(Guid uuid)
        {
            return await RegeneratePdfServiceAsync(uuid);
        }
    }
}