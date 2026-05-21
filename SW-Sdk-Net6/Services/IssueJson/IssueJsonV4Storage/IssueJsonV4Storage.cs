using SW.Services.Stamp;

namespace SW.Services.IssueJson
{
    public class IssueJsonV4Storage : IssueJsonV4StorageService
    {
        /// <summary>
        /// Crear una instancia de la clase IssueJsonV4Storage
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="url">URL base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueJsonV4Storage(string urlApi, string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base(urlApi, url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase IssueJsonV4Storage
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="url">URL base.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public IssueJsonV4Storage(string urlApi, string url, string token, int proxyPort = 0, string proxy = null) 
            : base(urlApi, url, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato JSON. Recibe un Custom ID y puede realizar el guardado del PDF. Obtiene los datos faltantes
        /// de la versión del Response cuando se obtiene un error por Custom ID duplicado.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="pdf">Especifica si se genera el PDF en el proceso, si es true, se almacena en storage.</param>
        /// <returns><see cref="StampResponseV2"/> Respuesta V2 de timbrado.</returns>
        public async Task<StampResponseV2> StampV2Async(string json, string customId, bool pdf = false)
        {
            return await IssueJsonStorageServiceV2Async(json, customId, null, pdf);
        }
        /// <summary>
        /// Servicio de Emisión Timbrado JSON V4 de un CFDI en formato XML. Recibe un Custom ID y un array de correos para el reenvio del XML y el PDF. Obtiene los datos faltantes
        /// de la versión del Response cuando se obtiene un error por Custom ID duplicado.
        /// </summary>
        /// <param name="json">String del CFDI en formato JSON.</param>
        /// <param name="customId">Identificador unico asignado al comprobante.</param>
        /// <param name="email">Listado de correos, máximo 5, a los cuales se les hara el envío del XML y PDF.</param>
        /// <returns><see cref="StampResponseV2"/> Respuesta V2 de timbrado.</returns>
        public async Task<StampResponseV2> StampV2Async(string json, string customId, string[] email)
        {
            return await IssueJsonStorageServiceV2Async(json, customId, email);
        }
    }
}
