using SW.Helpers;
using SW.Services.Stamp;
using System.Text;

namespace SW.Services.Issue
{
    public class IssueV4 : StampService
    {
        /// <summary>
        /// Crear una instancia de la clase IssueV4.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueV4(string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base (url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase IssueV4.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueV4(string url, string token, int proxyPort = 0, string proxy = null) 
            : base(url, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de Emisión Timbrado V4 de un CFDI en formato XML. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="isB64">Especifica si el XML se envia en formato B64.</param>
        /// <returns><see cref="StampResponseV1"/> Respuesta V1 de timbrado.</returns>
        public async Task<StampResponseV1> StampV1Async(string xml, string customId, bool pdf = false, bool isB64 = false)
        {
            return await StampServiceV1Async(Encoding.UTF8.GetBytes(xml), StampAction.Issue, StampVersion.V4, isB64, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado V4 de un CFDI en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns><see cref="StampResponseV1"/> Respuesta V1 de timbrado.</returns>
        public async Task<StampResponseV1> StampV1Async(string xml, string customId, string[] email, bool isB64 = false)
        {
            return await StampServiceV1Async(Encoding.UTF8.GetBytes(xml), StampAction.Issue, StampVersion.V4, isB64, customId, email);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado V4 de un CFDI en formato XML. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns><see cref="StampResponseV2"/> Respuesta V2 de timbrado.</returns>
        public async Task<StampResponseV2> StampV2Async(string xml, string customId, bool pdf = false, bool isB64 = false)
        {
            return await StampServiceV2Async(Encoding.UTF8.GetBytes(xml), StampAction.Issue, StampVersion.V4, isB64, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado V4 de un CFDI en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns><see cref="StampResponseV2"/> Respuesta V2 de timbrado.</returns>
        public async Task<StampResponseV2> StampV2Async(string xml, string customId, string[] email, bool isB64 = false)
        {
            return await StampServiceV2Async(Encoding.UTF8.GetBytes(xml), StampAction.Issue, StampVersion.V4, isB64, customId, email);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado V4 de un CFDI en formato XML. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns><see cref="StampResponseV3"/> Respuesta V3 de timbrado.</returns>
        public async Task<StampResponseV3> StampV3Async(string xml, string customId, bool pdf = false, bool isB64 = false)
        {
            return await StampServiceV3Async(Encoding.UTF8.GetBytes(xml), StampAction.Issue, StampVersion.V4, isB64, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado V4 de un CFDI en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns><see cref="StampResponseV3"/> Respuesta V3 de timbrado.</returns>
        public async Task<StampResponseV3> StampV3Async(string xml, string customId, string[] email, bool isB64 = false)
        {
            return await StampServiceV3Async(Encoding.UTF8.GetBytes(xml), StampAction.Issue, StampVersion.V4, isB64, customId, email);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado V4 de un CFDI en formato XML. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns><see cref="StampResponseV4"/> Respuesta V4 de timbrado.</returns>
        public async Task<StampResponseV4> StampV4Async(string xml, string customId, bool pdf = false, bool isB64 = false)
        {
            return await StampServiceV4Async(Encoding.UTF8.GetBytes(xml), StampAction.Issue, StampVersion.V4, isB64, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado V4 de un CFDI en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns><see cref="StampResponseV4"/>Respuesta V4 de timbrado.</returns>
        public async Task<StampResponseV4> StampV4Async(string xml, string customId, string[] email, bool isB64 = false)
        {
            return await StampServiceV4Async(Encoding.UTF8.GetBytes(xml), StampAction.Issue, StampVersion.V4, isB64, customId, email);
        }
    }
}
