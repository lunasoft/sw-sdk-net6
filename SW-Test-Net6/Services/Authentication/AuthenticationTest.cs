using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Services.Authentication;
using SW.Test.Helpers;

namespace SW.Test.Services.AuthenticationTest
{
    [TestClass]
    public class AuthenticationTest
    {
        #region UT Success
        [TestMethod]
        public async Task Authenticate_Success()
        {
            Authentication auth = new Authentication("https://services.test.sw.com.mx", BuildHelper.User, BuildHelper.Password);
            var response = await auth.ObtenerTokenAsync();
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.token));
            Assert.IsTrue(response.data.expires_in > 0);
        }
        #endregion
        #region UT Error
        [TestMethod]
        public async Task Authenticate_WrongCredentials_Error()
        {
            Authentication auth = new Authentication("https://services.test.sw.com.mx", BuildHelper.User, "12345");
            var response = await auth.ObtenerTokenAsync();
            Assert.IsTrue(response.status.Equals("error"));
            Assert.IsTrue(response.message.Equals("AU2000 - El usuario y/o contraseña son inválidos, no se puede autenticar el servicio."));
        }
        [TestMethod]
        public async Task Authenticate_InvalidUrl_Error()
        {
            Authentication auth = new Authentication(null, BuildHelper.User, BuildHelper.Password);
            var response = await auth.ObtenerTokenAsync();
            Assert.IsTrue(response.status.Equals("error"));
            Assert.IsNotNull(response.message);
            Assert.IsNotNull(response.messageDetail);
        }
        [TestMethod]
        public async Task Authenticate_WrongUrl_Error()
        {
            Authentication auth = new Authentication("https://test.sw.com.mx", BuildHelper.User, BuildHelper.Password);
            var response = await auth.ObtenerTokenAsync();
            Assert.IsTrue(response.status.Equals("error"));
            Assert.IsNotNull(response.message);
            Assert.IsNotNull(response.messageDetail);
        }
        #endregion
    }
}
