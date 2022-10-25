using System.Runtime.Serialization;
using SW.Entities;

namespace SW.Services.Stamp
{
    [DataContract]
    public class StampResponseV1 : Response
    {
        [DataMember]
        public DataResponseV1 Data { get; set; }
    }
    [DataContract]
    public class StampResponseV2 : Response
    {
        [DataMember]
        public DataResponseV2 Data { get; set; }
    }
    [DataContract]
    public class StampResponseV3 : Response
    {
        [DataMember]
        public DataResponseV3 Data { get; set; }
    }
    [DataContract]
    public class StampResponseV4 : Response 
    {
        [DataMember]
        public DataResponseV4 Data { get; set; }

    }
    public partial class DataResponseV1
    {
        [DataMember]
        public string Tfd { get; set; }
    }
    public partial class DataResponseV2
    {
        [DataMember]
        public string Tfd { get; set; }
        [DataMember]
        public string Cfdi { get; set; }
    }
    public partial class DataResponseV3
    {
        [DataMember]
        public string Cfdi { get; set; }
    }
    public partial class DataResponseV4
    {
        [DataMember]
        public string CadenaOriginalSAT { get; set; }
        [DataMember]
        public string NoCertificadoSAT { get; set; }
        [DataMember]
        public string NoCertificadoCFDI { get; set; }
        [DataMember]
        public string Uuid { get; set; }
        [DataMember]
        public string SelloSAT { get; set; }
        [DataMember]
        public string SelloCFDI { get; set; }
        [DataMember]
        public string FechaTimbrado { get; set; }
        [DataMember]
        public string QrCode { get; set; }
        [DataMember]
        public string Cfdi { get; set; }
    }
}