using SW.Services.IssueJson;
using SW.Test.Helpers;

namespace SW.Test.Services.IssueJsonTest
{
    [TestClass]
    public class IssueJsonV4StorageTest
    {
        [TestMethod]
        public async Task IssueJsonV4Storage_V2_CFDI3307_Success()
        {
            var stamp = new IssueJsonV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(json, customId);
            json = await BuildHelper.GetCfdiJson("cfdi40.json");
            Thread.Sleep(5000);
            response = await stamp.StampV2Async(json, customId);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV4Storage_V2_CFDI3307_Auth_Success()
        {
            var stamp = new IssueJsonV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(json, customId);
            json = await BuildHelper.GetCfdiJson("cfdi40.json");
            Thread.Sleep(5000);
            response = await stamp.StampV2Async(json, customId);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV4Storage_V2_CFDI3307_Error()
        {
            var stamp = new IssueJsonV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var jsonA = await BuildHelper.GetCfdiJson("cfdi40.json");
            var jsonB = await BuildHelper.GetCfdiJson("cfdi40.json");
            var customId = Guid.NewGuid().ToString();
            var response = await stamp.StampV2Async(jsonA, customId);
            response = await stamp.StampV2Async(jsonB, customId);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("CFDI3307 - Timbre duplicado. El customId proporcionado está duplicado."));
            Assert.IsTrue(response.MessageDetail.Equals("No se pudo obtener la URL de descarga."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task IssueJsonV4Storage_V2_307_Error()
        {
            var stamp = new IssueJsonV4Storage(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.Token);
            var json = await BuildHelper.GetCfdiJson("cfdi40.json");
            var response = await stamp.StampV2Async(json, Guid.NewGuid().ToString());
            response = await stamp.StampV2Async(json, Guid.NewGuid().ToString());
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("307. El comprobante contiene un timbre previo."));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
    }
}
