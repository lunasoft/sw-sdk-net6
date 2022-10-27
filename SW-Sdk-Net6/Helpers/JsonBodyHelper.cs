using Newtonsoft.Json;
using SW.Services.Cancellation;

namespace SW.Helpers
{
    internal class JsonBodyHelper
    {
        /// <summary>
        /// Serialize the cancellation request to a JSON string.
        /// </summary>
        internal static string SerializeCancellation(CancellationRequest request, string password, byte[] cer, byte[] key, byte[] pfx)
        {
            var body = new
            {
                request.Rfc,
                request.Uuid,
                request.Motivo,
                request.FolioSustitucion,
                b64Cer = Convert.ToBase64String(cer ?? Array.Empty<byte>()),
                b64Key = Convert.ToBase64String(key ?? Array.Empty<byte>()),
                b64Pfx = Convert.ToBase64String(pfx ?? Array.Empty<byte>()),
                password,
            };
            return JsonConvert.SerializeObject(body);
        }
    }
}
