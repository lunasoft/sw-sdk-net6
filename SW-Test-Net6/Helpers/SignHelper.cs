using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Xsl;
using System.Xml;

namespace SW.Test.Helpers
{
    public class SignHelper
    {
        internal static string SignCfdi(byte[] pfx, string password, string xml)
        {
            try
            {
                X509Certificate2 x509Certificate = new(pfx, password
                 , X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                XmlDocument doc = new();
                doc.LoadXml(xml);
                doc.DocumentElement.SetAttribute("NoCertificado", CertificateNumber(x509Certificate));
                doc.DocumentElement.SetAttribute("Certificado", Convert.ToBase64String(x509Certificate.GetRawCertData()));
                xml = SaveXmlDocument(doc);
                string originalString = GetCadenaOriginal(xml);
                var signResult = GetSello(pfx, password, originalString);
                doc = new();
                doc.LoadXml(xml);
                doc.DocumentElement.SetAttribute("Sello", signResult);
                return SaveXmlDocument(doc);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private static string GetCadenaOriginal(string xml)
        {
            XsltSettings settings = new(true, true);
            XmlUrlResolver resolver = new();
            XslCompiledTransform xslt = new();
            xslt.Load("Resources/Xslt/cadenaoriginal_4_0.xslt", settings, resolver);
            string transformedXml = String.Empty;
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            using (StringWriter stringWriter = new())
            {
                xslt.Transform(xmlReader, null, stringWriter);
                transformedXml = stringWriter.ToString();
                xmlReader.Close();
                stringWriter.Close();
            }
            return transformedXml;
        }
        private static string GetSello(byte[] pfx, string password, string cadenaOriginal)
        {
            X509Certificate2 certificate = new(pfx, password);
            var rsaPrivKey = certificate.GetRSAPrivateKey();
            CngKey privateKey = rsaPrivKey is RSACng rsaCng ? rsaCng.Key : CngKey.Open("");
            RSACng rsa = new(privateKey);
            byte[] signature = rsa.SignData(Encoding.UTF8.GetBytes(cadenaOriginal), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return Convert.ToBase64String(signature);
        }
        private static string CertificateNumber(X509Certificate2 cert)
        {
            string hexadecimalString = cert.SerialNumber;
            StringBuilder sb = new();
            for (int i = 0; i <= hexadecimalString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexadecimalString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        private static string SaveXmlDocument(XmlDocument xml)
        {
            string strXml = String.Empty;
            using (MemoryStream ms = new())
            {
                xml.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                strXml = RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(ms.ToArray()));
                ms.Close();
            }
            return strXml;
        }
        internal static string RemoverCaracteresInvalidosXml(string xmlInvoice)
        {
            xmlInvoice = xmlInvoice.Replace("\r\n", "");
            xmlInvoice = xmlInvoice.Replace("\r", "");
            xmlInvoice = xmlInvoice.Replace("\n", "");
            xmlInvoice = xmlInvoice.Replace("﻿", "");
            xmlInvoice = xmlInvoice.Replace(@"
", "");
            return xmlInvoice;
        }
        internal static byte[] CreatePfx(byte[] certificate, byte[] privateKey, string password)
        {
            try
            {
                var rsa = RSA.Create();
                rsa.ImportEncryptedPkcs8PrivateKey(password, privateKey, out _);
                var cert = new X509Certificate2(certificate, password,
                    X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                var x509Certificate = cert.CopyWithPrivateKey(rsa);
                return x509Certificate.Export(X509ContentType.Pfx, password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
