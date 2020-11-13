using System.Reflection;
using registry = Microsoft.Win32;

namespace ZeroSys.Manager
{
    /// <summary>
    /// RegistryManager
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

        public static void CreateFileExtention()
        {
            //
        }

        public static void CreateExplorerEntry()
        {
            //
        }

        /// <summary>
        /// Create Registry Entry for Actions comming from the Webside
        /// Example: Download App
        /// 
        /// The WebCall is like http/https with the set Scheme
        /// </summary>
        public static void CreateURLScheme(string urlScheme, Assembly assembly)
        {

            var KeyTest = registry.Registry.CurrentUser.OpenSubKey("Software", true).OpenSubKey("Classes", true);//CHANGE CURRENTUSER TO ROOT
            registry.RegistryKey key = KeyTest.CreateSubKey(urlScheme + ":");//zero://install/Name...
            key.SetValue("URL Protocol", urlScheme);//NAME   
            key.CreateSubKey(@"shell\open\command").SetValue("", assembly + @" %1");


            // < a href = "alert:wmPing" data - mce - href = "zero:Test" target = "_blank" >< span style = "color: #0000ff;" > Click to trigger</ span ></ a >

        }

        /// <summary>
        /// Create Autostart Registry Entry
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="assembly"></param>
        public static void CreateAutostart(string appName, Assembly assembly)
        {
            var KeyTest = registry.Registry.ClassesRoot.OpenSubKey("Software", true);
            registry.RegistryKey key = KeyTest.CreateSubKey(appName);//CREATE MAIN PATH
            key.SetValue("Autostart", appName);//AUTOSTART ENTRY
            key.CreateSubKey(@"shell\open\command").SetValue("", assembly + @" %1");//EDIT

        }

        /// <summary>
        /// Remove Autostart from Registry
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="assembly"></param>
        public static void RemoveAutostart(string appName)
        {
            var KeyTest = registry.Registry.ClassesRoot.OpenSubKey("Software", true);
            KeyTest.DeleteSubKeyTree(appName);
        }

        public static void WindowsCreateContextMenu()
        {
            //Rechtsklick bei dateien oder Desktop
        }

    }
}
