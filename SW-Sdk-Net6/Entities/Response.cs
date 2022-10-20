using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SW.Entities
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string MessageDetail { get; set; }
    }
}
