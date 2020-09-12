using System;
using System.Net;
using System.Net.Mail;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Mail Manager                 *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Manager
{
    /// <summary>
    /// Mail Manager
    /// </summary>
    public class Mail
    {

        private static String fromEmail;
        private static MailMessage mailMessage;
        private static SmtpClient smtpClient;

        /// <summary>
        /// Initialize the Settings for the Email's
        /// Call once in the Main for initializing
        /// </summary>
        /// <param name="smtp"></param>
        /// <param name="port"></param>
        /// <param name="senderEmail"></param>
        /// <param name="password"></param>
        public static void Initialize(string smtp, int port, string senderEmail, string password)
        {

            if (smtpClient == null)
            {
                fromEmail = senderEmail;

                smtpClient = new SmtpClient(smtp, port);//"smtp.gmail.com", 587
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, password);
            }

        }

        /// <summary>
        /// Send an Email to your Customer
        /// </summary>
        /// <param name="heading"></param>
        /// <param name="content"></param>
        /// <param name="toEmail"></param>
        public static void sendMail(string heading, string content, string toEmail)
        {
            mailMessage = new MailMessage(fromEmail, toEmail, heading, content);
            smtpClient.Send(mailMessage);
        }

    }
}
