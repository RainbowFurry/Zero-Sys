using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using ZeroSys.Model;

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

        /*
         Organisation = O
        GeneralName = CN
        Domain = DC
        Land = S
         */

        private static readonly string savePath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Create new Certificate
        /// </summary>
        /// <param name="certificate"></param>
        public static void CreateNewCertificate(Certificate certificate)
        {

            try
            {

                if (!string.IsNullOrEmpty(certificate.DisplayName) && !string.IsNullOrEmpty(certificate.Organisation))
                {

                    //Get Certificate display Content
                    string content = "CN=" + certificate.DisplayName;
                    if (string.IsNullOrEmpty(certificate.FullName))
                        content = "DN=" + certificate.FullName;
                    if (string.IsNullOrEmpty(certificate.Title))
                        content = "T=" + certificate.Title;
                    if (string.IsNullOrEmpty(certificate.FirstName))
                        content = "G=" + certificate.FirstName;
                    if (string.IsNullOrEmpty(certificate.SecondName))
                        content = "SN=" + certificate.SecondName;
                    if (string.IsNullOrEmpty(certificate.Email))
                        content = "E=" + certificate.Email;
                    if (string.IsNullOrEmpty(certificate.Country))
                        content = "C=" + certificate.Country;
                    if (string.IsNullOrEmpty(certificate.Place))
                        content = "L=" + certificate.Place;
                    if (string.IsNullOrEmpty(certificate.Street))
                        content = "street=" + certificate.Street;
                    if (string.IsNullOrEmpty(certificate.Organisation))
                        content = "O=" + certificate.Organisation;

                    //Create Certificate
                    var req = new CertificateRequest(content, RSA.Create(2048), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    //         req.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));

                    //         req.CertificateExtensions.Add(
                    //new X509EnhancedKeyUsageExtension(
                    //    new OidCollection
                    //    {
                    //                 //http://javadoc.iaik.tugraz.at/iaik_jce/current/iaik/x509/extensions/ExtendedKeyUsage.html
                    //                 new Oid("1.3.6.1.5.5.7.3.1"),  // TLS Server auth
                    //                 new Oid("1.3.6.1.5.5.7.3.2"),  // TLS Client auth
                    //                 //new Oid("1.3.6.1.5.5.7.3.3"), //Code Sign
                    //                 //emailProtection (1.3.6.1.5.5.7.3.4)
                    //                 //timeStamping (1.3.6.1.5.5.7.3.8)
                    //                 //ocspSigning (1.3.6.1.5.5.7.3.9)
                    //                 //ipsecEndSystem (1.3.6.1.5.5.7.3.5)
                    //                 //ipsecTunnel (1.3.6.1.5.5.7.3.6)
                    //                 //ipsecUser (1.3.6.1.5.5.7.3.7)
                    //             },
                    //    true));

                    //var a = new X509ChainPolicy();
                    //    a.VerificationFlags = X509VerificationFlags.AllFlags;
                    //a.RevocationFlag = X509RevocationFlag.EndCertificateOnly;
                    //req.CertificateExtensions.Add(new X509ExtensionCollection(a));

                    //         req.CertificateExtensions.Add(
                    //             new X509KeyUsageExtension(
                    //                 X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation,
                    //                 false));

                    //         req.CertificateExtensions.Add(
                    //new X509SubjectKeyIdentifierExtension(req.PublicKey, false));


                    var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(1));

                    if (certificate.Duration_Days == 0 && certificate.Duration_Months == 0 && certificate.Duration_Years == 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(100));

                    if (certificate.Duration_Days != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(certificate.Duration_Days));
                    else if (certificate.Duration_Months != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(certificate.Duration_Months));
                    else if (certificate.Duration_Years != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(certificate.Duration_Years));

                    if (string.IsNullOrEmpty(certificate.Password))
                    {

                        if (certificate.CertType == CertificateType.CER)
                            File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Cert));
                        else if (certificate.CertType == CertificateType.PFX)
                            File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Pfx));
                        else
                            File.WriteAllBytes(savePath + certificate.DisplayName + ".snk", cert.Export(X509ContentType.Pfx));

                    }
                    else
                    {
                        if (certificate.CertType == CertificateType.CER)
                            File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Cert, certificate.Password));
                        else if (certificate.CertType == CertificateType.PFX)
                            File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Pfx, certificate.Password));
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// Create new SSL Certificate
        /// </summary>
        /// <param name="certificate"></param>
        public static void CreateNewCertificateSSL(Certificate certificate)
        {

            try
            {

                if (!string.IsNullOrEmpty(certificate.DisplayName) && !string.IsNullOrEmpty(certificate.Organisation))
                {

                    //Get Certificate display Content
                    string content = "CN=" + certificate.DisplayName;
                    if (string.IsNullOrEmpty(certificate.FullName))
                        content = "DN=" + certificate.FullName;
                    if (string.IsNullOrEmpty(certificate.Title))
                        content = "T=" + certificate.Title;
                    if (string.IsNullOrEmpty(certificate.FirstName))
                        content = "G=" + certificate.FirstName;
                    if (string.IsNullOrEmpty(certificate.SecondName))
                        content = "SN=" + certificate.SecondName;
                    if (string.IsNullOrEmpty(certificate.Email))
                        content = "E=" + certificate.Email;
                    if (string.IsNullOrEmpty(certificate.Country))
                        content = "C=" + certificate.Country;
                    if (string.IsNullOrEmpty(certificate.Place))
                        content = "L=" + certificate.Place;
                    if (string.IsNullOrEmpty(certificate.Street))
                        content = "street=" + certificate.Street;
                    if (string.IsNullOrEmpty(certificate.Organisation))
                        content = "O=" + certificate.Organisation;

                    //Create Certificate
                    var req = new CertificateRequest(content, RSA.Create(2048), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    req.CertificateExtensions.Add(
             new X509BasicConstraintsExtension(false, false, 0, false));

                    req.CertificateExtensions.Add(
           new X509EnhancedKeyUsageExtension(
               new OidCollection
               {
                            new Oid("1.3.6.1.5.5.7.3.1"),  // TLS Server auth
                            new Oid("1.3.6.1.5.5.7.3.2"),  // TLS Client auth
                            //new Oid("1.3.6.1.5.5.7.3.3"), //Code Sign
                            //emailProtection (1.3.6.1.5.5.7.3.4)
                            //timeStamping (1.3.6.1.5.5.7.3.8)
                            //ocspSigning (1.3.6.1.5.5.7.3.9)
                            //ipsecEndSystem (1.3.6.1.5.5.7.3.5)
                            //ipsecTunnel (1.3.6.1.5.5.7.3.6)
                            //ipsecUser (1.3.6.1.5.5.7.3.7)
                        },
               true));

                    req.CertificateExtensions.Add(
                        new X509KeyUsageExtension(
                            X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation,
                            false));

                    req.CertificateExtensions.Add(
           new X509SubjectKeyIdentifierExtension(req.PublicKey, false));


                    var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(1));

                    if (certificate.Duration_Days == 0 && certificate.Duration_Months == 0 && certificate.Duration_Years == 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(100));

                    if (certificate.Duration_Days != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(certificate.Duration_Days));
                    else if (certificate.Duration_Months != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(certificate.Duration_Months));
                    else if (certificate.Duration_Years != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(certificate.Duration_Years));

                    if (string.IsNullOrEmpty(certificate.Password))
                    {

                        if (certificate.CertType == CertificateType.CER)
                            File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Cert));
                        else if (certificate.CertType == CertificateType.PFX)
                            File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Pfx));

                    }
                    else
                    {
                        if (certificate.CertType == CertificateType.CER)
                            File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Cert, certificate.Password));
                        else if (certificate.CertType == CertificateType.PFX)
                            File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Pfx, certificate.Password));
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// Create new Code Sign Certificate
        /// </summary>
        /// <param name="certificate"></param>
        public static void CreateNewCertificateCodeSign(Certificate certificate)
        {

            try
            {

                if (!string.IsNullOrEmpty(certificate.DisplayName) && !string.IsNullOrEmpty(certificate.Organisation))
                {

                    //Get Certificate display Content
                    string content = "CN=" + certificate.DisplayName;
                    if (string.IsNullOrEmpty(certificate.FullName))
                        content = "DN=" + certificate.FullName;
                    if (string.IsNullOrEmpty(certificate.Title))
                        content = "T=" + certificate.Title;
                    if (string.IsNullOrEmpty(certificate.FirstName))
                        content = "G=" + certificate.FirstName;
                    if (string.IsNullOrEmpty(certificate.SecondName))
                        content = "SN=" + certificate.SecondName;
                    if (string.IsNullOrEmpty(certificate.Email))
                        content = "E=" + certificate.Email;
                    if (string.IsNullOrEmpty(certificate.Country))
                        content = "C=" + certificate.Country;
                    if (string.IsNullOrEmpty(certificate.Place))
                        content = "L=" + certificate.Place;
                    if (string.IsNullOrEmpty(certificate.Street))
                        content = "street=" + certificate.Street;
                    if (string.IsNullOrEmpty(certificate.Organisation))
                        content = "O=" + certificate.Organisation;

                    //Create Certificate
                    var req = new CertificateRequest(content, RSA.Create(2048), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    req.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));

                    req.CertificateExtensions.Add(
           new X509EnhancedKeyUsageExtension(
               new OidCollection
               {
                   new Oid("1.3.6.1.5.5.7.3.3"), //Code Sign
               },
               true));

                    req.CertificateExtensions.Add(
                        new X509KeyUsageExtension(
                            X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation,
                            false));

                    req.CertificateExtensions.Add(
           new X509SubjectKeyIdentifierExtension(req.PublicKey, false));


                    var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(1));

                    if (certificate.Duration_Days == 0 && certificate.Duration_Months == 0 && certificate.Duration_Years == 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(100));

                    if (certificate.Duration_Days != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(certificate.Duration_Days));
                    else if (certificate.Duration_Months != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(certificate.Duration_Months));
                    else if (certificate.Duration_Years != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(certificate.Duration_Years));

                    if (string.IsNullOrEmpty(certificate.Password))
                    {
                        File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Pfx));
                    }
                    else
                    {
                        File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Pfx, certificate.Password));
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// Create new Manifest Certificate
        /// </summary>
        /// <param name="certificate"></param>
        public static void CreateNewCertificateManifest(Certificate certificate)
        {

            try
            {

                if (!string.IsNullOrEmpty(certificate.DisplayName) && !string.IsNullOrEmpty(certificate.Organisation))
                {

                    //Get Certificate display Content
                    string content = "CN=" + certificate.DisplayName;
                    if (string.IsNullOrEmpty(certificate.FullName))
                        content = "DN=" + certificate.FullName;
                    if (string.IsNullOrEmpty(certificate.Title))
                        content = "T=" + certificate.Title;
                    if (string.IsNullOrEmpty(certificate.FirstName))
                        content = "G=" + certificate.FirstName;
                    if (string.IsNullOrEmpty(certificate.SecondName))
                        content = "SN=" + certificate.SecondName;
                    if (string.IsNullOrEmpty(certificate.Email))
                        content = "E=" + certificate.Email;
                    if (string.IsNullOrEmpty(certificate.Country))
                        content = "C=" + certificate.Country;
                    if (string.IsNullOrEmpty(certificate.Place))
                        content = "L=" + certificate.Place;
                    if (string.IsNullOrEmpty(certificate.Street))
                        content = "street=" + certificate.Street;
                    if (string.IsNullOrEmpty(certificate.Organisation))
                        content = "O=" + certificate.Organisation;

                    var req = new CertificateRequest(content, RSA.Create(2048), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    req.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));

                    req.CertificateExtensions.Add(
           new X509EnhancedKeyUsageExtension(
               new OidCollection
               {
                            //http://javadoc.iaik.tugraz.at/iaik_jce/current/iaik/x509/extensions/ExtendedKeyUsage.html
                            //new Oid("1.3.6.1.5.5.7.3.1"),  // TLS Server auth
                            //new Oid("1.3.6.1.5.5.7.3.2"),  // TLS Client auth
                            new Oid("1.3.6.1.5.5.7.3.3"), //Code Sign
                        },
               true));

                    req.CertificateExtensions.Add(
                        new X509KeyUsageExtension(
                            X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation,
                            false));

                    req.CertificateExtensions.Add(
           new X509SubjectKeyIdentifierExtension(req.PublicKey, false));


                    var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(1));

                    if (certificate.Duration_Days == 0 && certificate.Duration_Months == 0 && certificate.Duration_Years == 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(100));

                    if (certificate.Duration_Days != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(certificate.Duration_Days));
                    else if (certificate.Duration_Months != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(certificate.Duration_Months));
                    else if (certificate.Duration_Years != 0)
                        cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(certificate.Duration_Years));

                    if (string.IsNullOrEmpty(certificate.Password))
                    {
                        File.WriteAllBytes(savePath + certificate.DisplayName + ".snk", cert.Export(X509ContentType.Pfx));
                    }
                    else
                    {
                        File.WriteAllBytes(savePath + certificate.DisplayName + ".snk", cert.Export(X509ContentType.Pfx, certificate.Password));
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        /// <summary>
        /// Install the Certificate
        /// </summary>
        public static void InstallCertificate(string filePath, StoreName storename, StoreLocation storeLocation)
        {

            X509Certificate2 certificate = new X509Certificate2(filePath, "0000");
            X509Store store = new X509Store(storename, storeLocation);
            store.Open(OpenFlags.ReadWrite);
            //store.Certificates
            store.Add(certificate);
            store.Close();

        }

        /// <summary>
        /// Install the Certificate
        /// </summary>
        public static void InstallCertificate(string filePath, StoreName storename, StoreLocation storeLocation, string password)
        {

            X509Certificate2 certificate = new X509Certificate2(filePath, password);
            X509Store store = new X509Store(storename, storeLocation);
            store.Open(OpenFlags.ReadWrite);
            //store.Certificates
            store.Add(certificate);
            store.Close();

        }

        //public static void CreateNewCertificate(Certificate certificate)
        //{

        //    try
        //    {

        //        if (!string.IsNullOrEmpty(certificate.DisplayName) && !string.IsNullOrEmpty(certificate.Organisation))
        //        {

        //            //Get Certificate display Content
        //            string content = "CN=" + certificate.DisplayName;
        //            if (string.IsNullOrEmpty(certificate.FullName))
        //                content = "DN=" + certificate.FullName;
        //            if (string.IsNullOrEmpty(certificate.Title))
        //                content = "T=" + certificate.Title;
        //            if (string.IsNullOrEmpty(certificate.FirstName))
        //                content = "G=" + certificate.FirstName;
        //            if (string.IsNullOrEmpty(certificate.SecondName))
        //                content = "SN=" + certificate.SecondName;
        //            if (string.IsNullOrEmpty(certificate.Email))
        //                content = "E=" + certificate.Email;
        //            if (string.IsNullOrEmpty(certificate.Country))
        //                content = "C=" + certificate.Country;
        //            if (string.IsNullOrEmpty(certificate.Place))
        //                content = "L=" + certificate.Place;
        //            if (string.IsNullOrEmpty(certificate.Street))
        //                content = "street=" + certificate.Street;
        //            if (string.IsNullOrEmpty(certificate.Organisation))
        //                content = "O=" + certificate.Organisation;

        //            //Create Certificate
        //            //var ecdsa = ECDsa.Create(); // generate asymmetric key pair
        //            //var req = new CertificateRequest(content, ecdsa, HashAlgorithmName.SHA256);
        //            var req = new CertificateRequest(content, RSA.Create(2048), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        //            //https://stackoverflow.com/questions/48196350/generate-and-sign-certificate-request-using-pure-net-framework
        //            req.CertificateExtensions.Add(
        //     new X509BasicConstraintsExtension(false, false, 0, false));

        //            req.CertificateExtensions.Add(
        //   new X509EnhancedKeyUsageExtension(
        //       new OidCollection
        //       {
        //                    //http://javadoc.iaik.tugraz.at/iaik_jce/current/iaik/x509/extensions/ExtendedKeyUsage.html
        //                    new Oid("1.3.6.1.5.5.7.3.1"),  // TLS Server auth
        //                    new Oid("1.3.6.1.5.5.7.3.2"),  // TLS Client auth
        //                    //new Oid("1.3.6.1.5.5.7.3.3"), //Code Sign
        //                    //emailProtection (1.3.6.1.5.5.7.3.4)
        //                    //timeStamping (1.3.6.1.5.5.7.3.8)
        //                    //ocspSigning (1.3.6.1.5.5.7.3.9)
        //                    //ipsecEndSystem (1.3.6.1.5.5.7.3.5)
        //                    //ipsecTunnel (1.3.6.1.5.5.7.3.6)
        //                    //ipsecUser (1.3.6.1.5.5.7.3.7)
        //                },
        //       true));

        //            //var a = new X509ChainPolicy();
        //            //    a.VerificationFlags = X509VerificationFlags.AllFlags;
        //            //a.RevocationFlag = X509RevocationFlag.EndCertificateOnly;
        //            //req.CertificateExtensions.Add(new X509ExtensionCollection(a));

        //            req.CertificateExtensions.Add(
        //                new X509KeyUsageExtension(
        //                    X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation,
        //                    false));

        //            req.CertificateExtensions.Add(
        //   new X509SubjectKeyIdentifierExtension(req.PublicKey, false));


        //            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(1));

        //            if (certificate.Duration_Days == 0 && certificate.Duration_Months == 0 && certificate.Duration_Years == 0)
        //                cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(100));

        //            if (certificate.Duration_Days != 0)
        //                cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(certificate.Duration_Days));
        //            else if (certificate.Duration_Months != 0)
        //                cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddMonths(certificate.Duration_Months));
        //            else if (certificate.Duration_Years != 0)
        //                cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(certificate.Duration_Years));

        //            if (string.IsNullOrEmpty(certificate.Password))
        //            {

        //                if (certificate.CertType == CertificateType.CER)
        //                    File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Cert));
        //                else if (certificate.CertType == CertificateType.PFX)
        //                    File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Pfx));
        //                else
        //                    File.WriteAllBytes(savePath + certificate.DisplayName + ".snk", cert.Export(X509ContentType.Pfx));

        //            }
        //            else
        //            {
        //                if (certificate.CertType == CertificateType.CER)
        //                    File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Cert, certificate.Password));
        //                else if (certificate.CertType == CertificateType.PFX)
        //                    File.WriteAllBytes(savePath + certificate.DisplayName + "." + certificate.CertType.ToString().ToLower(), cert.Export(X509ContentType.Pfx, certificate.Password));
        //            }

        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }

        //}

    }

}
