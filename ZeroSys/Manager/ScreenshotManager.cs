using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ZeroSys.Manager
{
    /// <summary>
    /// ScreenshotManager
    /// </summary>
    public class ScreenshotManager
    {

        //screenshot https://stackoverflow.com/questions/1163761/capture-screenshot-of-active-window - https://ourcodeworld.com/articles/read/195/capturing-screenshots-of-different-ways-with-c-and-winforms

        //ToDo:
        //mehrere bildschirme
        //mehrere bildformate...
        //vlt funktion mit rectangle das user zieht wie in snipingtools dass dann erstellt und genommen wird und verarbeitet wird.

        /// <summary>
        /// Create Screenshot and save it with Random Name
        /// </summary>
        /// <param name="savePath"></param>
        public static void CaptureScreenSaveRandomFileName(string savePath)
        {

            try
            {

                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will  
                //capture our Current Screen
                Rectangle captureRectangle = System.Windows.Forms.Screen.AllScreens[0].Bounds;

                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                captureBitmap.Save(savePath + saveFile(savePath) + ".jpg", ImageFormat.Png);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// Create Screenshot
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="fileName"></param>
        public static void CaptureScreen(string savePath, string fileName)
        {

            try
            {

                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will  
                //capture our Current Screen
                Rectangle captureRectangle = System.Windows.Forms.Screen.AllScreens[0].Bounds;

                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                captureBitmap.Save(savePath + fileName, ImageFormat.Png);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// Create Screenshot
        /// </summary>
        /// <returns></returns>
        public static Bitmap CaptureScreen()
        {

            try
            {

                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will  
                //capture our Current Screen
                Rectangle captureRectangle = System.Windows.Forms.Screen.AllScreens[0].Bounds;

                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                return captureBitmap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// Save File with random generated File Name in selected Folder Path
        /// </summary>
        /// <param name="savePath"></param>
        /// <returns></returns>
        private static int saveFile(string savePath)
        {

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            Random random = new Random();
            int ran = random.Next(1000000, 1000000000);

            if (!File.Exists(""))
            {

                //A new Screenshot has been taken and saved under " + savePath + ran + ".jpg
                return ran;

            }
            else
            {
                saveFile(savePath);
            }

            return 0;
        }

    }
}
