using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Pdf
{
    [DataContract]
    public class PdfResponse : Response
    {
        public PdfDataResponse Data { get; set; }
    }
    public partial class PdfDataResponse
    {
        public string ContentB64 { get; set; }
        public int ContentSizeBytes { get; set; }
        public string Uuid { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string StampDate { get; set; }
        public string IssuedDate { get; set; }
        public string RfcIssuer { get; set; }
        public string RfcReceptor { get; set; }
        public string Total { get; set; }
    }
}