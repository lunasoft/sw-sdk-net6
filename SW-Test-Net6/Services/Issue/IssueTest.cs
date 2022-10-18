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
        [TestMethod]
        public async Task IssueV1_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.TimbrarV1Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_Success()
        {
            var issue = new Issue(SWEnvironment.Api.Test, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.TimbrarV1Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.TimbrarV1Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.TimbrarV1Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV1_B64_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.TimbrarV1Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
        }
        [TestMethod]
        public async Task IssueV2_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.TimbrarV2Async(xml);
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
            var response = await issue.TimbrarV2Async(xml);
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
            var response = await issue.TimbrarV2Async(xml);
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
            var response = await issue.TimbrarV2Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV3_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.TimbrarV3Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV3_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.TimbrarV3Async(xml);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV3_B64_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.TimbrarV3Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV3_B64_Auth_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetXml("cfdi40.xml", true);
            var response = await issue.TimbrarV3Async(xml, true);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.cfdi));
        }
        [TestMethod]
        public async Task IssueV4_Success()
        {
            var issue = new Issue(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetXml("cfdi40.xml");
            var response = await issue.TimbrarV4Async(xml);
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
            var response = await issue.TimbrarV4Async(xml);
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
            var response = await issue.TimbrarV4Async(xml, true);
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
            var response = await issue.TimbrarV4Async(xml, true);
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
    }
}
