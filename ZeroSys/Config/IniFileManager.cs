using System.Runtime.InteropServices;
using System.Text;

namespace ZeroSys.Config
{
    /// <summary>
    /// IniFileManager
    /// </summary>
    public class IniFileManager
    {

        private static string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// Initialize IniFileManager
        /// </summary>
        /// <param name="filePath"></param>
        public IniFileManager(string filePath)
        {
            path = filePath;
        }

        //create file
        public void AddInitValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        //Get Ini Values
        public string GetInitValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
            return temp.ToString();
        }

        //delete file
        public void DeleteInit()
        {

        }

        //remove value
        //Update value

    }
}
