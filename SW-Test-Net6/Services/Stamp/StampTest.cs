using SW.Services.Stamp;
using SW.Services.Stamp;
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
    public class StampTest
    {
        #region UT Success
        #region V1
        [TestMethod]
        public async Task StampV1_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var response = await stamp.StampV1Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        [TestMethod]
        public async Task StampV1_Auth_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var response = await stamp.StampV1Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        [TestMethod]
        public async Task StampV1_B64_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var response = await stamp.StampV1Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        [TestMethod]
        public async Task StampV1_B64_Auth_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var response = await stamp.StampV1Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        [TestMethod]
        public async Task StampV1_BigXml_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_big.xml", false, true);
            var response = await stamp.StampV1Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        [TestMethod]
        public async Task StampV1_SpecialChar_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_special_char.xml", false, true);
            var response = await stamp.StampV1Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        [TestMethod]
        public async Task StampV1_SpecialChar_B64_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_special_char.xml", true, true);
            var response = await stamp.StampV1Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
        }
        #endregion
        #region V2
        [TestMethod]
        public async Task StampV2_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var response = await stamp.StampV2Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV2_Auth_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var response = await stamp.StampV2Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV2_B64_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var response = await stamp.StampV2Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV2_B64_Auth_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var response = await stamp.StampV2Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [Ignore("Se ejecuta según sea requerido.")]
        [TestMethod]
        public async Task StampV2_BigXml_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_big.xml");
            var response = await stamp.StampV2Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV2_SpecialChar_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_special_char.xml", false, true);
            var response = await stamp.StampV2Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV2_SpecialChar_B64_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_special_char.xml", true, true);
            var response = await stamp.StampV2Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Tfd));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        #endregion
        #region V3
        [TestMethod]
        public async Task StampV3_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var response = await stamp.StampV3Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV3_Auth_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var response = await stamp.StampV3Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV3_B64_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var response = await stamp.StampV3Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV3_B64_Auth_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var response = await stamp.StampV3Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [Ignore("Se ejecuta según sea requerido.")]
        [TestMethod]
        public async Task StampV3_BigXml_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml");
            var response = await stamp.StampV3Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV3_SpecialChar_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_special_char.xml", false, true);
            var response = await stamp.StampV3Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        [TestMethod]
        public async Task StampV3_SpecialChar_B64_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_special_char.xml", true, true);
            var response = await stamp.StampV3Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
        }
        #endregion
        #region V4
        [TestMethod]
        public async Task StampV4_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var response = await stamp.StampV4Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
        [TestMethod]
        public async Task StampV4_Auth_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", false, true);
            var response = await stamp.StampV4Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
        [TestMethod]
        public async Task StampV4_B64_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var response = await stamp.StampV4Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
        [TestMethod]
        public async Task StampV4_B64_Auth_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml", true, true);
            var response = await stamp.StampV4Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
        [Ignore("Se ejecuta según sea requerido.")]
        [TestMethod]
        public async Task StampV4_BigXml_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40.xml");
            var response = await stamp.StampV4Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
        [TestMethod]
        public async Task StampV4_SpecialChar_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_special_char.xml", false, true);
            var response = await stamp.StampV4Async(xml);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
        [TestMethod]
        public async Task StampV4_SpecialChar_B64_Success()
        {
            var stamp = new Stamp(BuildHelper.UrlService, BuildHelper.Token);
            var xml = await BuildHelper.GetCfdi("cfdi40_special_char.xml", true, true);
            var response = await stamp.StampV4Async(xml, true);
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.QrCode));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Uuid));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.FechaTimbrado));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.CadenaOriginalSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.Cfdi));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.NoCertificadoSAT));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloCFDI));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Data.SelloSAT));
        }
    }
    #endregion
    #endregion
}
