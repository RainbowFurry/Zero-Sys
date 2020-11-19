using System.Collections.Generic;
using System.Management;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get Microphone Info          *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemControll.Hardware
{
    /// <summary>
    /// Get Microphone Information
    /// </summary>
    public class Microphone
    {

        private static readonly ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"Select * From Win32_SoundDevice");
        private static Dictionary<string, string> microphoneInformation = new Dictionary<string, string>();

        /// <summary>
        /// Get the Complete Information about your Microphone
        /// </summary>
        /// <returns></returns>
        public static void GetMicroponeInformation()
        {

            Dictionary<string, string> microphone = new Dictionary<string, string>();

            foreach (ManagementObject obj in searcher.Get())
            {
                microphone.Add("Name", obj["Name"].ToString());
                microphone.Add("ProductName", obj["ProductName"].ToString());
                microphone.Add("Availability", obj["Availability"].ToString());
                microphone.Add("DeviceID", obj["DeviceID"].ToString());
                microphone.Add("PowerManagementSupported", obj["PowerManagementSupported"].ToString());
                microphone.Add("Status", obj["Status"].ToString());
                microphone.Add("StatusInfo", obj["StatusInfo"].ToString());
            }

        }

        /// <summary>
        /// Get a specific Value of your Microphone
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetMicrophoneValue(string Value)
        {

            if (microphoneInformation.ContainsKey(Value))
                return microphoneInformation[Value];
            else
            {
                foreach (ManagementObject obj in searcher.Get())
                    microphoneInformation.Add(Value, obj[Value].ToString());
                return microphoneInformation[Value];
            }

        }

        /// <summary>
        /// Microphone Values to get from Microphone
        /// </summary>
        public class MicrophoneValues
        {
            public static string Name { get { return "Name"; } }
            public string ProductName { get { return "ProductName"; } }
            public string Availability { get { return "Availability"; } }
            public string DeviceID { get { return "DeviceID"; } }
            public string PowerManagementSupported { get { return "PowerManagementSupported"; } }
            public string Status { get { return "Status"; } }
            public string StatusInfo { get { return "StatusInfo"; } }
        }

    }
}
