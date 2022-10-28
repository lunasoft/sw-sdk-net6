using SW.Services.Stamp;
using SW.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Test.Services.StampTest
{
    [TestClass]
    public class IssueV4StorageTest
    {
        [TestMethod]
        public async Task StampV4Storage_V2_CFDI3307_Success()
        {
            var stamp = new StampV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xml, customId);
            xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            Thread.Sleep(1500);
            response = await stamp.StampV2Async(xml, customId);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV4Storage_V2_CFDI3307_Auth_Success()
        {
            var stamp = new StampV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xml, customId);
            xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            Thread.Sleep(1500);
            response = await stamp.StampV2Async(xml, customId);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV4Storage_V2_CFDI3307_Error()
        {
            var stamp = new StampV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xmlA = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var xmlB = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
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
        public async Task StampV4Storage_V2_307_Error()
        {
            var stamp = new StampV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var response = await stamp.StampV2Async(xml, Guid.NewGuid().ToString());
            response = await stamp.StampV2Async(xml, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("307. El comprobante contiene un timbre previo."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV4Storage_V2_CFDI3307_B64_Success()
        {
            var stamp = new StampV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xml, customId, false, true);
            xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            Thread.Sleep(1500);
            response = await stamp.StampV2Async(xml, customId, false, true);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV4Storage_V2_CFDI3307_B64_Auth_Success()
        {
            var stamp = new StampV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(xml, customId, false, true);
            xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            Thread.Sleep(1500);
            response = await stamp.StampV2Async(xml, customId, false, true);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV4Storage_V2_CFDI3307_B64_Error()
        {
            var stamp = new StampV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xmlA = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var xmlB = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
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
        public async Task StampV4Storage_V2_307_B64_Error()
        {
            var stamp = new StampV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
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
