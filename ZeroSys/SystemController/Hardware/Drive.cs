using System;
using System.Collections.Generic;
using System.Management;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get Drive Info               *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemController.Hardware
{
    /// <summary>
    /// Get Drive Information
    /// </summary>
    public class Drive
    {

        private ConnectionOptions oConn;
        private ManagementScope oMs;
        private ObjectQuery oQuery;
        private readonly ManagementObjectSearcher searcher;
        private static ManagementObjectCollection oReturnCollection;

        /// <summary>
        /// Get Drive Information
        /// </summary>
        public Drive()
        {
            oConn = new ConnectionOptions();
            oMs = new ManagementScope("\\\\localhost", oConn);
            oQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            searcher = new ManagementObjectSearcher(oMs, oQuery);
            oReturnCollection = searcher.Get();
        }

        /// <summary>
        /// Get the Complete Information about your Drive's
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetDriveInformation()
        {

            Dictionary<string, string> storage = new Dictionary<string, string>();

            long mb = 1073741824; //megabyte in # of bytes 1024x1024x1024

            //variables for numerical conversions
            double fs = 0;
            double us = 0;
            double tot = 0;
            double up = 0;
            double fp = 0;

            //for string formating args
            object[] oArgs = new object[2];

            //loop through found drives and write out info
            foreach (ManagementObject oReturn in oReturnCollection)
            {
                // Disk name
                storage.Add("Name", oReturn["Name"].ToString());

                //Free space in MB
                fs = Convert.ToInt64(oReturn["FreeSpace"]) / mb;

                //Used space in MB
                us = (Convert.ToInt64(oReturn["Size"]) - Convert.ToInt64(oReturn["FreeSpace"])) / mb;

                //Total space in MB
                tot = Convert.ToInt64(oReturn["Size"]) / mb;

                //used percentage
                up = us / tot * 100;

                //free percentage
                fp = fs / tot * 100;

                //used space args
                oArgs[0] = us;
                oArgs[1] = up;

                //write out used space stats
                //Console.WriteLine("Used: {0:#,###.##} GB ({1:###.##})%", oArgs);
                storage.Add("Used", oArgs[0] + " GB " + oArgs[1] + "%");

                //free space args
                oArgs[0] = fs;
                oArgs[1] = fp;

                //write out free space stats
                storage.Add("Free", oArgs[0] + " GB " + oArgs[1] + "%");
                storage.Add("Size", tot + "GB");
            }

            return storage;

        }

        /// <summary>
        /// Get a specific Value of your Drive
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static void GetDriveValue(string Value)
        {

        }

        /// <summary>
        /// Drive Values to get from Drive
        /// </summary>
        public class DriveValues
        {
            public static string Name { get { return "Name"; } }
            public string FreeSpace { get { return "FreeSpace"; } }
            public string Size { get { return "Size"; } }
            public string UsedSpace { get { return "Size"; } }//muss ich selber berechnen..
        }

    }
}
