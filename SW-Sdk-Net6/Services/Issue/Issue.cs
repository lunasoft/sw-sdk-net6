using SW.Helpers;
using SW.Services.Stamp;
using System.Text;

namespace SW.Services.Issue
{
    public class Issue : StampService
    {
        /// <summary>
        /// Crear una instancia de la clase Issue.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Issue(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Issue.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Issue(string url, string token, int proxyPort = 0, string proxy = null) : base(url, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de Emision Timbrado de un CFDI en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isB64">Especifica si el XML esta en formato B64.</param>
        /// <returns>Respuesta V1 de timbrado.</returns>    
        public async Task<StampResponseV1> StampV1Async(string xml, bool isB64 = false)
        {
            return await StampV1Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Issue);
        }
        /// <summary>
        /// Servicio de Emision Timbrado de un CFDI en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isB64">Especifica si el XML esta en formato B64.</param>
        /// <returns>Respuesta V2 de timbrado.</returns> 
        public async Task<StampResponseV2> StampV2Async(string xml, bool isB64 = false)
        {
            return await StampV2Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Issue);
        }
        /// <summary>
        /// Servicio de Emision Timbrado de un CFDI en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isB64">Especifica si el XML esta en formato B64.</param>
        /// <returns>Respuesta V3 de timbrado.</returns> 
        public async Task<StampResponseV3> StampV3Async(string xml, bool isB64 = false)
        {
            return await StampV3Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Issue);
        }
        /// <summary>
        /// Servicio de Emision Timbrado de un CFDI en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isB64">Especifica si el XML esta en formato B64.</param>
        /// <returns>Respuesta V4s de timbrado.</returns> 
        public async Task<StampResponseV4> StampV4Async(string xml, bool isB64 = false)
        {
            return await StampV4Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.Issue);
        }
    }
}