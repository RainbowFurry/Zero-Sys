using System;
using System.Net;
using System.Text.RegularExpressions;

namespace ZeroSys.Manager
{
    /// <summary>
    /// IsValid
    /// </summary>
    public class IsValid
    {

        /// <summary>
        /// Is the Mail Address Valid?
        /// </summary>
        /// <param name="MailAddress"></param>
        /// <returns></returns>
        public static bool MailAddress(String MailAddress)
        {
            // var foo = new EmailAddressAttribute();
            //if (new EmailAddressAttribute().IsValid("someone@somewhere.com"))

            return Regex.IsMatch(MailAddress, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }

        //        using System.ComponentModel.DataAnnotations;
        //public bool IsValidEmail(string source)
        //    {
        //        return new EmailAddressAttribute().IsValid(source);
        //    }

        /// <summary>
        /// Is the Phone-Number Valid?
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool PhoneNumber(string number)
        {
            //return Regex.Match(number, @"^([\+]?61[-]?|[0])?[1-9][0-9]{8}$").Success;
            return Regex.Match(number, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").Success;
        }

        /// <summary>
        /// Is IP Valid?
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool Ip(string ipAddress)
        {
            IPAddress ip;
            bool ValidateIP = IPAddress.TryParse(ipAddress, out ip);
            return ValidateIP;
        }

        /// <summary>
        /// Is URL Valid?
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool URL(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            //bool result = Regex.IsMatch(url, @"(http|https)://(([www\.])?|([\da-z-\.]+))\.([a-z\.]{2,3})$");
            return result;
        }

    }
}
