using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : WhatsApp Controller          *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Azure.Twilo
{
    /// <summary>
    /// WhatsApp Messages Controll
    /// </summary>
    public class WhatsApp
    {

        private static string AccountSID;
        private static string AuthToken;
        private static string FromPhoneNumber;

        /// <summary>
        /// Initialize the API Token and SID From Twilo to
        /// use this WhatsApp Function
        /// </summary>
        /// <param name="accoutSid"></param>
        /// <param name="authToken"></param>
        /// <param name="fromPhoneNumber"></param>
        public static void Initialize(string accoutSid, string authToken, string fromPhoneNumber)
        {
            AccountSID = accoutSid;
            AuthToken = authToken;
            FromPhoneNumber = fromPhoneNumber;
        }

        /// <summary>
        /// Send a Whatsapp Message
        /// </summary>
        /// <param name="content"></param>
        /// <param name="toPhoneNumber"></param>
        public static void Send(string content, string toPhoneNumber)
        {

            TwilioClient.Init(AccountSID, AuthToken);

            var message = MessageResource.Create(
                body: content,
                from: new Twilio.Types.PhoneNumber("whatsapp:" + FromPhoneNumber),
                to: new Twilio.Types.PhoneNumber("whatsapp:" + toPhoneNumber)
            );

            Console.WriteLine(message.Sid);

        }

    }
}
