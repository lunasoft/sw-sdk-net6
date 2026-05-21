using SW.Services.Resend;
using SW.Test.Helpers;

namespace SW.Test.Services.ResendTest
{
    [TestClass]
    public class ResendTest
    {
        [TestMethod]
        public async Task Resend_Success()
        {
            Resend resend = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await resend.ResendEmail(Guid.Parse("e9ed746b-751a-46e9-aa8a-e4e65960163a"), new string[] { "user@mail.com" });
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task Resend_Auth_Success()
        {
            Resend resend = new(BuildHelper.UrlApi, BuildHelper.UrlService, BuildHelper.User, BuildHelper.Password);
            var response = await resend.ResendEmail(Guid.Parse("e9ed746b-751a-46e9-aa8a-e4e65960163a"), new string[] { "user@mail.com    " });
            Assert.IsTrue(response.Status.Equals("success"));
            Assert.IsTrue(!String.IsNullOrEmpty(response.Message));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task Resend_InvalidMail_Error()
        {
            Resend resend = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await resend.ResendEmail(Guid.Parse("e9ed746b-751a-46e9-aa8a-e4e65960163a"), new string[] { "myMail" });
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("El listado de correos no tiene un formato válido o contiene mas de 5 correos."));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task Resend_NullMail_Error()
        {
            Resend resend = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await resend.ResendEmail(Guid.Parse("e9ed746b-751a-46e9-aa8a-e4e65960163a"), null);
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("El listado de correos no tiene un formato válido o contiene mas de 5 correos."));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
        [TestMethod]
        public async Task Resend_MaxAllowedMail()
        {
            Resend resend = new(BuildHelper.UrlApi, BuildHelper.Token);
            var response = await resend.ResendEmail(Guid.Parse("e9ed746b-751a-46e9-aa8a-e4e65960163a"), 
                new string[] { "a@mail.com", "a@mail.com", "a@mail.com", "a@mail.com", "a@mail.com", "a@mail.com" });
            Assert.IsTrue(response.Status.Equals("error"));
            Assert.IsTrue(response.Message.Equals("El listado de correos no tiene un formato válido o contiene mas de 5 correos."));
            Assert.IsTrue(!String.IsNullOrEmpty(response.MessageDetail));
        }
    }
}