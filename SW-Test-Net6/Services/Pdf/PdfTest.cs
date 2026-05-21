using SW.Helpers;
using SW.Services.Issue;
using SW.Services.Pdf;
using SW.Test.Helpers;

namespace SW.Test.Services.PdfTest
{
    [TestClass]
    public class PdfTest
    {
        private Issue _issue { get; set; }
        public PdfTest()
        {
            _issue = new(BuildHelper.UrlService, BuildHelper.Token);
        }
        [TestMethod]
        public async Task Pdf_Success()
        {
            var xml = await BuildHelper.GetCfdi("cfdi40.xml");
            var stamp = await _issue.StampV3Async(xml);
            Pdf pdf = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await pdf.GeneratePdfAsync(stamp.Data.Cfdi, PdfTemplate.Cfdi40);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.ContentB64));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Serie));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Folio));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.StampDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.IssuedDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcIssuer));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcReceptor));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Total));
            Assert.IsTrue(response.Data.ContentSizeBytes > 0);
        }
        [TestMethod]
        public async Task Pdf_Auth_Success()
        {
            var xml = await BuildHelper.GetCfdi("cfdi40.xml");
            var stamp = await _issue.StampV3Async(xml);
            Pdf pdf = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var response = await pdf.GeneratePdfAsync(stamp.Data.Cfdi, PdfTemplate.Cfdi40);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.ContentB64));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Serie));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Folio));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.StampDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.IssuedDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcIssuer));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcReceptor));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Total));
            Assert.IsTrue(response.Data.ContentSizeBytes > 0);
        }
        [TestMethod]
        public async Task Pdf_B64_Success()
        {
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true);
            var stamp = await _issue.StampV3Async(xml, true);
            Pdf pdf = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await pdf.GeneratePdfAsync(stamp.Data.Cfdi, PdfTemplate.Cfdi40, null, null, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.ContentB64));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Serie));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Folio));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.StampDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.IssuedDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcIssuer));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcReceptor));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Total));
            Assert.IsTrue(response.Data.ContentSizeBytes > 0);
        }
        [TestMethod]
        public async Task Pdf_StringTemplate_Success()
        {
            var xml = await BuildHelper.GetCfdi("cfdi40.xml");
            var stamp = await _issue.StampV3Async(xml);
            Pdf pdf = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await pdf.GeneratePdfAsync(stamp.Data.Cfdi, "cfdi40");
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.ContentB64));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Serie));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Folio));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.StampDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.IssuedDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcIssuer));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcReceptor));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Total));
            Assert.IsTrue(response.Data.ContentSizeBytes > 0);
        }
        [TestMethod]
        public async Task Pdf_StringTemplate_Auth_Success()
        {
            var xml = await BuildHelper.GetCfdi("cfdi40.xml");
            var stamp = await _issue.StampV3Async(xml);
            Pdf pdf = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var response = await pdf.GeneratePdfAsync(stamp.Data.Cfdi, "cfdi40");
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.ContentB64));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Serie));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Folio));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.StampDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.IssuedDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcIssuer));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcReceptor));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Total));
            Assert.IsTrue(response.Data.ContentSizeBytes > 0);
        }
        [TestMethod]
        public async Task Pdf_StringTemplate_B64_Success()
        {
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true);
            var stamp = await _issue.StampV3Async(xml, true);
            Pdf pdf = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await pdf.GeneratePdfAsync(stamp.Data.Cfdi, "cfdi40", null, null, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.ContentB64));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Serie));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Folio));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.StampDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.IssuedDate));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcIssuer));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.RfcReceptor));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Total));
            Assert.IsTrue(response.Data.ContentSizeBytes > 0);
        }
    }
}
