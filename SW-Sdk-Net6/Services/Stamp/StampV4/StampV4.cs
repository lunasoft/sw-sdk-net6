using SW.Helpers;
using System.Text;

namespace SW.Services.Stamp
{
    public class StampV4 : StampService
    {
        /// <summary>
        /// Crear una instancia de la clase StampV4.
        /// </summary>
        /// <param name="url">URL Base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contrasena.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public StampV4(string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base(url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase StampV4.
        /// </summary>
        /// <param name="url">URL Base.</param>
        /// <param name="token">Token de autenticacion.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public StampV4(string url, string token, int proxyPort = 0, string proxy = null) 
            : base(url, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de Timbrado V4 de un CFDI sellado en formato XML. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="xml">String del CFDI sellado en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns>Respuesta V1 de timbrado.</returns>
        public async Task<StampResponseV1> StampV1Async(string xml, string customId, bool pdf = false, bool isB64 = false)
        {
            return await StampServiceV1Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Stamp, StampVersion.V4, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Timbrado V4 de un CFDI sellado en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF.
        /// </summary>
        /// <param name="xml">String del CFDI sellado en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns>Respuesta V1 de timbrado.</returns>
        public async Task<StampResponseV1> StampV1Async(string xml, string customId, string[] email, bool isB64 = false)
        {
            return await StampServiceV1Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Stamp, StampVersion.V4, customId, email);
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
            return await StampServiceV2Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Stamp, StampVersion.V4, customId, null, pdf);
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
            return await StampServiceV2Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Stamp, StampVersion.V4, customId, email);
        }
        /// <summary>
        /// Servicio de Timbrado V4 de un CFDI sellado en formato XML. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="xml">String del CFDI sellado en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns>Respuesta V3 de timbrado.</returns>
        public async Task<StampResponseV3> StampV3Async(string xml, string customId, bool pdf = false, bool isB64 = false)
        {
            return await StampServiceV3Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Stamp, StampVersion.V4, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Timbrado V4 que recibe un Custom ID y un array de correos para el reenvio del XML y el PDF del CFDI.
        /// </summary>
        /// <param name="xml">String del CFDI sellado en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns>Respuesta V3 de timbrado.</returns>
        public async Task<StampResponseV3> StampV3Async(string xml, string customId, string[] email, bool isB64 = false)
        {
            return await StampServiceV3Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Stamp, StampVersion.V4, customId, email);
        }
        /// <summary>
        /// Servicio de Timbrado V4 de un CFDI sellado en formato XML. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="xml">String del CFDI sellado en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns>Respuesta V4 de timbrado.</returns>
        public async Task<StampResponseV4> StampV4Async(string xml, string customId, bool pdf = false, bool isB64 = false)
        {
            return await StampServiceV4Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Stamp, StampVersion.V4, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Timbrado V4 que recibe un Custom ID y un array de correos para el reenvio del XML y el PDF del CFDI.
        /// </summary>
        /// <param name="xml">String del CFDI sellado en formato XML.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <param name="isB64">Especifica si el XML se envía en formato B64.</param>
        /// <returns>Respuesta V4 de timbrado.</returns>
        public async Task<StampResponseV4> StampV4Async(string xml, string customId, string[] email, bool isB64 = false)
        {
            return await StampServiceV4Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Stamp, StampVersion.V4, customId, email);
        }
    }
}