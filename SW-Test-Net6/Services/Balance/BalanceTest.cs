using SW.Services.Balance;
using SW.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Test.Services.BalanceTest
{
    [TestClass]
    public class BalanceTest
    {
        [TestMethod]
        public async Task GetBalance_Success()
        {
            Balance balance = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await balance.GetBalanceAsync();
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsNotNull(response.Data.TimbresUtilizados);
            Assert.IsNotNull(response.Data.TimbresAsignados);
            Assert.IsNotNull(response.Data.Unlimited);
            Assert.IsTrue(!response.Data.IdClienteUsuario.Equals(Guid.Empty));
            Assert.IsTrue(!response.Data.IdSaldoCliente.Equals(Guid.Empty));
        }
        [TestMethod]
        public async Task GetBalance_Auth_Success()
        {
            Balance balance = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var response = await balance.GetBalanceAsync();
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsNotNull(response.Data.TimbresUtilizados);
            Assert.IsNotNull(response.Data.TimbresAsignados);
            Assert.IsNotNull(response.Data.Unlimited);
            Assert.IsTrue(!response.Data.IdClienteUsuario.Equals(Guid.Empty));
            Assert.IsTrue(!response.Data.IdSaldoCliente.Equals(Guid.Empty));
        }
        [TestMethod]
        public async Task GetBalance_IdUser_Success()
        {
            Balance balance = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await balance.GetBalanceAsync(Guid.Parse("88DD89A2-A491-4919-8CC6-9C1DBD4DFE9B"));
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsNotNull(response.Data.TimbresUtilizados);
            Assert.IsNotNull(response.Data.TimbresAsignados);
            Assert.IsNotNull(response.Data.Unlimited);
            Assert.IsTrue(!response.Data.IdClienteUsuario.Equals(Guid.Empty));
            Assert.IsTrue(!response.Data.IdSaldoCliente.Equals(Guid.Empty));
        }
        [TestMethod]
        public async Task GetBalance_IdUser_Auth_Success()
        {
            Balance balance = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var response = await balance.GetBalanceAsync(Guid.Parse("88DD89A2-A491-4919-8CC6-9C1DBD4DFE9B"));
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsNotNull(response.Data.TimbresUtilizados);
            Assert.IsNotNull(response.Data.TimbresAsignados);
            Assert.IsNotNull(response.Data.Unlimited);
            Assert.IsTrue(!response.Data.IdClienteUsuario.Equals(Guid.Empty));
            Assert.IsTrue(!response.Data.IdSaldoCliente.Equals(Guid.Empty));
        }
        //[TestMethod]
        //public async Task AddStamps_Success()
        //{
        //    Balance balance = new(BuildHelper.UrlApi, BuildHelper.Token);
        //    var response = await balance.AddStampsAsync(Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53"), 1, null);
        //    Assert.IsNotNull(response);
        //    Assert.IsTrue(response.Status.Equals("success"));
        //    Assert.IsNotNull(response.Data);
        //}
        //[TestMethod]
        //public async Task AddStamps_Auth_Success()
        //{
        //    Balance balance = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
        //    var response = await balance.AddStampsAsync(Guid.Parse("f0f11ef6-e4c5-425b-8fc9-b17465bf6f53"), 1, "sw-sdk-net6");
        //    Assert.IsNotNull(response);
        //    Assert.IsTrue(response.Status.Equals("success"));
        //    Assert.IsNotNull(response.Data);
        //}
    }
}
