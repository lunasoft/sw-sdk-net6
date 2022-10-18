using SW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Authentication
{
    public class AuthenticationResponse : Response
    {
        [DataMember]
        public Data data { get; set; }
        public partial class Data
        {
            /// <summary>
            /// Token de autenticación.
            /// </summary>
            [DataMember]
            public string token { get; set; }
            /// <summary>
            /// Vencimiento del token en formato timestamp.
            /// </summary>
            [DataMember]
            public int expires_in { get; set; }
        }
    }
}
