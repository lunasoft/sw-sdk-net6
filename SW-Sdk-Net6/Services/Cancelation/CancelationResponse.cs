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
        public CancelationData data { get; set; }
    }
    public partial class CancelationData
    {
        [DataMember]
        public string acuse { get; set; }
        [DataMember]
        public Dictionary<string, string> uuid { get; set; }
    }
}
