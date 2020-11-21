using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace ZeroSys.Manager
{
    /// <summary>
    /// DesktopShortcutManager
    /// </summary>
    public class DesktopShortcutManager
    {

        //GEBE INI IMMER ANDEREN NAMEN!!!
        /// <summary>
        /// Create a Folder with an Icon (.ini) from DLL
        /// </summary>
        public static void CreateExplorerQuickAccess(string pathFolder, string iconPath)
        {
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/a63b0d8b-82c0-4e15-b1d5-1c6bec1ee96f/change-system-folder-icon-c?forum=csharpgeneral
            //https://stackoverflow.com/questions/41392818/change-directory-folder-icon-using-c-sharp-programmatically/41394575#41394575
            if (!Directory.Exists(pathFolder))
                Directory.CreateDirectory(pathFolder);

            if (File.Exists(pathFolder + "desktop.ini"))
            {
                //remove hidden and system attributes to make ini file writable
                File.SetAttributes(
                   pathFolder + "desktop.ini",
                   File.GetAttributes(pathFolder + "desktop.ini") &
                   ~(FileAttributes.Hidden | FileAttributes.System));
            }

            //create new ini file with the required contents
            var iniContents = new StringBuilder()
                .AppendLine("[.ShellClassInfo]")
                .AppendLine($"IconResource=" + iconPath)//pathFiles + "DarkWolfCraftSys.dll,0"
                .AppendLine($"IconFile=" + iconPath)//pathFiles + "DarkWolfCraftSys.dll"
                .AppendLine("IconIndex=0")
                .ToString();
            File.WriteAllText(pathFolder + "desktop.ini", iniContents);

            //hide the ini file and set it as system
            File.SetAttributes(
               pathFolder + "desktop.ini",
               File.GetAttributes(pathFolder + "desktop.ini") | FileAttributes.Hidden | FileAttributes.System);
            //set the folder as system
            File.SetAttributes(
                pathFolder,
                File.GetAttributes(pathFolder) | FileAttributes.System);

            AddFolderToQuickAccess(pathFolder);

        }

        /// <summary>
        /// Add File/Folder to QuickAccess
        /// </summary>
        /// <param name="pathToFolder"></param>
        public static void AddFolderToQuickAccess(string pathToFolder)
        {
            //https://stackoverrun.com/de/q/10128731
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();
                var ps = PowerShell.Create();
                var shellApplication =
                 ps.AddCommand("New-Object").AddParameter("ComObject", "shell.application").Invoke();
                dynamic nameSpace = shellApplication.FirstOrDefault()?.Methods["NameSpace"].Invoke(pathToFolder);
                nameSpace?.Self.InvokeVerb("pintohome");
            }
        }

        /// <summary>
        /// Create Programm Desktop Shortcut
        /// </summary>
        public static void CreateDesktopShortcut(string shortcutName)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string linkName = shortcutName;

            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
            {
                string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");
                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
            }
        }

    }
}
