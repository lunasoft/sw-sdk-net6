using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SW.Entities;

namespace SW.Services.Stamp
{
    [DataContract]
    public class StampResponseV1 : Response
    {
        [DataMember]
        public DataResponseV1 data { get; set; }
    }
    [DataContract]
    public class StampResponseV2 : Response
    {
        [DataMember]
        public DataResponseV2 data { get; set; }
    }
    [DataContract]
    public class StampResponseV3 : Response
    {
        [DataMember]
        public DataResponseV3 data { get; set; }
    }
    [DataContract]
    public class StampResponseV4 : Response 
    {
        [DataMember]
        public DataResponseV4 data { get; set; }

    }
    public partial class DataResponseV1
    {
        [DataMember]
        public string tfd { get; set; }
    }
    public partial class DataResponseV2
    {
        [DataMember]
        public string tfd { get; set; }
        [DataMember]
        public string cfdi { get; set; }
    }
    public partial class DataResponseV3
    {
        [DataMember]
        public string cfdi { get; set; }
    }
    public partial class DataResponseV4
    {
        [DataMember]
        public string cadenaOriginalSAT { get; set; }
        [DataMember]
        public string noCertificadoSAT { get; set; }
        [DataMember]
        public string noCertificadoCFDI { get; set; }
        [DataMember]
        public string uuid { get; set; }
        [DataMember]
        public string selloSAT { get; set; }
        [DataMember]
        public string selloCFDI { get; set; }
        [DataMember]
        public string fechaTimbrado { get; set; }
        [DataMember]
        public string qrCode { get; set; }
        [DataMember]
        public string cfdi { get; set; }
    }
}
