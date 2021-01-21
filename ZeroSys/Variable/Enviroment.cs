using System;

namespace ZeroSys.Variable
{
   /// <summary>
   /// Enviroment
   /// </summary>
   public class Enviroment
   {

      public static string CookiePath = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
      public static string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      public static string Startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
      public static string System = Environment.GetFolderPath(Environment.SpecialFolder.System);
      public static string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
      public static string Windows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
      public static string SystemX86 = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
      public static string Programs = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
      public static string InternetCache = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
      public static string Favorites = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
      public static string MyComputer = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
      public static string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
      public static string StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);

      public static string CurrentDirectory = Environment.CurrentDirectory;
      public static string MachineName = Environment.MachineName;
      public static bool Is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
      public static string OSVersion = Environment.OSVersion.VersionString;
      public static string UserName = Environment.UserName;
      public static string BuildVersion = Environment.Version.Build.ToString();

      /// <summary>
      /// Create Temp Enviroment Variable
      /// </summary>
      /// <param name="key"></param>
      /// <param name="value"></param>
      public static void CreateEnviromentVariable(string key, string value)
      {
         Environment.SetEnvironmentVariable(key, value);
      }

      /// <summary>
      /// Create Enviroment Variable and Save
      /// </summary>
      /// <param name="key"></param>
      /// <param name="value"></param>
      /// <param name="target"></param>
      public static void CreateEnviromentVariable(string key, string value, EnvironmentVariableTarget target)
      {
         Environment.SetEnvironmentVariable(key, value, target);
      }

   }
}
