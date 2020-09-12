using System.Collections.Generic;
using System.Management;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get USB Info                 *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemControll.Hardware
{
    /// <summary>
    /// Get USB Information
    /// </summary>
    public class Usb
    {

        private static readonly ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub");
        private static Dictionary<string, string> usbInformation = new Dictionary<string, string>();


        /// <summary>
        /// Get the Complete Information about your USB's
        /// </summary>
        /// <returns></returns>
        public static void GetUSBInformation()
        {

            Dictionary<string, string> usb = new Dictionary<string, string>();

            ManagementObjectCollection collection;
            collection = managementObjectSearcher.Get();

            foreach (var device in collection)
            {
                usb.Add("DeviceID", device["DeviceID"].ToString());
                usb.Add("PNPDeviceID", device["PNPDeviceID"].ToString());
                usb.Add("Description", device["Description"].ToString());
            }

            collection.Dispose();

        }

        /// <summary>
        /// Get a specific Value of your USB
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetUSBValue(string Value)
        {

            if (usbInformation.ContainsKey(Value))
                return usbInformation[Value];
            else
            {
                foreach (ManagementObject obj in managementObjectSearcher.Get())
                    usbInformation.Add(Value, obj[Value].ToString());
                return usbInformation[Value];
            }

        }

        /// <summary>
        /// USB Values to get from USB
        /// </summary>
        public class USBValues
        {
            public static string DeviceID { get { return "DeviceID"; } }
            public string PNPDeviceID { get { return "PNPDeviceID"; } }
            public string Description { get { return "Description"; } }
        }

    }
}
