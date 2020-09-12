using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using ZeroSys.Manager;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get Weather Information      *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.API
{
    /// <summary>
    /// Weather Information
    /// </summary>
    public class Weather
    {

        //ICONS: - https://openweathermap.org/weather-conditions

        /// <summary>
        /// Get the Weather Information by the Users current GeoLocation
        /// </summary>
        public static void getWeatherWithGeoLocation(string filePath)
        {

            IPTracker.TrackIP();

            WebClient webClient = new WebClient();
            webClient.DownloadFile(@"https://api.openweathermap.org/data/2.5/weather?lat=" + IPTracker.IpInfo.Lat + "&lon=" + IPTracker.IpInfo.Lng + "&units=metric&apikey=bb3d887e7c1f4952de3e58319bf1410a", filePath);

            StreamReader streamReader = new StreamReader(filePath);
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);
            Weather.Info.temp = obj["main"]["temp"].ToString();
            Weather.Info.tempMin = obj["main"]["temp_min"].ToString();
            Weather.Info.tempMax = obj["main"]["temp_max"].ToString();
            Weather.Info.cityName = obj["name"].ToString();
            Weather.Info.iconID = obj["weather"][0]["icon"].ToString();
            Weather.Info.clouds = obj["clouds"]["all"].ToString();
            Weather.Info.wind = obj["wind"]["speed"].ToString();
            Weather.Info.weather = obj["weather"][0]["description"].ToString();

        }

        /// <summary>
        /// Get the Weather Information by the Users current GeoLocation
        /// </summary>
        public static void getWeatherWithGeoLocation(string Lat, string Lng, string filePath)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadFile(@"https://api.openweathermap.org/data/2.5/weather?lat=" + Lat + "&lon=" + Lng + "&units=metric&apikey=bb3d887e7c1f4952de3e58319bf1410a", filePath);

            StreamReader streamReader = new StreamReader(filePath);
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);
            Weather.Info.temp = obj["main"]["temp"].ToString();
            Weather.Info.tempMin = obj["main"]["temp_min"].ToString();
            Weather.Info.tempMax = obj["main"]["temp_max"].ToString();
            Weather.Info.cityName = obj["name"].ToString();
            Weather.Info.iconID = obj["weather"][0]["icon"].ToString();
            Weather.Info.clouds = obj["clouds"]["all"].ToString();
            Weather.Info.wind = obj["wind"]["speed"].ToString();
            Weather.Info.weather = obj["weather"][0]["description"].ToString();

        }

        /// <summary>
        /// Get the Weather Information of the given ZipCode City
        /// </summary>
        /// <param name="zipCode">The ZipCode of the searching City Info</param>
        public static void getWeatherWithZipCode(String zipCode, string filePath)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadFile(@"https://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",de&units=metric&apikey=bb3d887e7c1f4952de3e58319bf1410a", filePath);

            StreamReader streamReader = new StreamReader(filePath);
            string json = streamReader.ReadToEnd();

            JObject obj = JObject.Parse(json);
            Weather.Info.temp = obj["main"]["temp"].ToString();
            Weather.Info.tempMin = obj["main"]["temp_min"].ToString();
            Weather.Info.tempMax = obj["main"]["temp_max"].ToString();
            Weather.Info.cityName = obj["name"].ToString();
            Weather.Info.iconID = obj["weather"]["icon"].ToString();
            Weather.Info.wind = obj["wind"]["speed"].ToString();
            Weather.Info.weather = obj["weather"][0]["description"].ToString();

        }

        /// <summary>
        /// Weather Values
        /// </summary>
        public struct Info
        {
            public static String temp;//temp
            public static String tempMin;//min temp
            public static String tempMax;//max temp
            public static String cityName;//city Name
            public static String weather;// sun/rain etc
            public static String wind;//wind strength
            public static String iconID;//Image ID
            public static String clouds;
        }

    }
}
