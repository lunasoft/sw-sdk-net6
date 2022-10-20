using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SW.Test.Helpers
{
    public class BuildHelper
    {
        public static string User = "pruebas_ut@sw.com.mx";
        public static string Password = "swpass";
        public static string Token = "T2lYQ0t4L0RHVkR4dHZ5Nkk1VHNEakZ3Y0J4Nk9GODZuRyt4cE1wVm5tbXB3YVZxTHdOdHAwVXY2NTdJb1hkREtXTzE3dk9pMmdMdkFDR2xFWFVPUXpTUm9mTG1ySXdZbFNja3FRa0RlYURqbzdzdlI2UUx1WGJiKzViUWY2dnZGbFloUDJ6RjhFTGF4M1BySnJ4cHF0YjUvbmRyWWpjTkVLN3ppd3RxL0dJPQ.T2lYQ0t4L0RHVkR4dHZ5Nkk1VHNEakZ3Y0J4Nk9GODZuRyt4cE1wVm5tbFlVcU92YUJTZWlHU3pER1kySnlXRTF4alNUS0ZWcUlVS0NhelhqaXdnWTRncklVSWVvZlFZMWNyUjVxYUFxMWFxcStUL1IzdGpHRTJqdS9Zakw2UGRZbFlVYmJVSkxXa1NZNzN5VUlSUzlJaTYvbi9wczBSRnZGK1NUNUVoM1FNNXZJRUg1Qkx1dXJ1Z09EcHYyQnE4V1dnOHpkczFLdm5MZytxalNBeHdRbmFvb2VhTksrVzhyTTFXU09NbzZVeXMyQ2Q4VC9ncUlqWGZaMFhXSkdmcjJIWlB2Z2RmeFJGNzRkdXh2UHlvdnVhbGN6cGFsRWhSY3BOOWxPc0h4Z2ZJRjBjZEl5WEsvZW0vb0ZxZEJjUGtpRFlWYi9zRDZwZVJFRks0QUpRNkplZ2N4UzVEME40d2RhUHA4c1VUQWJiY1Jvc3NSVFcrRzVyTHNOTWovZlJHQmV6c0lmclE1TXV3aVY3UERtQUo3SjdpTzhuc1R1SGt1R0s0UHUvc3hEZWRtK3U0NExEYUdUVWIxL3NKRE1XY1RlTnNMaENoSFUvVGhaclk2WmNPR2JjUlpib1RPUTN5QUxiU0VEY0NpYmJDcDZHY3pGd0ZJMXcxTEExTnBPdzM.VZBKM8Odz5VdIyhQPZyRaJK1iVLmot-oMf0h69NU4vk";
        public static string UrlService = "https://services.test.sw.com.mx";
        public static string UrlApi = "https://api.test.sw.com.mx";
        public static string PfxPassword = "swpass";

        public static async Task<string> GetJson(string fileName)
        {
            var cfdi = await File.ReadAllTextAsync(String.Format(@"Resources\Cfdi\{0}", fileName), Encoding.UTF8);
            var json = JObject.Parse(cfdi);
            json["Fecha"] = DateTime.Now.AddHours(-6).ToString("yyyy-MM-ddTHH:mm:ss");
            json["Serie"] = Assembly.GetExecutingAssembly().GetName().Name;
            json["Folio"] = Guid.NewGuid().ToString();
            return json.ToString();
        }
        public static async Task<string> GetXml(string fileName, bool isB64 = false, bool sign = false)
        {
            var cfdi = await File.ReadAllTextAsync(String.Format(@"Resources\Cfdi\{0}", fileName), Encoding.UTF8);
            var doc = new XmlDocument();
            doc.LoadXml(cfdi);
            doc.DocumentElement.SetAttribute("Fecha", DateTime.Now.AddHours(-6).ToString("yyyy-MM-ddTHH:mm:ss"));
            doc.DocumentElement.SetAttribute("Serie", Assembly.GetExecutingAssembly().GetName().Name);
            doc.DocumentElement.SetAttribute("Folio", Guid.NewGuid().ToString());
            string xml = sign ? SignXml(doc.OuterXml) : doc.OuterXml;
            return isB64 ? Convert.ToBase64String(Encoding.UTF8.GetBytes(xml)) : xml;
        }
        internal static string SignXml(string xml)
        {
            var bytesPfx = File.ReadAllBytes(@"Resources\Csd\EKU9003173C9.pfx");
            var signedXml = SignHelper.SignCfdi(bytesPfx, PfxPassword, xml);
            return signedXml;
        }
    }
}
