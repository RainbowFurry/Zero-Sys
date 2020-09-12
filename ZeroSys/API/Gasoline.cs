using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get Gasoline Information     *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.API
{
    /// <summary>
    /// Gasoline Information
    /// </summary>
    public class Gasoline
    {

        //INFO : https://creativecommons.tankerkoenig.de/api_register_part2.php?email=darkwolfcraft.net%40gmail.com&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95

        private static WebClient webClient = new WebClient();
        private static Gassolin gassolin = new Gassolin();

        /// <summary>
        /// Load Gasolin Top Price infos
        /// </summary>
        public static void loadTopPrices(string id, string saveFolder)
        {

            if (!File.Exists(saveFolder + "GasolinInfo_" + id + ".json"))
            {
                webClient.DownloadFile("https://creativecommons.tankerkoenig.de/json/prices.php?ids=" + id + "&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95", saveFolder + "GasolinInfo_" + id + ".json");
            }

            StreamReader streamReader = new StreamReader(saveFolder + "GasolinInfo_" + id + ".json");
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);

            try
            {
                gassolin.diesel = obj["prices"][id]["diesel"];//Math.Round(Convert.ToDouble(obj["prices"][id]["diesel"]), 2) + "€";
                gassolin.e5 = obj["prices"][id]["e5"];
                gassolin.e10 = obj["prices"][id]["e10"];
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }

        }

        /// <summary>
        /// Load Gasolin Shop infos
        /// </summary>
        public static void loadGasolineStationInfo(string id, string saveFolder)
        {

            if (!File.Exists(saveFolder + "GasolinInfo_" + id + ".json"))
            {
                webClient.DownloadFile("https://creativecommons.tankerkoenig.de/json/prices.php?ids=" + id + "&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95", saveFolder + "GasolinInfo_" + id + ".json");
            }

            if (id != "" || id != null)
            {
                //Load more info - öffnungszeiten..

                StreamReader streamReader = new StreamReader(saveFolder + "GasolinInfo_" + id + ".json");
                string json = streamReader.ReadToEnd();

                JObject obj = JObject.Parse(json);

                try
                {

                    if (!String.IsNullOrEmpty(obj["prices"][id]["diesel"].ToString()))
                    {
                        gassolin.diesel = obj["prices"][id]["diesel"];
                        gassolin.e5 = obj["prices"][id]["e5"];
                        gassolin.e10 = obj["prices"][id]["e10"];
                    }

                }
                catch (Exception exeption)
                {
                    Console.WriteLine(exeption.Message);
                }
            }

        }

        /// <summary>
        /// Load Location and distanced Shops
        /// </summary>
        public static void loadGasolinPostcode(string Lat, string Lng, string saveFolder)
        {

            webClient.DownloadFile("https://creativecommons.tankerkoenig.de/json/list.php?lat=" + Lat + "&lng=" + Lng + "&rad=10&sort=price&type=diesel&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95", saveFolder + "GasolinPostcode.json");

            StreamReader streamReader = new StreamReader(saveFolder + "GasolinPostcode.json");
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);

            try
            {

                for (int i = 0; i < 15; i++)
                {
                    if (!String.IsNullOrEmpty(obj["stations"][i]["id"].ToString()))
                    {

                        gassolin.id = obj["stations"][i]["id"];
                        gassolin.name = obj["stations"][i]["name"];
                        gassolin.street = obj["stations"][i]["street"];
                        gassolin.place = obj["stations"][i]["place"];
                        gassolin.lat = obj["stations"][i]["lat"];
                        gassolin.lng = obj["stations"][i]["lng"];
                        gassolin.distance = obj["stations"][i]["dist"];
                        gassolin.diesel = obj["stations"][i]["diesel"];
                        gassolin.e5 = obj["stations"][i]["e5"];
                        gassolin.e10 = obj["stations"][i]["e10"];
                        gassolin.isopen = obj["stations"][i]["isOpen"];
                        gassolin.housenumber = obj["stations"][i]["houseNumber"];
                        gassolin.postcode = obj["stations"][i]["postCode"];
                        gassolin.brand = obj["stations"][i]["brand"];

                    }
                }

            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);

            }

        }

        /// <summary>
        /// Load Location and distanced Shops
        /// </summary>
        public static void loadGasolinPostcode(string saveFolder)
        {

            IPTracker.TrackIP();

            webClient.DownloadFile("https://creativecommons.tankerkoenig.de/json/list.php?lat=" + IPTracker.IpInfo.Lat + "&lng=" + IPTracker.IpInfo.Lng + "&rad=10&sort=price&type=diesel&apikey=225eb269-08f1-90c8-6aa2-d580b7f0fe95", saveFolder + "GasolinPostcode.json");

            StreamReader streamReader = new StreamReader(saveFolder + "GasolinPostcode.json");
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);

            try
            {

                for (int i = 0; i < 15; i++)
                {
                    if (!String.IsNullOrEmpty(obj["stations"][i]["id"].ToString()))
                    {

                        gassolin.id = obj["stations"][i]["id"];
                        gassolin.name = obj["stations"][i]["name"];
                        gassolin.street = obj["stations"][i]["street"];
                        gassolin.place = obj["stations"][i]["place"];
                        gassolin.lat = obj["stations"][i]["lat"];
                        gassolin.lng = obj["stations"][i]["lng"];
                        gassolin.distance = obj["stations"][i]["dist"];
                        gassolin.diesel = obj["stations"][i]["diesel"];
                        gassolin.e5 = obj["stations"][i]["e5"];
                        gassolin.e10 = obj["stations"][i]["e10"];
                        gassolin.isopen = obj["stations"][i]["isOpen"];
                        gassolin.housenumber = obj["stations"][i]["houseNumber"];
                        gassolin.postcode = obj["stations"][i]["postCode"];
                        gassolin.brand = obj["stations"][i]["brand"];

                    }
                }

            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);

            }

        }

        /// <summary>
        /// Gasoline Values
        /// </summary>
        public class Gassolin
        {
            public object id { get; set; }
            public object name { get; set; }
            public object street { get; set; }
            public object place { get; set; }
            public object lat { get; set; }
            public object lng { get; set; }
            public object distance { get; set; }
            public object diesel { get; set; }
            public object e5 { get; set; }
            public object e10 { get; set; }
            public object isopen { get; set; }
            public object housenumber { get; set; }
            public object postcode { get; set; }
            public object brand { get; set; }

        }

    }
}
