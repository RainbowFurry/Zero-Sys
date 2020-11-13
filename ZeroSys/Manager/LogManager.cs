using System;
using System.Collections.Generic;
using System.IO;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Log File Manager             *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Manager
{
   /// <summary>
   /// Log File Manager
   /// </summary>
   public class LogManager
   {

      private static string save_path = AppDomain.CurrentDomain.BaseDirectory + @"\Log\";

      /// <summary>
      /// Set the Log File Path
      /// </summary>
      /// <param name="logPath"></param>
      public static void SetLogPath(string logPath)
      {
         save_path = logPath;
      }

      /// <summary>
      ///  Create a daily Logfile if not exist and add new Message
      /// </summary>
      /// <param name="logType"></param>
      /// <param name="logMessage"></param>
      /// <param name="priority"></param>
      public static void AddLogEntrence(LogType logType, String logMessage, int priority)
      {

         //create logfile if not exist with given name
         if (!Directory.Exists(save_path))
         {
            Directory.CreateDirectory(save_path);
         }

         string logBody = "[" + DateTime.Now.ToLongDateString() + "][" + DateTime.Now.ToLongTimeString() + "][" + logType.ToString() + "][" + priority + "] " + logMessage + "\n";

         File.AppendAllText(save_path + DateTime.Now.ToLongDateString() + ".txt", logBody);

         ConsoleLog(logType, logBody);
         //WebLog(logType, logBody);

      }

      /// <summary>
      /// Add Exeption output to the User Log File
      /// </summary>
      /// <param name="exception"></param>
      public static void AddLogExeptionEntrence(Exception exception)
      {

         String errorMessage = "\nAn Exeption occured:\n" +
                          "[Message] - " + exception.Message + "\n" +
                          "[Source] - " + exception.Source + "\n" +
                          "[Help] - " + exception.HelpLink + "\n" +
                          "[Data] - " + exception.Data + "\n\n";

         AddLogEntrence(LogType.Error, errorMessage, 99);

      }

      /// <summary>
      /// Generate a HTML Web Log File
      /// This File gives the Logs in a nice Marked Color
      /// </summary>
      /// <param name="logType"></param>
      /// <param name="content"></param>
      private static void WebLog(LogType logType, string content)
      {

         List<string> txtLines = new List<string>();

         //create logfile if not exist with given name
         if (!Directory.Exists(save_path))
         {
            Directory.CreateDirectory(save_path);
         }

         if (!File.Exists(save_path + "Dev_" + DateTime.Now.ToLongDateString() + ".html"))
         {

            File.WriteAllText("Test.htm", @"<html>");
            File.WriteAllText("Test.htm", @"<head>");
            File.WriteAllText("Test.htm", @"</head>");
            File.WriteAllText("Test.htm", @"<body>");
            File.WriteAllText("Test.htm", @"</body>");
            File.WriteAllText("Test.htm", @"</html>");

         }

         foreach (string s in File.ReadAllLines(save_path + "Dev_" + DateTime.Now.ToLongDateString() + ".html"))
         {
            txtLines.Add(s);
         }

         switch (logType)
         {

            case LogType.Info:
               txtLines.Insert(txtLines.IndexOf("</body>"), "<p style='color:DodgerBlue;'>" + content + "</p>");
               break;

            case LogType.Warning:
               txtLines.Insert(txtLines.IndexOf("</body>"), "<p style='color:Yellow;'>" + content + "</p>");
               break;

            case LogType.Fatal:
               txtLines.Insert(txtLines.IndexOf("</body>"), "<p style='color:DarkRed;'>" + content + "</p>");
               break;

            case LogType.Error:
               txtLines.Insert(txtLines.IndexOf("</body>"), "<p style='color:Red;'>" + content + "</p>");
               break;

         }

         File.WriteAllLines(save_path + "Dev_" + DateTime.Now.ToLongDateString() + ".html", txtLines);

      }

      /// <summary>
      /// Print the Log to the Console with Color
      /// </summary>
      /// <param name="logType"></param>
      /// <param name="content"></param>
      private static void ConsoleLog(LogType logType, string content)
      {

         switch (logType)
         {

            case LogType.Info:
               Console.ForegroundColor = ConsoleColor.Blue;
               break;

            case LogType.Warning:
               Console.ForegroundColor = ConsoleColor.Yellow;
               break;

            case LogType.Error:
               Console.ForegroundColor = ConsoleColor.Red;
               break;

            case LogType.Fatal:
               Console.ForegroundColor = ConsoleColor.DarkRed;
               break;

            case LogType.Debug:
               Console.ForegroundColor = ConsoleColor.Cyan;
               break;

         }

         Console.WriteLine("New Log entrence added ->\n" + content);

      }

   }

   /// <summary>
   /// LogTypes make it easy to refference the Logs
   /// </summary>
   public enum LogType
   {
      Error,
      Warning,
      Log,
      Info,
      Fatal,
      Debug
   }
}
