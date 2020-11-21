using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ZeroSys.Manager.Web
{
    /// <summary>
    /// WebRequestManager
    /// </summary>
    public class WebRequestManager
    {

        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Send Post Request to Webside
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        public static async void Post(string url, Dictionary<string, string> content)
        {
            //var values = new Dictionary<string, string> { { "thing1", "hello" }, { "thing2", "world" } };

            var response = await client.PostAsync(url, new FormUrlEncodedContent(content));

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }

        /// <summary>
        /// Send post Request to Webside
        /// </summary>
        /// <param name="url"></param>
        public static async void GET(string url)
        {
            var responseString = await client.GetStringAsync(url);
            Console.WriteLine(responseString);
        }

        //tojson?
        //toxml?
        //was bekomme ich überhaubt von dem...?

    }
}
