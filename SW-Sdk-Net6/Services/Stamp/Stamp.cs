using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    public class Stamp : StampService
    {
        /// <summary>
        /// Crear una instancia de la clase Stamp.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Stamp(string url, string user, string password, int proxyPort = 0, string proxy = null) : base(url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Stamp.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Stamp(string url, string token, int proxyPort = 0, string proxy = null) : base (url, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de Timbrado de un CFDI sellado en formato XML.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isB64">Especifica si el XML esta en formato B64.</param>
        /// <returns>Respuesta V1 de timbrado.</returns>
        public async Task<StampResponseV1> StampV1Async(string xml, bool isB64 = false)
        {
            return await StampV1Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.stamp);
        }
        /// <summary>
        /// Servicio de timbrado de un XML sellado con respuesta v2.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isB64">Especifica si el XML esta en formato B64.</param>
        /// <returns>Respuesta V2 de timbrado.</returns>
        public async Task<StampResponseV2> StampV2Async(string xml, bool isB64 = false)
        {
            return await StampV2Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.stamp);
        }
        /// <summary>
        /// Servicio de timbrado de un XML sellado con respuesta v3.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isB64">Especifica si el XML esta en formato B64.</param>
        /// <returns>Respuesta V3 de timbrado.</returns>
        public async Task<StampResponseV3> StampV3Async(string xml, bool isB64 = false)
        {
            return await StampV3Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.stamp);
        }
        /// <summary>
        /// Servicio de timbrado de un XML sellado con respuesta v4.
        /// </summary>
        /// <param name="xml">String del CFDI en formato XML.</param>
        /// <param name="isB64">Especifica si el XML esta en formato B64.</param>
        /// <returns>Respuesta V4 de timbrado.</returns>
        public async Task<StampResponseV4> StampV4Async(string xml, bool isB64 = false)
        {
            return await StampV4Async(Encoding.UTF8.GetBytes(xml), isB64, StampAction.stamp);
        }
    }
}
