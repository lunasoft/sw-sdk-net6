using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Balance
{
    [DataContract]
    public class BalanceResponse : Response
    {
        [DataMember]
        public BalanceResponseData Data { get; set; }
    }
    public class BalanceResponseData
    {
        [DataMember]
        public string IdSaldoCliente { get; set; }
        [DataMember]
        public string IdClienteUsuario { get; set; }
        [DataMember]
        public int SaldoTimbres { get; set; }
        [DataMember]
        public int? TimbresUtilizados { get; set; }
        [DataMember]
        public bool? Unlimited { get; set; }
        [DataMember]
        public int? TimbresAsignados { get; set; }
    }
    public class StampBalanceResponse : Response
    {
        [DataMember]
        public string Data { get; set; }
    }
}
