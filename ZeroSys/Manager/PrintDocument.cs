using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows;
using Print = System.Drawing.Printing;

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



        private static System.ComponentModel.Container components;
        private static System.Windows.Forms.Button printButton;
        private static Font printFont;
        private static StreamReader streamToPrint;

        /// <summary>
        /// Print the Selected Document - With Options
        /// </summary>
        /// <param name="filePath"></param>
        public static void PrintDoc(string filePath)
        {

            components = new System.ComponentModel.Container();
            printButton = new System.Windows.Forms.Button();

            try
            {
                streamToPrint = new StreamReader
                   (filePath);
                try
                {
                    printFont = new Font("Arial", 10);
                    Print.PrintDocument pd = new Print.PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(PrintPage);
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // The PrintPage event is raised for each page to be printed.
        private static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

    }
}
