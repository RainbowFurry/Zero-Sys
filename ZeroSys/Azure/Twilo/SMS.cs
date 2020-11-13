using Twilio;
using Twilio.Rest.Api.V2010.Account;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : SMS Controller               *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Azure.Twilo
{
    /// <summary>
    /// SMS Controller
    /// </summary>
    public class SMS
    {

        private static string AccountSid;
        private static string AuthToken;
        private static string FromPhoneNumber;

        /// <summary>
        /// Initialize the API Token and SID From Twilo to
        /// use this SMS Function
        /// </summary>
        /// <param name="accoutSid"></param>
        /// <param name="authToken"></param>
        /// <param name="fromPhoneNumber"></param>
        public SMS(string accoutSid, string authToken, string fromPhoneNumber)
        {
            AccountSid = accoutSid;
            AuthToken = authToken;
            FromPhoneNumber = fromPhoneNumber;
        }

        /// <summary>
        /// Send a SMS with Twilo
        /// </summary>
        /// <param name="content"></param>
        /// <param name="toPhoneNumber"></param>
        public void Send(string content, string toPhoneNumber)
        {

            TwilioClient.Init(AccountSid, AuthToken);

            var message = MessageResource.Create(
                body: content,
                from: new Twilio.Types.PhoneNumber(FromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );

            //Console.WriteLine(message.Sid);

        }

    }
}
