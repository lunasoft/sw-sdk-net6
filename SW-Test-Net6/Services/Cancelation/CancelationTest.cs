using SW.Services.Cancelation;
using SW.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Test.Services.CancelationTest
{
    [TestClass]
    public class CancelationTest
    {
        #region UT Success
        [TestMethod]
        public async Task CancelationUuid_Success()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancelationRequest()
            {
                rfc = BuildHelper.Rfc,
                uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                motivo = "02"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.acuse));
            Assert.IsTrue(response.data.uuid.Count > 0);
        }
        [TestMethod]
        public async Task CancelationUuid_Auth_Success()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var request = new CancelationRequest()
            {
                rfc = BuildHelper.Rfc,
                uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                motivo = "02"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.acuse));
            Assert.IsTrue(response.data.uuid.Count > 0);
        }
        [TestMethod]
        public async Task CancelationCsd_Success()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancelationRequest()
            {
                rfc = BuildHelper.Rfc,
                uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                motivo = "02"
            };
            var baseDir = "Csd/EKU9003173C9";
            var cer = await BuildHelper.GetByteResourceAsync(baseDir + ".cer");
            var key = await BuildHelper.GetByteResourceAsync(baseDir + ".key");
            var response = await cancelation.CancelByCsdAsync(request, cer, key, "12345678a");
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.acuse));
            Assert.IsTrue(response.data.uuid.Count > 0);
        }
        [TestMethod]
        public async Task CancelationCsd_Auth_Success()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var request = new CancelationRequest()
            {
                rfc = BuildHelper.Rfc,
                uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                motivo = "02"
            };
            var baseDir = "Csd/EKU9003173C9";
            var cer = await BuildHelper.GetByteResourceAsync(baseDir + ".cer");
            var key = await BuildHelper.GetByteResourceAsync(baseDir + ".key");
            var response = await cancelation.CancelByCsdAsync(request, cer, key, "12345678a");
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.acuse));
            Assert.IsTrue(response.data.uuid.Count > 0);
        }
        [TestMethod]
        public async Task CancelationPfx_Success()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancelationRequest()
            {
                rfc = BuildHelper.Rfc,
                uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                motivo = "02"
            };
            var baseDir = "Csd/EKU9003173C9";
            var pfx = await BuildHelper.GetByteResourceAsync(baseDir + ".pfx");
            var response = await cancelation.CancelByPfxAsync(request, pfx, BuildHelper.PfxPassword);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.acuse));
            Assert.IsTrue(response.data.uuid.Count > 0);
        }
        [TestMethod]
        public async Task CancelationPfx_Auth_Success()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var request = new CancelationRequest()
            {
                rfc = BuildHelper.Rfc,
                uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                motivo = "02"
            };
            var baseDir = "Csd/EKU9003173C9";
            var pfx = await BuildHelper.GetByteResourceAsync(baseDir + ".pfx");
            var response = await cancelation.CancelByPfxAsync(request, pfx, BuildHelper.PfxPassword);
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.acuse));
            Assert.IsTrue(response.data.uuid.Count > 0);
        }
        [TestMethod]
        public async Task CancelationXml_Success()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.Token);
            var response = await cancelation.CancelByXmlAsync(await BuildHelper.GetStringResourceAsync(@"Xml\xmlCancelation.xml"));
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.acuse));
            Assert.IsTrue(response.data.uuid.Count > 0);
        }
        [TestMethod]
        public async Task CancelationXml_Auth_Success()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var response = await cancelation.CancelByXmlAsync(await BuildHelper.GetStringResourceAsync(@"Xml\xmlCancelation.xml"));
            Assert.IsTrue(response.status.Equals("success"));
            Assert.IsNotNull(response.data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.data.acuse));
            Assert.IsTrue(response.data.uuid.Count > 0);
        }
        #endregion
        #region UT Error
        [TestMethod]
        public async Task CancelationUuid_Error()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, "invalidToken");
            var request = new CancelationRequest()
            {
                rfc = BuildHelper.Rfc,
                uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                motivo = "02"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.messageDetail));
        }
        [TestMethod]
        public async Task CancelationUuid_Auth_Error()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.User, "invalidPass");
            var request = new CancelationRequest()
            {
                rfc = BuildHelper.Rfc,
                uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                motivo = "02"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.messageDetail));
        }
        [TestMethod]
        public async Task CancelationUuid_InvalidMotivo_Error()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancelationRequest()
            {
                rfc = BuildHelper.Rfc,
                uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                motivo = "00"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.messageDetail));
        }
        [TestMethod]
        public async Task CancelationUuid_NullRequest_Error()
        {
            var cancelation = new Cancelation(BuildHelper.UrlService, BuildHelper.Token);
            var response = await cancelation.CancelByUuidAsync(null);
            Assert.IsTrue(response.status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.messageDetail));
        }
        #endregion
    }
}
