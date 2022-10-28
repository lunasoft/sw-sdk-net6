using SW.Handlers;
using SW.Services.Stamp;
using SW.Services.Storage;
using System.Text;
using System.Xml;

namespace SW.Helpers
{
    internal class ConvertionHelper
    {
        internal static bool TryGetUuid(string tfd, out Guid uuid, bool isB64 = false)
        {
            try
            {
                tfd = !isB64 ? tfd : Encoding.UTF8.GetString(Convert.FromBase64String(tfd));
                XmlDocument doc = new();
                doc.LoadXml(tfd);
                var getUuid = doc.LastChild.Attributes.GetNamedItem("UUID")?.Value;
                return Guid.TryParse(getUuid, out uuid);
            }
            catch
            {
                uuid = Guid.Empty;
                return false;
            }
        }
        internal static async Task<StampResponseV2> ToStampResponseV2(StampResponseV2 stamp, StorageResponse storage, HttpClientHandler proxy, bool isB64 = false)
        {
            DownloadHandler<StampResponseV2> _handler = new();
            if (storage.Status.Equals("success") && storage.Data.Records.Length > 0)
            {
                var cfdi = await _handler.DownloadFileAsync(storage.Data.Records.FirstOrDefault().UrlXml, proxy);
                if (cfdi.Status.Equals("success"))
                {
                    stamp.Data.Cfdi = !isB64 ? cfdi.Message : Convert.ToBase64String(Encoding.UTF8.GetBytes(cfdi.Message));
                    return stamp;
                }
                stamp.MessageDetail = cfdi.Message;
                return stamp;
            }
            stamp.MessageDetail = String.Format("No se pudo obtener la URL de descarga.");
            return stamp;
        }
    }
}
