using System.IO.Compression;
using System.Net;

namespace ZeroSys.Manager
{
    /// <summary>
    /// DownloadManager
    /// </summary>
    public class DownloadManager
    {

        /// <summary>
        /// Start downloading Cotnent from Web
        /// </summary>
        /// <param name="remoteFilePath"></param>
        /// <param name="localFilePath"></param>
        public static void DownloadFile(string remoteFilePath, string localFilePath)
        {
            WebClient client = new WebClient();
            client.DownloadFile(remoteFilePath, localFilePath);
        }

        /// <summary>
        /// Start downloading Cotnent from Web and unzip Content after Finish
        /// </summary>
        /// <param name="remoteFilePath"></param>
        /// <param name="localFilePath"></param>
        public static void DownloadFileAndUnzip(string remoteFilePath, string localFilePath)
        {
            WebClient client = new WebClient();
            client.DownloadFile(remoteFilePath, localFilePath);

            if (localFilePath.Contains(".zip") || localFilePath.Contains(".rar") || localFilePath.Contains("7zip"))
            {
                string[] fullPath = localFilePath.Split('\\');
                string path = "";

                for (int i = 0; i < fullPath.Length - 2; i++)
                {
                    path += fullPath[i];
                }

                if (!string.IsNullOrEmpty(path))
                    ZipFile.ExtractToDirectory(localFilePath, path);

            }

        }

    }
}
