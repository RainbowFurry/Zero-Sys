using System.Reflection;
using registry = Microsoft.Win32;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Autostart Manager            *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Manager.Registry
{
    /// <summary>
    /// Autostart Manager
    /// </summary>
    public class Autostart
    {

        private static registry.RegistryKey key = registry.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private static Assembly currentAssembly = Assembly.GetExecutingAssembly();

        /// <summary>
        /// Create Autostart Entry
        /// </summary>
        public static void Create()
        {
            key.SetValue(currentAssembly.GetName().Name, currentAssembly.Location);
        }

        /// <summary>
        /// Delete Autostart Entry
        /// </summary>
        public static void Delete()
        {
            key.DeleteValue(currentAssembly.GetName().Name);
        }

        /// <summary>
        /// Create Autostart Entry
        /// </summary>
        public static void Create(Assembly assembly)
        {
            key.SetValue(assembly.GetName().Name, assembly.Location);
        }

        /// <summary>
        /// Delete Autostart Entry
        /// </summary>
        public static void Delete(Assembly assembly)
        {
            key.DeleteValue(assembly.GetName().Name);
        }

    }
}
