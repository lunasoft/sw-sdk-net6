using SW.Helpers;
using SW.Services.Stamp;
using System.Text;

namespace SW.Services.Issue
{
    public class IssueV4Storage : StampV4StorageService
    {
        /// <summary>
        /// Crear una instancia de la clase IssueV4Storage
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="url">URL base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueV4Storage(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null) : base(urlApi, url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase IssueV4Storage
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="url">URL base.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueV4Storage(string urlApi, string url, string token, int proxyPort = 0, string proxy = null) : base(urlApi, url, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de Timbrado V4 de un CFDI sellado en formato XML. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="xml">String del CFDI sellado en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns>Respuesta V2 de timbrado.</returns>
        public async Task<StampResponseV2> StampV2Async(string xml, string customId, bool pdf = false, bool isB64 = false)
        {
            return await StampStorageServiceV2Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Issue, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Timbrado V4 que recibe un Custom ID y un array de correos para el reenvio del XML y el PDF del CFDI.
        /// </summary>
        /// <param name="xml">String del CFDI sellado en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns>Respuesta V2 de timbrado.</returns>
        public async Task<StampResponseV2> StampV2Async(string xml, string customId, string[] email, bool isB64 = false)
        {
            return await StampStorageServiceV2Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Issue, customId, email);
        }
    }
}