using System;
using System.Reflection;
using System.Windows;

namespace ZeroSys.Manager.RunExeCode
{
    /// <summary>
    /// DLLManager
    /// </summary>
    public class ExecuteManager
    {

        /// <summary>
        /// Open Exe File in new Window
        /// </summary>
        /// <param name="pathToExe"></param>
        public static void OpenExeInNewWindow(string pathToExe)
        {
            Assembly assembly = Assembly.LoadFrom(pathToExe);
            Window window = Activator.CreateInstance(SetupAssembly(assembly).Type) as Window;
            window.Show();
        }

        /// <summary>
        /// Open Exe in Current Window
        /// </summary>
        /// <param name="pathToExe"></param>
        /// <returns></returns>
        public static Window OpenExeInCurrentApllication(string pathToExe)
        {
            Assembly assembly = Assembly.LoadFrom(pathToExe);
            return Activator.CreateInstance(SetupAssembly(assembly).Type) as Window;
        }

        /// <summary>
        /// Setup Assembly Information
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static AssemblyObject SetupAssembly(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(true);
            AssemblyTitleAttribute titleAttribute = attributes[3] as AssemblyTitleAttribute;
            AssemblyDescriptionAttribute descriptionAttribute = attributes[4] as AssemblyDescriptionAttribute;
            AssemblyCompanyAttribute companyAttribute = attributes[6] as AssemblyCompanyAttribute;
            AssemblyCopyrightAttribute copyrightAttribute = attributes[8] as AssemblyCopyrightAttribute;
            AssemblyTrademarkAttribute trademarkAttribute = attributes[9] as AssemblyTrademarkAttribute;
            Type type = assembly.GetType(titleAttribute.Title + ".MainWindow");
            AssemblyObject pluginObject = new AssemblyObject(titleAttribute.Title, descriptionAttribute.Description, companyAttribute.Company, copyrightAttribute.Copyright, trademarkAttribute.Trademark, type, false);
            return pluginObject;
        }

        /// <summary>
        /// Setup Assembly Information
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="startWindowName"></param>
        /// <returns></returns>
        public static AssemblyObject SetupAssembly(Assembly assembly, string startWindowName)
        {
            object[] attributes = assembly.GetCustomAttributes(true);
            AssemblyTitleAttribute titleAttribute = attributes[3] as AssemblyTitleAttribute;
            AssemblyDescriptionAttribute descriptionAttribute = attributes[4] as AssemblyDescriptionAttribute;
            AssemblyCompanyAttribute companyAttribute = attributes[6] as AssemblyCompanyAttribute;
            AssemblyCopyrightAttribute copyrightAttribute = attributes[8] as AssemblyCopyrightAttribute;
            AssemblyTrademarkAttribute trademarkAttribute = attributes[9] as AssemblyTrademarkAttribute;
            Type type = assembly.GetType(titleAttribute.Title + "." + startWindowName);
            AssemblyObject pluginObject = new AssemblyObject(titleAttribute.Title, descriptionAttribute.Description, companyAttribute.Company, copyrightAttribute.Copyright, trademarkAttribute.Trademark, type, false);
            return pluginObject;
        }

    }

}
