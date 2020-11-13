using System.Diagnostics;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Document Print Manager       *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Manager
{
    /// <summary>
    /// Document Print Manager
    /// </summary>
    public class PrintDocument
    {

        /// <summary>
        /// Print the selected Document
        /// </summary>
        /// <param name="filePath"></param>
        public static void Print(string filePath)
        {

            ProcessStartInfo info = new ProcessStartInfo(filePath);
            info.Verb = "Print";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);

        }

        /// <summary>
        /// Print the selected Document from Browser
        /// </summary>
        /// <param name="filePath"></param>
        public static void PrintWebRequest(string filePath)
        {

        }

    }
}
