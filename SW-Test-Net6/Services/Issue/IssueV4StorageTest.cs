using SW.Services.Issue;
using SW.Services.Stamp;
using SW.Test.Helpers;

namespace SW.Test.Services.IssueTest
{
    [TestClass]
    public class IssueV4StorageTest
    {
        [TestMethod]
        public async Task IssueV4Storage_V2_CFDI3307_Success()
        {
            var stamp = new IssueV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml");
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xml, customId);
            xml = await BuildHelper.GetCfdi("cfdi40.xml");
            Thread.Sleep(5000);
            response = await stamp.StampV2Async(xml, customId);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueV4Storage_V2_CFDI3307_Auth_Success()
        {
            var stamp = new IssueV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml");
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xml, customId);
            xml = await BuildHelper.GetCfdi("cfdi40.xml");
            Thread.Sleep(5000);
            response = await stamp.StampV2Async(xml, customId);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueV4Storage_V2_CFDI3307_Error()
        {
            var stamp = new IssueV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xmlA = await BuildHelper.GetCfdi("cfdi40.xml");
            var xmlB = await BuildHelper.GetCfdi("cfdi40.xml");
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xmlA, customId);
            response = await stamp.StampV2Async(xmlB, customId);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsTrue(response.MessageDetail.Equals("No se pudo obtener la URL de descarga."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueV4Storage_V2_307_Error()
        {
            var stamp = new IssueV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml");
            var response = await stamp.StampV2Async(xml, Guid.NewGuid().ToString());
            response = await stamp.StampV2Async(xml, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("307. El comprobante contiene un timbre previo."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueV4Storage_V2_CFDI3307_B64_Success()
        {
            var stamp = new IssueV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true);
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xml, customId, false, true);
            xml = await BuildHelper.GetCfdi("cfdi40.xml", true);
            Thread.Sleep(5000);
            response = await stamp.StampV2Async(xml, customId, false, true);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueV4Storage_V2_CFDI3307_B64_Auth_Success()
        {
            var stamp = new IssueV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true);
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xml, customId, false, true);
            xml = await BuildHelper.GetCfdi("cfdi40.xml", true);
            Thread.Sleep(5000);
            response = await stamp.StampV2Async(xml, customId, false, true);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueV4Storage_V2_CFDI3307_B64_Error()
        {
            var stamp = new IssueV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xmlA = await BuildHelper.GetCfdi("cfdi40.xml", true);
            var xmlB = await BuildHelper.GetCfdi("cfdi40.xml", true);
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xmlA, customId, false, true);
            response = await stamp.StampV2Async(xmlB, customId, false, true);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsTrue(response.MessageDetail.Equals("No se pudo obtener la URL de descarga."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueV4Storage_V2_307_B64_Error()
        {
            var stamp = new IssueV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true);
            var response = await stamp.StampV2Async(xml, Guid.NewGuid().ToString(), false, true);
            response = await stamp.StampV2Async(xml, Guid.NewGuid().ToString(), false, true);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("307. El comprobante contiene un timbre previo."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
    }
}
