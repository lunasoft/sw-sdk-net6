using SW.Entities;

namespace SW.Services.Stamp
{
    public class StampResponseV1 : Response
    {
        public DataResponseV1 Data { get; set; }
    }
    public class StampResponseV2 : Response
    {
        public DataResponseV2 Data { get; set; }
    }
    public class StampResponseV3 : Response
    {
        public DataResponseV3 Data { get; set; }
    }
    public class StampResponseV4 : Response 
    {
        public DataResponseV4 Data { get; set; }
    }
    public partial class DataResponseV1
    {
        public string Tfd { get; set; }
    }
    public partial class DataResponseV2
    {
        public string Tfd { get; set; }
        public string Cfdi { get; set; }
    }
    public partial class DataResponseV3
    {
        public string Cfdi { get; set; }
    }
    public partial class DataResponseV4
    {
        public string CadenaOriginalSAT { get; set; }
        public string NoCertificadoSAT { get; set; }
        public string NoCertificadoCFDI { get; set; }
        public string Uuid { get; set; }
        public string SelloSAT { get; set; }
        public string SelloCFDI { get; set; }
        public string FechaTimbrado { get; set; }
        public string QrCode { get; set; }
        public string Cfdi { get; set; }
    }
}