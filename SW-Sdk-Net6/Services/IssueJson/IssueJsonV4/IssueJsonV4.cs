using SW.Helpers;
using SW.Services.Stamp;

namespace SW.Services.IssueJson
{
    public class IssueJsonV4 : IssueJsonService
    {
        /// <summary>
        /// Crear una instancia de la clase IssueJsonV4.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueJsonV4(string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base(url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase IssueJsonV4.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueJsonV4(string url, string token, int proxyPort = 0, string proxy = null) 
            : base(url, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato JSON. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <returns><see cref="StampResponseV1"/> Respuesta V1 de timbrado.</returns>
        public async Task<StampResponseV1> StampV1Async(string json, string customId, bool pdf = false)
        {
            return await IssueJsonV1Async(json, StampVersion.V4, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <returns><see cref="StampResponseV1"/> Respuesta V1 de timbrado.</returns>
        public async Task<StampResponseV1> StampV1Async(string json, string customId, string[] email)
        {
            return await IssueJsonV1Async(json, StampVersion.V4, customId, email);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato JSON. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <returns><see cref="StampResponseV2"/> Respuesta V2 de timbrado.</returns>
        public async Task<StampResponseV2> StampV2Async(string json, string customId, bool pdf = false)
        {
            return await IssueJsonV2Async(json, StampVersion.V4, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <returns><see cref="StampResponseV2"/> Respuesta V2 de timbrado.</returns>
        public async Task<StampResponseV2> StampV2Async(string json, string customId, string[] email)
        {
            return await IssueJsonV2Async(json, StampVersion.V4, customId, email);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato JSON. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <returns><see cref="StampResponseV3"/>Respuesta V3 de timbrado.</returns>
        public async Task<StampResponseV3> StampV3Async(string json, string customId, bool pdf = false)
        {
            return await IssueJsonV3Async(json, StampVersion.V4, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <returns><see cref="StampResponseV3"/>Respuesta V3 de timbrado.</returns>
        public async Task<StampResponseV3> StampV3Async(string json, string customId, string[] email)
        {
            return await IssueJsonV3Async(json, StampVersion.V4, customId, email);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato JSON. Recibe un Custom ID y puede realizar el guardado del PDF.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <returns><see cref="StampResponseV4"/>Respuesta V4 de timbrado.</returns>
        public async Task<StampResponseV4> StampV4Async(string json, string customId, bool pdf = false)
        {
            return await IssueJsonV4Async(json, StampVersion.V4, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <returns><see cref="StampResponseV4"/>Respuesta V4 de timbrado.</returns>
        public async Task<StampResponseV4> StampV4Async(string json, string customId, string[] email)
        {
            return await IssueJsonV4Async(json, StampVersion.V4, customId, email);
        }
    }
}
