using System.Runtime.InteropServices;
using System.Text;

namespace ZeroSysTestsFramework
{
   public class IniTest
   {

      //https://midnightprogrammer.net/post/readwrite-settings-to-ini-file-using-c/

      private string filePath;

      [DllImport("kernel32")]
      private static extern long WritePrivateProfileString(string section,
      string key,
      string val,
      string filePath);

      [DllImport("kernel32")]
      private static extern int GetPrivateProfileString(string section,
      string key,
      string def,
      StringBuilder retVal,
      int size,
      string filePath);

      public IniTest(string filePath)
      {
         this.filePath = filePath;
      }

      public void Write(string section, string key, string value)
      {
         WritePrivateProfileString(section, key, value.ToLower(), filePath);
      }

      public string Read(string section, string key)
      {
         StringBuilder SB = new StringBuilder(255);
         int i = GetPrivateProfileString(section, key, "", SB, 255, filePath);
         return SB.ToString();
      }

      public string FilePath
      {
         get { return filePath; }
         set { filePath = value; }
      }

   }
}
