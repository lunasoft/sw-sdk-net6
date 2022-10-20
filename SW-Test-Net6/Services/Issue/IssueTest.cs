using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW.Helpers;
using SW.Services.Issue;
using SW.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Test.Services.IssueTest
{
    [TestClass]
    public class IssueTest
    {
        #region UT Success
        #region V1
        [TestMethod]
        public async Task IssueV1_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV1Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV1Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.StampV1Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_B64_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.StampV1Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_BigXml_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_big.xml");
            var response = await issue.StampV1Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_SpecialChar_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_special_char.xml");
            var response = await issue.StampV1Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_SpecialChar_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_special_char.xml", true);
            var response = await issue.StampV1Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        #endregion
        #region V2
        [TestMethod]
        public async Task IssueV2_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV2Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV2_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV2Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV2_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV2Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV2_B64_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.StampV2Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [Ignore("Se ejecuta según sea requerido.")]
        [TestMethod]
        public async Task IssueV2_BigXml_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_big.xml");
            var response = await issue.StampV2Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV2_SpecialChar_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_special_char.xml");
            var response = await issue.StampV2Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV2_SpecialChar_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_special_char.xml", true);
            var response = await issue.StampV2Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        #endregion
        #region V3
        [TestMethod]
        public async Task IssueV3_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV3Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV3_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV3Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV3_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.StampV3Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV3_B64_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.StampV3Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [Ignore("Se ejecuta según sea requerido.")]
        [TestMethod]
        public async Task IssueV3_BigXml_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV3Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV3_SpecialChar_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_special_char.xml");
            var response = await issue.StampV3Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV3_SpecialChar_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_special_char.xml", true);
            var response = await issue.StampV3Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        #endregion
        #region V4
        [TestMethod]
        public async Task IssueV4_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV4Async(xml);
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
        public async Task IssueV4_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV4Async(xml);
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
        public async Task IssueV4_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.StampV4Async(xml, true);
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
        public async Task IssueV4_B64_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.StampV4Async(xml, true);
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
        [Ignore("Se ejecuta según sea requerido.")]
        [TestMethod]
        public async Task IssueV4_BigXml_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.StampV4Async(xml);
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
        public async Task IssueV4_SpecialChar_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_special_char.xml");
            var response = await issue.StampV4Async(xml);
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
        public async Task IssueV4_SpecialChar_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40_special_char.xml", true);
            var response = await issue.StampV4Async(xml, true);
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
