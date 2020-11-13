using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZeroSys.Manager
{
    /// <summary>
    /// Manage the Translated Content
    /// </summary>
    public class TranslateManager
    {

        //NICHT FERTIG!
        //PW VON SERVER GRABBEN
        //Translate From To Contente

        private string COGNITIVE_SERVICES_KEY;//PW VON WEBSEITE ANFORDERN... "34bd0a30de8c4fbeb4ef820d8cb67a10"

        private string TEXT_TRANSLATION_API_ENDPOINT;//https://voiceassistent-texttranslation.cognitiveservices.azure.com/translator/text/v3.0/translate?api-version=3.0                           //"https://api.cognitive.microsofttranslator.com/{0}?api-version=3.0";//@"https://voiceassistent-texttranslation.cognitiveservices.azure.com/";

        /// <summary>
        /// Initialize TranslateManager
        /// </summary>
        /// <param name="_COGNITIVE_SERVICES_KEY"></param>
        /// <param name="_TEXT_TRANSLATION_API_ENDPOINT"></param>
        public TranslateManager(string _COGNITIVE_SERVICES_KEY, string _TEXT_TRANSLATION_API_ENDPOINT)
        {
            COGNITIVE_SERVICES_KEY = _COGNITIVE_SERVICES_KEY;
            TEXT_TRANSLATION_API_ENDPOINT = _TEXT_TRANSLATION_API_ENDPOINT;
        }

        /// <summary>
        /// Start the Translation of the Content
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<String> translateText(String content)
        {

            // send HTTP request to perform the translation
            string endpoint = string.Format(TEXT_TRANSLATION_API_ENDPOINT);
            string uri = string.Format(endpoint + "&to={0}", "en");

            Object[] body = new Object[] { new { Text = content } };
            var requestBody = JsonConvert.SerializeObject(body);

            var client = new HttpClient();

            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", COGNITIVE_SERVICES_KEY);
                request.Headers.Add("Ocp-Apim-Subscription-Region", "westeu");

                Console.WriteLine(Guid.NewGuid().ToString());
                Console.WriteLine(request.RequestUri.ToString());

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<Dictionary<string, List<Dictionary<string, string>>>>>(responseBody);
                var translation = result[0]["translations"][0]["text"];

                return translation;
            }
        }

    }
}
