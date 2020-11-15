using System.IO;

namespace ZeroSys.IO
{
    /// <summary>
    /// FileManager
    /// </summary>
    public class FileManager
    {

        //
        public void CreateTextFile(string path, string name)
        {

        }

        //
        public void CreateTextFile(string path, string name, string content)
        {

        }

        //
        public void CreateFile(string path, string name, string fileEnding)
        {

        }

        //
        public void CreateFile(string path, string name, string fileEnding, string content)
        {

        }

        //
        public void EditeFile(string path, string content, bool overwrite)
        {

        }

        //
        public void EditTextFile(string path, string content, bool overwrite)
        {

        }

        /// <summary>
        /// Read Content from File
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            return null;
        }

        /// <summary>
        /// Read Content from File and Split by new Line
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string[] ReadFileAndSplitLine(string path)
        {
            if (File.Exists(path))
            {
                string[] content = File.ReadAllLines(path);
                return content;
            }
            return null;
        }

        //
        public void CreateZipFile()
        {

        }

        //
        public void UnpackZipFile()
        {

        }

    }
}
