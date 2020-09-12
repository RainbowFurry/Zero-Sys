using System.Collections.Generic;
using System.Management;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get Printer Info             *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemControll.Hardware
{
    /// <summary>
    /// Get Printer Information
    /// </summary>
    public class Printer
    {

        private static readonly ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"Select * From Win32_Printer");
        private static Dictionary<string, string> printerInformation = new Dictionary<string, string>();

        /// <summary>
        /// Get the Complete Information about your Printer
        /// </summary>
        /// <returns></returns>
        public static void GetPrinterInformation()
        {

            Dictionary<string, string> printer = new Dictionary<string, string>();

            foreach (ManagementObject obj in searcher.Get())
            {
                printer.Add("Name", obj["Name"].ToString());
                printer.Add("Network", obj["Network"].ToString());
                printer.Add("Availability", obj["Availability"].ToString());
                printer.Add("Default", obj["Default"].ToString());
                printer.Add("DeviceID", obj["DeviceID"].ToString());
                printer.Add("Status", obj["Status"].ToString());
            }

        }

        /// <summary>
        /// Get a specific Value of your Printer
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetPrinterValue(string Value)
        {
            if (printerInformation.ContainsKey(Value))
                return printerInformation[Value];
            else
            {
                foreach (ManagementObject obj in searcher.Get())
                    printerInformation.Add(Value, obj[Value].ToString());
                return printerInformation[Value];
            }
        }

        /// <summary>
        /// Printer Values to get from Printer
        /// </summary>
        public class PrinterValues
        {
            public static string Name { get { return "Name"; } }
            public string Network { get { return "Network"; } }
            public string Default { get { return "Default"; } }
            public string DeviceID { get { return "DeviceID"; } }
            public string Status { get { return "Status"; } }
            public string Availability { get { return "Availability"; } }
        }

    }
}
