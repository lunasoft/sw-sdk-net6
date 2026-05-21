using SW.Entities;

namespace SW.Services.Authentication
{
    public class AuthenticationResponse : Response
    {
        public AuthData Data { get; set; }
        public class AuthData
        {
            /// <summary>
            /// Token de autenticación.
            /// </summary>
            public string Token { get; set; }
            /// <summary>
            /// Vencimiento del token en formato timestamp.
            /// </summary>
            public long Expires_in { get; set; }
        }
    }
}