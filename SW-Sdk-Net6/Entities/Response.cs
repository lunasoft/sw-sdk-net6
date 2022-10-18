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
        public string status { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string messageDetail { get; set; }
    }
}
