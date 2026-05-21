using SW.Services.Cancellation;
using System.Text.Json;

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
            return JsonSerializer.Serialize(body);
        }
        /// <summary>
        /// Serialize the pdf request to a JSON string.
        /// </summary>
        internal static string SerializePdf(string xml, string template, Dictionary<string, string> extras, string logo)
        {
            var body = new
            {
                xmlContent = xml,
                templateId = template,
                extras,
                logo
            };
            return JsonSerializer.Serialize(body);
        }
        /// <summary>
        /// Serialize the resend request to a JSON string.
        /// </summary>
        internal static string SerializeResend(Guid uuid, string[] email)
        {
            var body = new
            {
                uuid = uuid.ToString(),
                to = String.Join(',', email).Trim()
            };
            return JsonSerializer.Serialize(body);
        }
    }
}
