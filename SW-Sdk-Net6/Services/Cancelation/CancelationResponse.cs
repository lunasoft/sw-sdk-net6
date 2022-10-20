using SW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Cancelation
{
    public class CancelationResponse : Response
    {
        [DataMember]
        public CancelationData Data { get; set; }
    }
    public partial class CancelationData
    {
        [DataMember]
        public string Acuse { get; set; }
        [DataMember]
        public Dictionary<string, string> Uuid { get; set; }
    }
}
