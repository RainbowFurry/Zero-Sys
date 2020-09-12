using System.Collections.Generic;
using System.Management;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get RAM Info                 *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemControll.Hardware
{
    /// <summary>
    /// Get RAM Information
    /// </summary>
    public class Ram
    {

        //Nicht Fertig ! Umrechnen in GB

        private static readonly ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
        private static readonly ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
        private static Dictionary<string, string> ramInformation = new Dictionary<string, string>();

        /// <summary>
        /// Get the Complete Information about your RAM
        /// </summary>
        /// <returns></returns>
        public static void GetRAMInformation()
        {

            Dictionary<string, string> ram = new Dictionary<string, string>();

            foreach (ManagementObject obj in searcher.Get())
            {
                ram.Add("TotalVisibleMemorySize", obj["TotalVisibleMemorySize"].ToString());
                ram.Add("FreePhysicalMemory", obj["FreePhysicalMemory"].ToString());
                ram.Add("TotalVirtualMemorySize", obj["TotalVirtualMemorySize"].ToString());
                ram.Add("FreeVirtualMemory", obj["FreeVirtualMemory"].ToString());
            }

        }

        /// <summary>
        /// Get a specific Value of your RAM
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetRAMValue(string Value)
        {
            if (ramInformation.ContainsKey(Value))
                return ramInformation[Value];
            else
            {
                foreach (ManagementObject obj in searcher.Get())
                    ramInformation.Add(Value, obj[Value].ToString());
                return ramInformation[Value];
            }
        }

        /// <summary>
        /// RAM Values to get from RAM
        /// </summary>
        public class RAMValues
        {
            public static string TotalVisibleMemorySize { get { return "TotalVisibleMemorySize"; } }
            public string FreePhysicalMemory { get { return "FreePhysicalMemory"; } }
            public string TotalVirtualMemorySize { get { return "TotalVirtualMemorySize"; } }
            public string FreeVirtualMemory { get { return "FreeVirtualMemory"; } }
        }

    }
}
