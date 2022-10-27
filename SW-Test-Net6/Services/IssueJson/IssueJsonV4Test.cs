using SW.Services.IssueJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Test.Helpers;
using SW.Services.Authentication;
using SW.Services.Issue;

namespace SW.Test.Services.IssueJsonTest
{
    [TestClass]
    public class IssueJsonV4Test
    {
        #region UT Success
        [TestMethod]
        public async Task IssueJsonV4_Success()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await stamp.StampV4Async(json, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
        }
        [TestMethod]
        public async Task IssueJsonV4_Auth_Success()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await stamp.StampV4Async(json, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
        }
        [TestMethod]
        public async Task IssueJsonV4_Pdf_Success()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await stamp.StampV4Async(json, Guid.NewGuid().ToString(), true);
            Assert.IsTrue(response.Status.Equals("success"));
        }
        [TestMethod]
        public async Task IssueJsonV4_Email_Success()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await stamp.StampV4Async(json, Guid.NewGuid().ToString(), new string[] { "mail@email.com" });
            Assert.IsTrue(response.Status.Equals("success"));
        }
        #endregion
        #region UT Error
        [TestMethod]
        public async Task IssueJsonV4_Error()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, "Token");
            var response = await stamp.StampV4Async(String.Empty, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("401"));
            Assert.IsTrue(response.MessageDetail.Equals("Unauthorized"));
        }
        [TestMethod]
        public async Task IssueJsonV4_Auth_Error()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.User, "Password");
            var response = await stamp.StampV4Async(String.Empty, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("401"));
            Assert.IsTrue(response.MessageDetail.Equals("Unauthorized"));
        }
        [TestMethod]
        public async Task IssueJsonV4_WrongUrl_Error()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await stamp.StampV4Async(String.Empty, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("404"));
            Assert.IsTrue(response.MessageDetail.Equals("Not Found"));
        }
        [TestMethod]
        public async Task IssueJsonV4_WrongUrl_Auth_Error()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlApi, BuildHelper.User, BuildHelper.Password);
            var response = await stamp.StampV4Async(String.Empty, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("404"));
            Assert.IsTrue(response.MessageDetail.Equals("Not Found"));
        }
        [TestMethod]
        public async Task IssueJsonV4_InvalidUrl_Error()
        {
            var stamp = new IssueJsonV4(null, BuildHelper.Token);
            var response = await stamp.StampV4Async(String.Empty, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task IssueJsonV4_InvalidUrl_Auth_Error()
        {
            var stamp = new IssueJsonV4("This is an url.", BuildHelper.User, BuildHelper.Password);
            var response = await stamp.StampV4Async(String.Empty, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task IssueJsonV4_InvalidJson_Error()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.Token);
            var response = await stamp.StampV4Async("My JSON", Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
        }
        [TestMethod]
        public async Task IssueJsonV4_InvalidCustomId_Error()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await stamp.StampV4Async(json, String.Empty);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(response.Message.Equals("El CustomId no es válido o no se especificó."));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task IssueJsonV4_InvalidEmail_Error()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await stamp.StampV4Async(json, Guid.NewGuid().ToString(), new string[] { "mi.correo" });
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(response.Message.Equals("El listado de correos no tiene un formato válido o está vacío."));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task IssueJsonV4_InvalidEmailCount_Error()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await stamp.StampV4Async(json, Guid.NewGuid().ToString(), new string[] { "1@mail.com", "2@mail.com", "3@mail.com",
                                                                                                    "4@mail.com", "5@mail.com", "6@mail.com" });
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(response.Message.Equals("El header email contiene más de 5 correos."));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task IssueJsonV4_CFDI3307_Error()
        {
            var stamp = new IssueJsonV4(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV4Async(json, customId);
            json = await BuildHelper.GetCfdiJson("cfdi40.json");
            Thread.Sleep(1500);
            response = await stamp.StampV4Async(json, customId);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Contains("CFDI3307"));
        }
        #endregion
    }
}
