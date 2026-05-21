namespace SW.Services.Authentication
{
    public class Authentication : AuthenticationService
    {
        /// <summary>
        /// Crear una instancia de la clase Authentication.
        /// </summary>
        /// <param name="url">URL base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Authentication(string url, string user, string password, int proxyPort = 0, string proxy = null) 
            : base(url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio de Autenticación.
        /// </summary>
        /// <returns>AuthenticationResponse</returns>
        public async Task<AuthenticationResponse> GenerateTokenAsync()
        {
            return await GetTokenAsync();
        }
    }
}