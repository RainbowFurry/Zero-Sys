using Meziantou.Framework.Win32;
using System;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Credentials Manager          *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Manager
{
    /// <summary>
    /// Windows Credentials Manager
    /// </summary>
    public class Credentials
    {

        /// <summary>
        /// Create a New Windows Credential
        /// </summary>
        public static void addCredentials(string credentialName, string userName, string password, string comment)
        {

            CredentialManager.WriteCredential(
              applicationName: credentialName,
              userName: userName,
              secret: password,
              comment: comment,
              persistence: CredentialPersistence.LocalMachine
            );

        }

        /// <summary>
        /// Remove an existing Windows Credential
        /// </summary>
        /// <param name="credentialName"></param>
        public static void removeCredentials(string credentialName)
        {
            CredentialManager.DeleteCredential(applicationName: credentialName);
        }

        /// <summary>
        /// Get an existing Windows Credential
        /// </summary>
        /// <param name="credentialName"></param>
        /// <returns></returns>
        public static string[] getCredentials(string credentialName)
        {

            var cred = CredentialManager.ReadCredential(applicationName: credentialName);

            String[] userCredentials = { cred.UserName, cred.Password };

            return userCredentials;

        }

    }
}
