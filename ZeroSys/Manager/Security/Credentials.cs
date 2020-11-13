using Meziantou.Framework.Win32;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Credentials Manager          *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Manager.Security
{
    /// <summary>
    /// Windows Credentials Manager
    /// </summary>
    public class Credentials
    {

        /// <summary>
        /// Create a New Windows Credential
        /// </summary>
        public static void CreateCredential(string credentialName, string userName, string password, string comment)
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
        public static void DeleteCredential(string credentialName)
        {
            CredentialManager.DeleteCredential(applicationName: credentialName);
        }

        /// <summary>
        /// Get an existing Windows Credential
        /// </summary>
        /// <param name="credentialName"></param>
        /// <returns></returns>
        public static (string, string) getCredentials(string credentialName)
        {
            var cred = CredentialManager.ReadCredential(applicationName: credentialName);
            if (cred != null)
                return (cred.UserName, cred.Password);
            return (null, null);
        }

    }
}
