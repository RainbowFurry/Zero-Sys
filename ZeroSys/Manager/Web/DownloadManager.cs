using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;

namespace ZeroSys.Manager.Web
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

        //download speed - schlecht
        public static void GetDownloadSpeed()
        {
            const string tempfile = @"C:\Users\DarkS\Documents\HeimServer\tempfile.tmp";
            WebClient webClient = new WebClient();

            Console.WriteLine("Downloading file....");

            Stopwatch sw = Stopwatch.StartNew();
            webClient.DownloadFile("http://dl.google.com/googletalk/googletalk-setup.exe", tempfile);
            sw.Stop();

            FileInfo fileInfo = new FileInfo(tempfile);
            var speed = fileInfo.Length / sw.Elapsed.TotalSeconds;

            Console.WriteLine("Download duration: {0}", sw.Elapsed);
            Console.WriteLine("File size: {0}", fileInfo.Length.ToString("N0"));
            Console.WriteLine("Speed: {0} bps ", speed.ToString("N0"));

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }

        #region Get Donwload Info Update

        public static WebClient webClient;               // Our WebClient that will be doing the downloading for us
        public static Stopwatch sw = new Stopwatch();
        public static void DownloadFileAndGetDownloadInfoUpdate(string urlAddress, string location)
        {
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private static void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            string downloadSpeed = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
            Console.WriteLine(downloadSpeed);

            // Update the progressbar percentage only when the value is not the same.
            //progressBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            string downloadedPercentage = e.ProgressPercentage.ToString() + "%";
            Console.WriteLine(downloadedPercentage);

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            string dataProcessed = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
            Console.WriteLine(dataProcessed);
        }

        // The event that will trigger when the WebClient is completed
        private static void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            if (e.Cancelled == true)
            {
                MessageBox.Show("Download has been canceled.");
            }
            else
            {
                MessageBox.Show("Download completed!");
            }
        }

        #endregion

    }
}
