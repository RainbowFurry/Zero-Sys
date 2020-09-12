using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Mail Controller              *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Azure.SendGrid
{
    /// <summary>
    /// Mail Controller
    /// </summary>
    public class Mail
    {

        private static string APIKey;
        private static string FromEmail;
        private static string FromUserName;

        /// <summary>
        /// Initialize the Email Function once with the default Settings
        /// </summary>
        /// <param name="apiKey">The API Key you need for SendGrid</param>
        /// <param name="fromEmail">The Email you use to send the Email</param>
        /// <param name="fromUserName">The UserName of the Email Account you use to send the Mail</param>
        public static void Initialize(string apiKey, string fromEmail, string fromUserName)
        {
            APIKey = apiKey;
            FromEmail = fromEmail;
            FromUserName = fromUserName;
        }

        /// <summary>
        /// Send an Email to the Client
        /// </summary>
        /// <param name="subject">The Heading/Subject/Topic of the Mail</param>
        /// <param name="toEmail">The Email of the User which should get the Email</param>
        /// <param name="toUserName">The User's Name</param>
        /// <param name="contetn">Your Email Content you want to send to the User</param>
        /// <param name="html">KP</param>
        /// <returns></returns>
        public static async Task send(string subject, string toEmail, string toUserName, string contetn, string html)
        {

            if (APIKey != null)
            {
                var ApiKey = Environment.GetEnvironmentVariable(APIKey);
                var Client = new SendGridClient(ApiKey);
                var From = new EmailAddress(FromEmail, FromUserName);

                var Subject = subject;
                var To = new EmailAddress(toEmail, toUserName);
                var PlainTextContent = contetn;
                var HtmlContent = html;

                var msg = MailHelper.CreateSingleEmail(From, To, Subject, PlainTextContent, HtmlContent);
                var response = await Client.SendEmailAsync(msg);
            }

        }

    }
}
