using SW.Entities;

namespace SW.Services.Storage
{
    public class StorageResponse : Response
    {
        public StorageData Data { get; set; }
    }
    public partial class StorageData
    {
        public StorageRecords[] Records { get; set; }
    }
    public partial class StorageRecords
    {
        public string UrlXml { get; set; }
        public string UrlPdf { get; set; }
        public string UrlAckCfdi { get; set; }
        public string UrlAckCancellation { get; set; }
        public string UrlAddenda { get; set; }
    }
    public class StorageExtraResponse : Response
    {
        public StorageExtraData Data { get; set; }
    }
    public class StorageExtraData
    {
        public StorageExtraRecords[] Records { get; set; }
    }
    public partial class StorageExtraRecords : StorageRecords
    {
        public string FechaGeneracionPdf { get; set; }
        public string IdDealer { get; set; }
        public string IdUser { get; set; }
        public string Version { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string Fecha { get; set; }
        public string NumeroCertificado { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public string Moneda { get; set; }
        public decimal TipoCambio { get; set; }
        public string TipoDeComprobante { get; set; }
        public string MetodoPago { get; set; }
        public string FormaPago { get; set; }
        public string CondicionesPago { get; set; }
        public string LuegarExpedicion { get; set; }
        public string EmisorRfc { get; set; }
        public string EmisorNombre { get; set; }
        public string RegimenFiscal { get; set; }
        public string ReceptorRfc { get; set; }
        public string ReceptorNombre { get; set; }
        public string ResidenciaFiscal { get; set; }
        public string NumRegIdTrib { get; set; }
        public string usoCFDI { get; set; }
        public decimal TotalImpuestosTraslados { get; set; }
        public decimal TotalImpuestosRetencion { get; set; }
        public decimal TrasladosIVA { get; set; }
        public decimal TrasladosIEPS { get; set; }
        public decimal RetencionesISR { get; set; }
        public decimal RetencionesIVA { get; set; }
        public decimal RetencionesIEPS { get; set; }
        public decimal TotalImpuestosLocalesTraslados { get; set; }
        public decimal TotalImpuestosLocalesRetencion { get; set; }
        public string Complementos { get; set; }
        public string Uuid { get; set; }
        public string FechaTimbrado { get; set; }
        public string RfcProvCertif { get; set; }
        public string selloCFD { get; set; }
    }
}