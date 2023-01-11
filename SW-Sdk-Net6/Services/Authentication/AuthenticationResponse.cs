using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Authentication
{
    public class AuthenticationResponse : Response
    {
        [DataMember]
        public AuthData Data { get; set; }
        public class AuthData
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