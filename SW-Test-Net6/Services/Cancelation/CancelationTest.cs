using SW.Services.Cancellation;
using SW.Test.Helpers;

namespace SW.Test.Services.CancellationTest
{
    [TestClass]
    public class CancellationTest
    {
        #region UT Success
        [TestMethod]
        [Ignore ("Intermitencia del SAT.")]
        public async Task CancellationUuid_Success()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.IsTrue(response.Data.Uuid.Count > 0);
        }
        [TestMethod]
        [Ignore("Intermitencia del SAT.")]
        public async Task CancellationUuid_Auth_Success()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.IsTrue(response.Data.Uuid.Count > 0);
        }
        [TestMethod]
        [Ignore("Intermitencia del SAT.")]
        public async Task CancellationCsd_Success()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02"
            };
            var baseDir = "Csd/EKU9003173C9";
            var cer = await BuildHelper.GetByteResourceAsync(baseDir + ".cer");
            var key = await BuildHelper.GetByteResourceAsync(baseDir + ".key");
            var response = await cancelation.CancelByCsdAsync(request, cer, key, "12345678a");
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.IsTrue(response.Data.Uuid.Count > 0);
        }
        [TestMethod]
        [Ignore("Intermitencia del SAT.")]
        public async Task CancellationCsd_Auth_Success()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02"
            };
            var baseDir = "Csd/EKU9003173C9";
            var cer = await BuildHelper.GetByteResourceAsync(baseDir + ".cer");
            var key = await BuildHelper.GetByteResourceAsync(baseDir + ".key");
            var response = await cancelation.CancelByCsdAsync(request, cer, key, "12345678a");
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.IsTrue(response.Data.Uuid.Count > 0);
        }
        [TestMethod]
        [Ignore("Intermitencia del SAT.")]
        public async Task CancellationPfx_Success()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02"
            };
            var baseDir = "Csd/EKU9003173C9";
            var pfx = await BuildHelper.GetByteResourceAsync(baseDir + ".pfx");
            var response = await cancelation.CancelByPfxAsync(request, pfx, BuildHelper.PfxPassword);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.IsTrue(response.Data.Uuid.Count > 0);
        }
        [TestMethod]
        [Ignore("Intermitencia del SAT.")]
        public async Task CancellationPfx_Auth_Success()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02"
            };
            var baseDir = "Csd/EKU9003173C9";
            var pfx = await BuildHelper.GetByteResourceAsync(baseDir + ".pfx");
            var response = await cancelation.CancelByPfxAsync(request, pfx, BuildHelper.PfxPassword);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.IsTrue(response.Data.Uuid.Count > 0);
        }
        [TestMethod]
        [Ignore("Intermitencia del SAT.")]
        public async Task CancellationXml_Success()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.Token);
            var response = await cancelation.CancelByXmlAsync(await BuildHelper.GetStringResourceAsync(@"Xml\xmlCancellation.xml"));
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.IsTrue(response.Data.Uuid.Count > 0);
        }
        [TestMethod]
        [Ignore("Intermitencia del SAT.")]
        public async Task CancellationXml_Auth_Success()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var response = await cancelation.CancelByXmlAsync(await BuildHelper.GetStringResourceAsync(@"Xml\xmlCancellation.xml"));
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Acuse));
            Assert.IsTrue(response.Data.Uuid.Count > 0);
        }
        #endregion
        #region UT Error
        [TestMethod]
        public async Task CancellationUuid_Error()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, "invalidToken");
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task CancellationUuid_Auth_Error()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.User, "invalidPass");
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task CancellationUuid_InvalidMotivo_Error()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "00"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task CancellationUuid_NullRequest_Error()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.Token);
            var response = await cancelation.CancelByUuidAsync(null);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task CancellationUuid_InvalidRfc_Error()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancellationRequest()
            {
                Rfc = null,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02"
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task CancellationUuid_InvalidMotivoSustitucion_Error()
        {
            var cancelation = new Cancellation(BuildHelper.UrlService, BuildHelper.Token);
            var request = new CancellationRequest()
            {
                Rfc = BuildHelper.Rfc,
                Uuid = Guid.Parse("27967127-72db-47f9-8169-0c136d9a5bd8"),
                Motivo = "02",
                FolioSustitucion = Guid.NewGuid()
            };
            var response = await cancelation.CancelByUuidAsync(request);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        #endregion
    }
}
