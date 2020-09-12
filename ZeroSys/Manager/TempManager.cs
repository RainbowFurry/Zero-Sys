using System;
using System.CodeDom.Compiler;
using System.IO;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Manage temporary Files       *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Manager
{
    /// <summary>
    /// Temporary File Manager
    /// </summary>
    public class TempManager
    {

        private static string path = Path.GetTempPath();

        /// <summary>
        /// Create a Folder with a random Name
        /// </summary>
        public void CreateRandomFolder()
        {
            Directory.CreateDirectory(path + Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Create a File with random Name
        /// </summary>
        /// <param name="content"></param>
        /// <param name="deleteFile"></param>
        public void CreateRandomFile(string content, bool deleteFile)
        {
            TempFileCollection tempCollection = new TempFileCollection(path, true);
            string filename = tempCollection.AddExtension("tmp", deleteFile);
            File.WriteAllText(Path.Combine(path, filename), content);
        }

        /// <summary>
        /// Create a File with specific Name
        /// </summary>
        /// <param name="content"></param>
        /// <param name="name"></param>
        /// <param name="deleteFile"></param>
        public void CreateFileWithName(string content, string name, bool deleteFile)
        {
            TempFileCollection tempCollection = new TempFileCollection(path, deleteFile);
            tempCollection.AddFile(name, true);
            File.WriteAllText(Path.Combine(path, name), content);
        }

        /// <summary>
        /// Create Folder with specific Name
        /// </summary>
        /// <param name="name"></param>
        public void CreateFolderWithName(string name)
        {
            Directory.CreateDirectory(path + name);
        }

    }
}
