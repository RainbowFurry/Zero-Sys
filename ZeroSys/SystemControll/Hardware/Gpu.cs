using System.Collections.Generic;
using System.Management;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get GPU Info                 *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemControll.Hardware
{
    /// <summary>
    /// Get GPU Information
    /// </summary>
    public class Gpu
    {

        private static readonly ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_VideoController");
        private static Dictionary<string, string> gpuInformation = new Dictionary<string, string>();

        /// <summary>
        /// Get the Complete Information about your GPU
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetGPUInformation()
        {

            Dictionary<string, string> gpu = new Dictionary<string, string>();

            foreach (ManagementObject obj in managementObjectSearcher.Get())
            {
                gpu.Add("Name", obj["Name"].ToString());
                gpu.Add("Status", obj["Status"].ToString());
                gpu.Add("Caption", obj["Caption"].ToString());
                gpu.Add("DeviceID", obj["DeviceID"].ToString());
                gpu.Add("AdapterRAM", obj["AdapterRAM"].ToString());
                gpu.Add("AdapterDACType", obj["AdapterDACType"].ToString());
                gpu.Add("DriverVersion", obj["DriverVersion"].ToString());
            }

            //String.Empty.PadLeft(obj["Name"].ToString().Length, '=') + "\n";

            return gpu;
        }

        /// <summary>
        /// Get a specific Value of your GPU
        /// </summary>
        /// <param name="gpuValue"></param>
        /// <returns></returns>
        public static string GetGPUValue(string Value)
        {
            if (gpuInformation.ContainsKey(Value))
                return gpuInformation[Value];
            else
            {
                foreach (ManagementObject obj in managementObjectSearcher.Get())
                    gpuInformation.Add(Value, obj[Value].ToString());
                return gpuInformation[Value];
            }
        }

        /// <summary>
        /// GPU Values to get from GPU
        /// </summary>
        public class GPUValues
        {
            public static string Name { get { return "Name"; } }
            public string Status { get { return "Status"; } }
            public string Caption { get { return "Caption"; } }
            public string DeviceID { get { return "DeviceID"; } }
            public string AdapterRAM { get { return "AdapterRAM"; } }
            public string AdapterDACType { get { return "AdapterDACType"; } }
            public string DriverVersion { get { return "DriverVersion"; } }
        }

    }
}
