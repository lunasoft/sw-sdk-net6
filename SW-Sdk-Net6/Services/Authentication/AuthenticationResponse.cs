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
        public AuthData Data { get; set; }
        public partial class AuthData
        {
            /// <summary>
            /// Token de autenticación.
            /// </summary>
            [DataMember]
            public string Token { get; set; }
            /// <summary>
            /// Vencimiento del token en formato timestamp.
            /// </summary>
            [DataMember]
            public long Expires_in { get; set; }
        }
    }
}
