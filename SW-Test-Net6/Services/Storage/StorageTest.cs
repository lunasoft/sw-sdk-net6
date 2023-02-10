using SW.Services.Storage;
using SW.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Test.Services.StorageTest
{
    [TestClass]
    public class StorageTest
    {
        [TestMethod]
        public async Task Storage_Success()
        {
            Storage storage = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlXml));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlPdf));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCancellation));
        }
        [TestMethod]
        public async Task Storage_Auth_Success()
        {
            Storage storage = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var response = await storage.GetXmlAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.IsTrue(response.Status.Equals("success"), TestHelper.TestLog(response.Status, response.Message, response.MessageDetail));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlXml));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlPdf));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCancellation));
        }
        [TestMethod]
        public async Task StorageExtras_Success()
        {
            Storage storage = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlXml));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlPdf));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCancellation));
        }
        [TestMethod]
        public async Task StorageExtras_Auth_Success()
        {
            Storage storage = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlXml));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlPdf));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Records[0].UrlAckCancellation));
        }
        [TestMethod]
        public async Task Storage_Token_Error()
        {
            Storage storage = new(BuildHelper.UrlApi, "token");
            var response = await storage.GetXmlAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Contains("El token debe contener 3 partes"));
        }
        [TestMethod]
        public async Task Storage_Auth_Error()
        {
            Storage storage = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, "password");
            var response = await storage.GetXmlAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Contains("AU4101 - El token proporcionado viene vacio."));
        }
        [TestMethod]
        public async Task StorageExtras_Token_Error()
        {
            Storage storage = new(BuildHelper.UrlApi, "token");
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Contains("El token debe contener 3 partes"));
        }
        [TestMethod]
        public async Task StorageExtras_Auth_Error()
        {
            Storage storage = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, "password");
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Contains("AU4101 - El token proporcionado viene vacio."));
        }
        [TestMethod]
        public async Task Storage_NotFound_Error()
        {
            Storage storage = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("No se encuentra registro del timbrado."));
        }
        [TestMethod]
        public async Task StorageExtras_NotFound_Error()
        {
            Storage storage = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("005ee4ad-1000-4db6-8806-123491c2253e"));
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("No se encuentra registro del timbrado."));
        }
        [TestMethod]
        public async Task Storage_WrongUrlApi_Error()
        {
            Storage storage = new(BuildHelper.UrlService, BuildHelper.Token);
            var response = await storage.GetXmlAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("404"));
            Assert.IsTrue(response.MessageDetail.Equals("Not Found"));
        }
        [TestMethod]
        public async Task StorageExtras_WrongUrlApi_Error()
        {
            Storage storage = new(BuildHelper.UrlService, BuildHelper.Token);
            var response = await storage.GetXmlExtrasAsync(Guid.Parse("6d5ee4ad-102e-4db6-8806-6df891c2253e"));
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("404"));
            Assert.IsTrue(response.MessageDetail.Equals("Not Found"));
        }
    }
}