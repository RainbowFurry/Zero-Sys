using System.Net;

namespace ZeroSys.Manager.Web
{
    /// <summary>
    /// WebConnectionManager
    /// </summary>
    public class WebConnectionManager
    {

        /// <summary>
        /// Check if Client has Web Connection
        /// </summary>
        /// <returns></returns>
        public static bool CheckConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
