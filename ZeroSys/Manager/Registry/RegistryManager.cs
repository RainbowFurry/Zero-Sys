using System;
using System.IO;
using System.Linq;
using registry = Microsoft.Win32;

namespace ZeroSys.Manager.Registry
{
    /// <summary>
    /// 
    /// </summary>
    public class RegistryManager
    {

        //Rework completly
        //Aufbau Registry:
        //MainApp:
        //  Defaults
        //  Own File Type
        //  Explorer menu
        //  Rechtsklick einträge
        //  autostart - fertig
        //  URL - fertig
        //  für alles getter(key.GetValue("");), setter, deleter(Registry.CurrentUser.DeleteSubKey(subkey);)

        private static void CreateFileExtention()
        {
            //
        }

        private static void CreateExplorerEntry()
        {
            //
        }

        /// <summary>
        /// Create Registry Entry for Actions comming from the Webside
        /// Example: Download App
        /// 
        /// The WebCall is like http/https with the set Scheme
        /// </summary>
        private static void CreateURLScheme()
        {

            //how to reffer startargs
            //how to install?

            Console.WriteLine("Listening.."); //Gets the current location where the file is downloaded   
            var loc = System.Reflection.Assembly.GetExecutingAssembly().Location;
            if (!Directory.Exists(@"C:\Console\"))
            {
                System.IO.Directory.CreateDirectory(@"C:\Console\");
            } //Creates the Downloaded file in the specified folder  
            if (!File.Exists(@"C:\Console\" + loc.Split('\\').Last()))
            {
                File.Move(loc, @"C:\Console\" + loc.Split('\\').Last());
            }
            var KeyTest = registry.Registry.CurrentUser.OpenSubKey("Software", true).OpenSubKey("Classes", true);//CHANGE CURRENTUSER TO ROOT
            registry.RegistryKey key = KeyTest.CreateSubKey("zero:");//zero://install/Name...
            key.SetValue("URL Protocol", "Test");//NAME???   
            key.CreateSubKey(@"shell\open\command").SetValue("", @"C:\Console\WMConsole.exe %1");


            // < a href = "alert:wmPing" data - mce - href = "zero:Test" target = "_blank" >< span style = "color: #0000ff;" > Click to trigger</ span ></ a >

        }

        private static void CreateAutostart()
        {

            var KeyTest = registry.Registry.ClassesRoot.OpenSubKey("Software", true);
            registry.RegistryKey key = KeyTest.CreateSubKey("ZeroWorks");//CREATE MAIN PATH
            key.CreateSubKey("Client", true);
            key.SetValue("Autostart", "zeroworks");//AUTOSTART ENTRY
            key.CreateSubKey(@"shell\open\command").SetValue("", @"E:\app.exe %1");//EDIT

        }

        private static void WindowsCreateContextMenu()
        {
            //Rechtsklick bei dateien oder Desktop
        }

    }
}
