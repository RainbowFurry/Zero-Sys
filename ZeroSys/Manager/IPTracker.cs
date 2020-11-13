using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Track User IP Location       *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Manager
{
    /// <summary>
    /// Track User IP Location
    /// </summary>
    public class IPTracker
    {

        /// <summary>
        /// Track the IP of the Client/User
        /// </summary>
        public static void TrackIP()
        {

            IpInfo ipInfo = new IpInfo();
            string info = new WebClient().DownloadString("http://ipinfo.io/");
            ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
            RegionInfo myRI1 = new RegionInfo(IpInfo.Country);
            IpInfo.Country = myRI1.EnglishName;

            String[] lol = IpInfo.Loc.Split(',');
            IpInfo.Lat = lol[0];
            IpInfo.Lng = lol[1];

        }

        /// <summary>
        /// IpInfo Model
        /// </summary>
        public class IpInfo
        {

            [JsonProperty("ip")]
            public static string Ip { get; set; }

            [JsonProperty("hostname")]
            public static string Hostname { get; set; }

            [JsonProperty("city")]
            public static string City { get; set; }

            [JsonProperty("region")]
            public static string Region { get; set; }

            [JsonProperty("country")]
            public static string Country { get; set; }

            [JsonProperty("loc")]
            public static string Loc { get; set; }

            [JsonProperty("org")]
            public static string Org { get; set; }

            [JsonProperty("postal")]
            public static string Postal { get; set; }

            [JsonProperty("lat")]
            public static string Lat { get; set; }
            [JsonProperty("lng")]
            public static string Lng { get; set; }
        }

    }
}
