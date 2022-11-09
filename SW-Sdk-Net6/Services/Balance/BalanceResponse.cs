using SW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Balance
{
    [DataContract]
    public class BalanceResponse : Response
    {
        [DataMember]
        public BalanceResponseData Data { get; set; }
    }
    public abstract class BalanceResponseData
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
}
