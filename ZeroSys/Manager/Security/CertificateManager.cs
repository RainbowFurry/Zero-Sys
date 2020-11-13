using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Certificate Manager          *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Manager.Security
{
    /// <summary>
    /// Windows Certificate Manager
    /// </summary>
    public class CertificateManager
    {

        //nicht fertig

        /*
         Organisation = O
        GeneralName = CN
        Domain = DC
        Land = S
         */

        private static readonly string savePath = AppDomain.CurrentDomain.BaseDirectory + "/Certificate/";

        /// <summary>
        /// Generate Windows Password Certificate
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="filePassword"></param>
        /// <param name="ceartInfo">Organisation = O | GeneralName = CN | Domain = DC | Land = S</param>
        public static void GeneratePFX(string fileName, string filePassword, string ceartInfo)
        {

            if (String.IsNullOrEmpty(ceartInfo))
            {
                ceartInfo = "cn=ZeroWorks GmbH";
            }

            var ecdsa = ECDsa.Create(); // generate asymmetric key pair
            var req = new CertificateRequest("cn=foobar", ecdsa, HashAlgorithmName.SHA256);
            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(100));

            // Create PFX (PKCS #12) with private key
            File.WriteAllBytes(savePath + fileName + ".pfx", cert.Export(X509ContentType.Pfx, filePassword));

        }

        /// <summary>
        /// Generate Windows Certificate
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ceartInfo"></param>
        public static void GenerateCertificate(string fileName, string ceartInfo)
        {

            if (String.IsNullOrEmpty(ceartInfo))
            {
                ceartInfo = "ZeroWorks GmbH";
            }

            var ecdsa = ECDsa.Create(); // generate asymmetric key pair
            var req = new CertificateRequest("cn=foobar", ecdsa, HashAlgorithmName.SHA256);
            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(100));

            // Create Base 64 encoded CER (public key only)
            File.WriteAllText(savePath + fileName + ".cer",
                "-----BEGIN CERTIFICATE-----\r\n"
                + Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks)
                + "\r\n-----END CERTIFICATE-----");

        }

    }
}
