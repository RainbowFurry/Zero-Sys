using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ZeroSys.Converter
{
    /// <summary>
    /// ImageConverter
    /// </summary>
    public class ImageConverter
    {

        /// <summary>
        /// Convert Images from one Format to another.
        /// Important! the ImageFormat needs to match the newImageEnding
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="newImageFormat"></param>
        /// <param name="newImageEnding"></param>
        public static void ConvertImage(string path, string name, ImageFormat newImageFormat, string newImageEnding)
        {
            if (File.Exists(path + name))
            {
                Image image = Image.FromFile(path + name);
                image.Save(path + name.Split('.')[0] + "." + newImageEnding.Replace(".", ""), newImageFormat);
                image.Dispose();
            }
        }

        /// <summary>
        /// Convert Images from one Format to another.
        /// Important! the ImageFormat needs to match the newImageEnding
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="newImageFormat"></param>
        /// <param name="newPath"></param>
        /// <param name="newImageEnding"></param>
        public static void ConvertImage(string path, string name, ImageFormat newImageFormat, string newPath, string newImageEnding)
        {
            if (File.Exists(path + name))
            {
                Image image = Image.FromFile(path + name);
                image.Save(newPath + name.Split('.')[0] + "." + newImageEnding.Replace(".", ""), newImageFormat);
                image.Dispose();
            }
        }

        /// <summary>
        /// Convert Image to Bitmap
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Bitmap ConvertImageToBitmap(Image image)
        {
            return new Bitmap(image);
        }

        /// <summary>
        /// Convert Bitmap to Image
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Image ConvertBitmapToImage(Bitmap bitmap)
        {
            Image image = bitmap;
            return image;
        }

    }
}
