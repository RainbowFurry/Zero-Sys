using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Media = System.Windows.Media;

namespace ZeroSys.Manager.Images
{
    /// <summary>
    /// Change Color of Image
    /// </summary>
    public class ChangeColor
    {

        /// <summary>
        /// Change The Color of an Image to the defined Configs
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fromColor"></param>
        /// <param name="toColor"></param>
        /// <returns></returns>
        public static Media.ImageSource changeImageColor(System.Windows.Controls.Image image, Color fromColor, Color toColor)
        {
            return ConvertToImageSource(changecolor(ConvertWpfImageToImage(image), fromColor, toColor));
        }

        /// <summary>
        /// Change Image Color to selected User Main Color
        /// </summary>
        public static Bitmap changecolor(Image image, Color fromColor, Color toColor)
        {

            Bitmap img = new Bitmap(image);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixelColor = img.GetPixel(i, j);
                    if (pixelColor == fromColor && pixelColor != Color.FromArgb(0, 255, 255, 255))//Change Main Color
                    {
                        img.SetPixel(i, j, toColor);
                    }
                    else if (pixelColor == Color.FromArgb(255, 0, 0, 0))//Wenn Schwarz
                    {
                        img.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                    }
                    else if (pixelColor == Color.FromArgb(255, 255, 255, 255))//Weiß zu Schwart
                    {
                        img.SetPixel(i, j, Color.FromArgb(255, 0, 0, 0));
                    }
                    else//falls keine farbe dabei ist
                    {
                        // TODO Entcomment when svg is implementiert
                        //img.SetPixel(i, j, System.Drawing.Color.FromArgb(0, 0, 0, 0));
                    }

                }
            }
            return img;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Image ConvertWpfImageToImage(System.Windows.Controls.Image image)
        {
            if (image == null)
                throw new ArgumentNullException("image", "Image darf nicht null sein.");

            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            MemoryStream ms = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image.Source));
            encoder.Save(ms);
            Image img = Image.FromStream(ms);
            return img;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Media.ImageSource ConvertToImageSource(Bitmap bitmap)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        /// <summary>
        /// Change Image Color to given Color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="image"></param>
        public static Bitmap changecolor(Color color, Image image)
        {
            Color fromColor = Color.FromArgb(15, 127, 238);
            Color toColor = color;

            Bitmap img = new Bitmap(image);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixelColor = img.GetPixel(i, j);
                    if (pixelColor == fromColor)
                        img.SetPixel(i, j, toColor);
                }
            }
            return img;
        }

    }
}
