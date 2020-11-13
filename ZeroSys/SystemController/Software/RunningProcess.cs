using System.Collections.Generic;
using System.Diagnostics;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Get Running Process Info     *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.SystemController.Software
{
    /// <summary>
    /// Get Running Process Information
    /// </summary>
    public class RunningProcess
    {

        //Process.GetProcesses(Environment.MachineName);
        //Process[] remoteByName = Process.GetProcessesByName("notepad", Environment.MachineName);//get all processe from notepad
        private static readonly Process[] processes = Process.GetProcesses();

        /// <summary>
        /// Get the Complete Information about your Process
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetProcessInformation()
        {

            Dictionary<string, string> process = new Dictionary<string, string>();

            for (int i = 0; i < processes.Length; i++)
            {
                process.Add("Name", processes[i].ProcessName);
                process.Add("ID", processes[i].Id.ToString());
                process.Add("Title", processes[i].MainWindowTitle);
                process.Add("StartInfo", processes[i].StartInfo.FileName);
                process.Add("BasePriority", processes[i].BasePriority.ToString());
                process.Add("VRam", processes[i].VirtualMemorySize64.ToString());
                process.Add("Threads", processes[i].Threads.Count.ToString());
                process.Add("SessionID", processes[i].SessionId.ToString());
            }

            return process;
        }

        /// <summary>
        /// Process Values to get from System
        /// </summary>
        public class ProcessValues
        {
            public static string Name { get { return "Name"; } }
            public string ID { get { return "ID"; } }
            public string WindowTitle { get { return "WindowTitle"; } }
            public string StartInfo { get { return "StartInfo"; } }
            public string BasePriority { get { return "BasePriority"; } }
            public string VRam { get { return "VRam"; } }
            public string Threads { get { return "Threads"; } }
            public string SessionID { get { return "SessionID"; } }
        }

    }
}
