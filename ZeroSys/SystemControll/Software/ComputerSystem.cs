using System.Collections.Generic;
using System.Management;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get Computer System Info     *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemControll.Software
{
    /// <summary>
    /// Get Computer System Information
    /// </summary>
    public class ComputerSystem
    {

        private static readonly ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
        private static Dictionary<string, string> systemInformation = new Dictionary<string, string>();

        /// <summary>
        /// Get the Complete Information about your System
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetSystemInformation()
        {

            Dictionary<string, string> system = new Dictionary<string, string>();

            foreach (ManagementObject obj in managementObjectSearcher.Get())
            {
                system.Add("Caption", obj["Caption"].ToString());
                system.Add("WindowsDirectory", obj["WindowsDirectory"].ToString());
                system.Add("ProductType", obj["ProductType"].ToString());
                system.Add("SerialNumber", obj["SerialNumber"].ToString());
                system.Add("SystemDirectory", obj["SystemDirectory"].ToString());
                system.Add("CountryCode", obj["CountryCode"].ToString());
                system.Add("CurrentTimeZone", obj["CurrentTimeZone"].ToString());
                system.Add("EncryptionLevel", obj["EncryptionLevel"].ToString());
                system.Add("OSType", obj["OSType"].ToString());
                system.Add("Version", obj["Version"].ToString());
            }

            return system;
        }

        /// <summary>
        /// Get a specific Value of your System
        /// </summary>
        /// <param name="gpuValue"></param>
        /// <returns></returns>
        public static string GetSystemValue(string Value)
        {
            if (systemInformation.ContainsKey(Value))
                return systemInformation[Value];
            else
            {
                foreach (ManagementObject obj in managementObjectSearcher.Get())
                    systemInformation.Add(Value, obj[Value].ToString());
                return systemInformation[Value];
            }
        }

        /// <summary>
        /// System Values to get from System
        /// </summary>
        public class SystemValues
        {
            public static string Caption { get { return "Caption"; } }
            public string WindowsDirectory { get { return "WindowsDirectory"; } }
            public string ProductType { get { return "ProductType"; } }
            public string SerialNumber { get { return "SerialNumber"; } }
            public string SystemDirectory { get { return "SystemDirectory"; } }
            public string CountryCode { get { return "CountryCode"; } }
            public string CurrentTimeZone { get { return "CurrentTimeZone"; } }
            public string EncryptionLevel { get { return "EncryptionLevel"; } }
            public string OSType { get { return "OSType"; } }
            public string Version { get { return "Version"; } }
        }

    }
}
