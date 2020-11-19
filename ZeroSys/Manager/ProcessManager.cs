using System;
using System.Diagnostics;

namespace ZeroSys.Manager
{
   /// <summary>
   /// ProcessManager
   /// </summary>
   public class ProcessManager
   {

      /// <summary>
      /// Start new Application Process
      /// </summary>
      /// <param name="processPath"></param>
      /// <param name="showNewWindow"></param>
      public static void StartNewProcess(string processPath, bool showNewWindow)
      {

         Process myProcess = new Process();

         try
         {
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = processPath;
            myProcess.StartInfo.CreateNoWindow = !showNewWindow;
            myProcess.Start();
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
         finally
         {
            myProcess.Kill();
         }

      }

      /// <summary>
      /// Run CMD and enter Command to execute
      /// </summary>
      /// <param name="command"></param>
      public static void StartNewConsoleCommand(string command, bool showWindow)
      {

         Process process = new Process();

         try
         {
            string cmdPath = "CMD.exe";
            //Process.Start(cmdPath, command);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = cmdPath;
            startInfo.CreateNoWindow = !showWindow;
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();

         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
         finally
         {
            process.Close();
         }

      }

      /*
         startInfo.UseShellExecute = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StandardInput.WriteLine("echo Oscar");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
       */

   }
}
