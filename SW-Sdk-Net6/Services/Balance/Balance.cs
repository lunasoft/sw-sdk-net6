using SW.Entities;
using SW.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Balance
{
    public class Balance : BalanceService
    {
        /// <summary>
        /// Crear una instancia de la clase Balance.
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="url">URL Base.</param>
        /// <param name="user">Usuario.</param>
        /// <param name="password">Contrasena.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Balance(string urlApi, string url, string user, string password, int proxyPort, string proxy) : base(urlApi, url, user, password, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Crear una instancia de la clase Balance.
        /// </summary>
        /// <param name="urlApi">URL Api.</param>
        /// <param name="token">Token de autenticacion.</param>
        /// <param name="proxyPort">Puerto Proxy.</param>
        /// <param name="proxy">Proxy.</param>
        public Balance(string urlApi, string token, int proxyPort, string proxy) : base(urlApi, token, proxyPort, proxy)
        {
        }
        /// <summary>
        /// Servicio que obtiene la información del saldo de una cuenta. La cuenta se identifica mediante el token.
        /// </summary>
        /// <returns>BalanceResponse</returns>
        public async Task<BalanceResponse> GetBalanceAsync() => await BalanceAsync(null);
        /// <summary>
        /// Servicio que obtiene la información del saldo de una cuenta. La cuenta se identifica por el IdUser.
        /// </summary>
        /// <param name="idUser">IdUser de la cuenta.</param>
        /// <returns>BalanceResponse</returns>
        public async Task<BalanceResponse> GetBalanceAsync(Guid idUser) => await BalanceAsync(idUser);
        /// <summary>
        /// Servicio para agregar timbres a una cuenta hijo.
        /// </summary>
        /// <param name="idUser">IdUser de la cuenta.</param>
        /// <param name="stamps">Espcifica la cantidad de timbres a agregar, debe ser mayor que 0.</param>
        /// <returns>Response</returns>
        public async Task<StampBalanceResponse> AddStampsAsync(Guid idUser, int stamps, string comment) => await StampBalanceAsync(idUser, BalanceAction.Add, stamps, comment);
        /// <summary>
        /// Servicio para remover timbres a una cuenta hijo.
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="stamps">Espcifica la cantidad de timbres a remover, debe ser mayor que 0.</param>
        /// <returns>Response</returns>
        public async Task<StampBalanceResponse> RemoveStampsAsync(Guid idUser, int stamps, string comment) => await StampBalanceAsync(idUser, BalanceAction.Remove, stamps, comment);
    }
}
