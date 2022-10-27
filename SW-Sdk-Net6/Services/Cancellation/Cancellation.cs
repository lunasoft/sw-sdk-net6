using System.Text;

namespace SW.Services.Cancellation
{
    public class Cancellation : CancellationService
    {
        /// <summary>
        /// Crear una instancia de la clase Cancellation.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Cancellation(string url, string user, string password, int proxyPort = 0, string? proxy = null) : base(url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Cancellation.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="token">Token de autenticación.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Cancellation(string url, string token, int proxyPort = 0, string? proxy = null) : base(url, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de cancelación por UUID.
        /// </summary>
        /// <param name="folio">UUID del comprobante.</param>
        /// <returns></returns>
        public async Task<CancellationResponse> CancelByUuidAsync(CancellationRequest folio)
        {
            return await CancellationAsync(folio);
        }
        /// <summary>
        /// Servicio de cancelación por CSD.
        /// </summary>
        /// <param name="folio">UUID del comprobante.</param>
        /// <param name="cer">Certificado CSD del emisor.</param>
        /// <param name="key">Certificado Key del emisor.</param>
        /// <param name="password">Contraseña del certificado.</param>
        /// <returns></returns>
        public async Task<CancellationResponse> CancelByCsdAsync(CancellationRequest folio, byte[] cer, byte[] key, string password)
        {
            return await CancellationAsync(folio, cer, key, password);
        }
        /// <summary>
        /// Servicio de cancelación por PFX.
        /// </summary>
        /// <param name="folio">UUID del comprobante.</param>
        /// <param name="pfx">Certificado PFX.</param>
        /// <param name="password">Contraseña del certificado.</param>
        /// <returns></returns>
        public async Task<CancellationResponse> CancelByPfxAsync(CancellationRequest folio, byte[] pfx, string password)
        {
            return await CancellationAsync(folio, pfx, password);
        }
        /// <summary>
        /// Servicio de cancelación por XML.
        /// </summary>
        /// <param name="xml">String del XML firmado de cancelación.</param>
        /// <returns></returns>
        public async Task<CancellationResponse> CancelByXmlAsync(string xml)
        {
            return await CancellationAsync(Encoding.UTF8.GetBytes(xml));
        }
    }
}