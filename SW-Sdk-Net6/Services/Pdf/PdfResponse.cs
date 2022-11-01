using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Pdf
{
    [DataContract]
    public class PdfResponse : Response
    {
        [DataMember]
        public PdfDataResponse Data { get; set; }
    }
    public partial class PdfDataResponse
    {
        [DataMember]
        public string ContentB64 { get; set; }
        [DataMember]
        public int ContentSizeBytes { get; set; }
        [DataMember]
        public string Uuid { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public string Folio { get; set; }
        [DataMember]
        public string StampDate { get; set; }
        [DataMember]
        public string IssuedDate { get; set; }
        [DataMember]
        public string RfcIssuer { get; set; }
        [DataMember]
        public string RfcReceptor { get; set; }
        [DataMember]
        public string Total { get; set; }
    }
}