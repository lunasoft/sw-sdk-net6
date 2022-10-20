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
            var json = await BuildHelper.GetCfdi("cfdi40.json");
            var response = await issue.StampV1Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueJsonV1_Auth_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdi("cfdi40.json");
            var response = await issue.StampV1Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueJsonV1_SpecialChar_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdi("cfdi40_special_char.json");
            var response = await issue.StampV1Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        #endregion
        #region V2
        [TestMethod]
        public async Task IssueJsonV2_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdi("cfdi40.json");
            var response = await issue.StampV2Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV2_Auth_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdi("cfdi40.json");
            var response = await issue.StampV2Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV2_SpecialChar_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdi("cfdi40_special_char.json");
            var response = await issue.StampV2Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        #endregion
        #region V3
        [TestMethod]
        public async Task IssueJsonV3_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdi("cfdi40.json");
            var response = await issue.StampV3Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV3_Auth_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdi("cfdi40.json");
            var response = await issue.StampV3Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV3_SpecialChar_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdi("cfdi40_special_char.json");
            var response = await issue.StampV3Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        #endregion
        #region V4
        [TestMethod]
        public async Task IssueJsonV4_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdi("cfdi40.json");
            var response = await issue.StampV4Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.qrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.fechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.noCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.noCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.selloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.selloSAT));
        }
        [TestMethod]
        public async Task IssueJsonV4_Auth_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdi("cfdi40.json");
            var response = await issue.StampV4Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.qrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.fechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.noCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.noCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.selloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.selloSAT));
        }
        [TestMethod]
        public async Task IssueJsonV4_SpecialChar_Success()
        {
            IssueJson issue = new IssueJson(BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdi("cfdi40_special_char.json");
            var response = await issue.StampV4Async(json);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.qrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.fechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.noCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.noCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.selloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.selloSAT));
        }
        #endregion
        #endregion
    }
}
