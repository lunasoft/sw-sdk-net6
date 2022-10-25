using SW.Services.IssueJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Test.Helpers;
using SW.Services.Authentication;

namespace SW.Test.Services.IssueTest
{
    [TestClass]
    public class IssueJsonTest
    {
        #region UT Success
        #region V1
        [TestMethod]
        public async Task IssueJsonV1_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await issue.StampV1Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        [TestMethod]
        public async Task IssueJsonV1_Auth_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await issue.StampV1Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        [TestMethod]
        public async Task IssueJsonV1_SpecialChar_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40_special_char.json");
            var response = await issue.StampV1Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        #endregion
        #region V2
        [TestMethod]
        public async Task IssueJsonV2_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await issue.StampV2Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV2_Auth_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await issue.StampV2Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV2_SpecialChar_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40_special_char.json");
            var response = await issue.StampV2Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        #endregion
        #region V3
        [TestMethod]
        public async Task IssueJsonV3_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await issue.StampV3Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV3_Auth_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await issue.StampV3Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV3_SpecialChar_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40_special_char.json");
            var response = await issue.StampV3Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        #endregion
        #region V4
        [TestMethod]
        public async Task IssueJsonV4_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await issue.StampV4Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
        [TestMethod]
        public async Task IssueJsonV4_Auth_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await issue.StampV4Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
        [TestMethod]
        public async Task IssueJsonV4_SpecialChar_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40_special_char.json");
            var response = await issue.StampV4Async(json);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
        #endregion
        #endregion
    }
}
