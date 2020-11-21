using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ZeroSys.Azure.Twilo
{
    /// <summary>
    /// Call
    /// </summary>
    public class Call
    {

        private static string AccountSid;
        private static string AuthToken;
        private static string FromPhoneNumber;

        /// <summary>
        /// Initialize Call
        /// </summary>
        /// <param name="accoutSid"></param>
        /// <param name="authToken"></param>
        /// <param name="fromPhoneNumber"></param>
        public Call(string accoutSid, string authToken, string fromPhoneNumber)
        {
            AccountSid = accoutSid;
            AuthToken = authToken;
            FromPhoneNumber = fromPhoneNumber;
        }

        /// <summary>
        /// Create a Phone call and let the KI Talk
        /// </summary>
        /// <param name="toPhoneNumber"></param>
        /// <param name="contentToSay"></param>
        public static void CreatePhoneCall(string toPhoneNumber, string contentToSay)
        {

            TwilioClient.Init(AccountSid, AuthToken);

            var call = CallResource.Create(
                twiml: new Twilio.Types.Twiml("<Response><Say>" + contentToSay + "</Say></Response>"),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber),
                from: new Twilio.Types.PhoneNumber(FromPhoneNumber)
            );

            //Console.WriteLine(call.Sid);

        }

    }
}
