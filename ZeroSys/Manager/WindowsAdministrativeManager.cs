using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows;

namespace ZeroSys.Manager
{
    /// <summary>
    /// WindowsAdministrativeManager
    /// </summary>
    public class WindowsAdministrativeManager
    {

        /// <summary>
        /// Start Application with Administrativ Rights
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="window"></param>
        public static void StartApplicationAsAdmin(Assembly assembly, Window window)
        {

            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);

            //check for admin rights
            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                //Console.WriteLine(principal.IsInRole(WindowsBuiltInRole.Administrator));

                //Console.WriteLine(WindowsIdentity.GetCurrent().Name);
                //Console.WriteLine(WindowsIdentity.GetCurrent().IsSystem);
                //Console.WriteLine(WindowsIdentity.GetCurrent().User);
                //Console.WriteLine(WindowsIdentity.GetCurrent().Owner);
                //Console.WriteLine(WindowsIdentity.GetCurrent().Token);
            }
            else
            {
                //start this programm as Admin with all Administrativ Rights
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = assembly.CodeBase;//Assembly.GetEntryAssembly().CodeBase;
                proc.Verb = "runas";//run as admin
                Process.Start(proc);
                window.Close();
            }

        }

        /// <summary>
        /// Check if Programm is started with Administrativ Rights
        /// </summary>
        /// <returns></returns>
        public static bool ProgramIsStartedAsAdmin()
        {

            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);

            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
