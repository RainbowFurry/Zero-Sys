using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get CPU Info                 *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemControll.Hardware
{

    /// <summary>
    /// Get CPU Information
    /// </summary>
    public class Cpu
    {

        private static readonly ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");
        private static PerformanceCounter CPUCore = new PerformanceCounter("Processor", "% Processor Time", "0");
        private static Dictionary<string, string> cpuInformation = new Dictionary<string, string>();

        /// <summary>
        /// Get the Complete Information about your CPU
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetCPUInformation()
        {

            Dictionary<string, string> cpu = new Dictionary<string, string>();

            foreach (ManagementObject obj in searcher.Get())
            {
                cpu.Add("Name", obj["Name"].ToString());
                cpu.Add("DeviceID", obj["DeviceID"].ToString());
                cpu.Add("Manufacturer", obj["Manufacturer"].ToString());
                cpu.Add("CurrentClockSpeed", obj["CurrentClockSpeed"].ToString());
                cpu.Add("Caption", obj["Caption"].ToString());
                cpu.Add("NumberOfCores", obj["NumberOfCores"].ToString());
                cpu.Add("NumberOfEnabledCore", obj["NumberOfEnabledCore"].ToString());
                cpu.Add("NumberOfLogicalProcessors", obj["NumberOfLogicalProcessors"].ToString());
                cpu.Add("Architecture", obj["Architecture"].ToString());
                cpu.Add("Family", obj["Family"].ToString());
                cpu.Add("ProcessorType", obj["ProcessorType"].ToString());
                cpu.Add("Characteristics", obj["Characteristics"].ToString());
                cpu.Add("AddressWidth", obj["AddressWidth"].ToString());
            }

            return cpu;
        }

        /// <summary>
        /// Get a specific Value of your CPU
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetCPUValue(string Value)
        {
            if (cpuInformation.ContainsKey(Value))
                return cpuInformation[Value];
            else
            {
                foreach (ManagementObject obj in searcher.Get())
                    cpuInformation.Add(Value, obj[Value].ToString());
                return cpuInformation[Value];
            }
        }

        /// <summary>
        /// Get all Cores and there Workload
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllCores()
        {

            Dictionary<string, string> cores = new Dictionary<string, string>();
            int coreAmount = 0;

            foreach (ManagementObject obj in searcher.Get())
            {
                coreAmount = (int)obj["NumberOfCores"];
            }

            for (int i = 0; i < coreAmount; i++)
            {
                CPUCore = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
                cores.Add(i.ToString(), CPUCore.NextValue().ToString("0.00"));
            }
            return cores;
        }

        /// <summary>
        /// Get single Core and his Workload
        /// </summary>
        /// <param name="coreNumber"></param>
        /// <returns></returns>
        public static string GetSingleCore(int coreNumber)
        {
            CPUCore = new PerformanceCounter("Processor", "% Processor Time", coreNumber.ToString());
            return CPUCore.NextValue().ToString("0.00");
        }

        /// <summary>
        /// CPU Values to get from CPU
        /// </summary>
        public class CPUValues
        {
            public static string Name { get { return "Name"; } }
            public string Manufacturer { get { return "Manufacturer"; } }
            public string Caption { get { return "Caption"; } }
            public string DeviceID { get { return "DeviceID"; } }
            public string CurrentClockSpeed { get { return "CurrentClockSpeed"; } }
            public string NumberOfCores { get { return "NumberOfCores"; } }
            public string NumberOfEnabledCore { get { return "NumberOfEnabledCore"; } }
            public string NumberOfLogicalProcessors { get { return "NumberOfLogicalProcessors"; } }
            public string Architecture { get { return "Architecture"; } }
            public string Family { get { return "Family"; } }
            public string ProcessorType { get { return "ProcessorType"; } }
            public string Characteristics { get { return "Characteristics"; } }
            public string AddressWidth { get { return "AddressWidth"; } }
        }

    }
}
