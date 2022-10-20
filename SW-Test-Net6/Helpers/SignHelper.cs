using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using System.Xml;

namespace SW.Test.Helpers
{
    public class SignHelper
    {
        static Random randomNumber = new Random(1);

        internal static string SignCfdi(byte[] pfx, string password, string xml)
        {
            xml = RemoverCaracteresInvalidosXml(xml);
            X509Certificate2 x509Certificate = new X509Certificate2(pfx, password
                 , X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

            //Set values Certificate
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("NoCertificado", CertificateNumber(x509Certificate));
            doc.DocumentElement.SetAttribute("Certificado", Convert.ToBase64String(x509Certificate.GetRawCertData()));
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                xml = RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(ms.ToArray()));
            }
            //Get original string
            string originalString = CadenaOriginalCFDI40(xml);
            //Sign Document
            var signResult = GetSignature(password, pfx, originalString, "SHA256");
            //Set Values Signature
            doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.DocumentElement.SetAttribute("Sello", signResult);
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                xml = RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(ms.ToArray()));
            }
            return xml;
        }

        internal static string CadenaOriginalCFDI40(string strXml)
        {
            try
            {
                var xslt = new XslCompiledTransform();
                XsltSettings settings = new XsltSettings(true, true);
                XmlUrlResolver resolver = new XmlUrlResolver();
                xslt.Load("Resources/Xslt/cadenaoriginal_4_0.xslt", settings, resolver);
                string resultado = null;
                StringWriter writer = new StringWriter();
                XmlReader xml = XmlReader.Create(new StringReader(strXml));
                xslt.Transform(xml, null, writer);
                resultado = writer.ToString().Trim();
                writer.Close();

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("El XML proporcionado no es válido.", ex);
            }
        }

        private static string GetSignature(string password, byte[] pfx, string strToSign, string algorithm = "SHA1")
        {
            var signData = string.Empty;
            RSACryptoServiceProvider rsa = default(RSACryptoServiceProvider);
            byte[] signatureBytes = default(byte[]);
            X509Certificate2 certX509 = new X509Certificate2(pfx, password
                 , X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

            rsa = new RSACryptoServiceProvider();
            RSAKeyHelper.FromXmlString(rsa, RSAKeyHelper.ToXmlString(certX509.GetRSAPrivateKey(), true));
            byte[] data = Encoding.UTF8.GetBytes(strToSign);

            signatureBytes = rsa.SignData(data, CryptoConfig.MapNameToOID(algorithm));
            return Convert.ToBase64String(signatureBytes);
        }

        private static string CertificateNumber(X509Certificate2 cert)
        {
            string hexadecimalString = cert.SerialNumber;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexadecimalString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexadecimalString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
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
    }
}
