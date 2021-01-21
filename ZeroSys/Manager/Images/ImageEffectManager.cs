using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace ZeroSys.Manager.Images
{
   /// <summary>
   /// ImageBlurrManager
   /// </summary>
   public class ImageEffectManager
   {

      //https://softwarebydefault.com/2013/03/03/colomatrix-image-filters/
      //https://softwarebydefault.com/2013/03/02/bitmap-image-filters/

      //anhengbar: rotate | Save

      //image shape - schärfer machen

      #region Image Blurr Filter

      /// <summary>
      /// Create Image Blurrer
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="blurrer"></param>
      /// <returns></returns>
      public static Bitmap CreateBlurredImage(Bitmap bitmap, int blurrer)
      {
         bitmap = Blur(bitmap, blurrer);
         return bitmap;
      }

      /// <summary>
      /// Create Image Blurrer
      /// </summary>
      /// <param name="image"></param>
      /// <param name="blurrer"></param>
      /// <returns></returns>
      public static Image CreateBlurredImage(Image image, int blurrer)
      {
         Bitmap bitmap = new Bitmap(image);
         bitmap = Blur(bitmap, blurrer);
         return bitmap;
      }

      /// <summary>
      /// Create Image Blurrer
      /// </summary>
      /// <param name="image"></param>
      /// <param name="blurSize"></param>
      /// <returns></returns>
      private static Bitmap Blur(Bitmap image, Int32 blurSize)
      {
         return Blur(image, new Rectangle(0, 0, image.Width, image.Height), blurSize);
      }

      /// <summary>
      /// Create Image Blurrer
      /// </summary>
      /// <param name="image">The image.</param>
      /// <param name="rectangle">The rectangle.</param>
      /// <param name="blurSize">The blur size.</param>
      /// <returns>A Bitmap.</returns>
      private unsafe static Bitmap Blur(Bitmap image, Rectangle rectangle, Int32 blurSize)
      {
         Bitmap blurred = new Bitmap(image.Width, image.Height);

         // make an exact copy of the bitmap provided
         using (Graphics graphics = Graphics.FromImage(blurred))
            graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

         // Lock the bitmap's bits
         BitmapData blurredData = blurred.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, blurred.PixelFormat);

         // Get bits per pixel for current PixelFormat
         int bitsPerPixel = Image.GetPixelFormatSize(blurred.PixelFormat);

         // Get pointer to first line
         byte* scan0 = (byte*)blurredData.Scan0.ToPointer();

         // look at every pixel in the blur rectangle
         for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
         {
            for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
            {
               int avgR = 0, avgG = 0, avgB = 0;
               int blurPixelCount = 0;

               // average the color of the red, green and blue for each pixel in the
               // blur size while making sure you don't go outside the image bounds
               for (int x = xx; (x < xx + blurSize && x < image.Width); x++)
               {
                  for (int y = yy; (y < yy + blurSize && y < image.Height); y++)
                  {
                     // Get pointer to RGB
                     byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                     avgB += data[0]; // Blue
                     avgG += data[1]; // Green
                     avgR += data[2]; // Red

                     blurPixelCount++;
                  }
               }

               avgR = avgR / blurPixelCount;
               avgG = avgG / blurPixelCount;
               avgB = avgB / blurPixelCount;

               // now that we know the average for the blur size, set each pixel to that color
               for (int x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
               {
                  for (int y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                  {
                     // Get pointer to RGB
                     byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                     // Change values
                     data[0] = (byte)avgB;
                     data[1] = (byte)avgG;
                     data[2] = (byte)avgR;
                  }
               }
            }
         }

         // Unlock the bits
         blurred.UnlockBits(blurredData);

         return blurred;
      }
      #endregion

      #region Image Resizer Filter

      /// <summary>
      /// Resize an Image
      /// </summary>
      /// <param name="imgToResize"></param>
      /// <param name="size"></param>
      /// <returns></returns>
      public static Image ResizeImage(Image imgToResize, Size size)
      {
         return new Bitmap(imgToResize, size);
      }

      /// <summary>
      /// Resize an Image dynamic
      /// </summary>
      /// <param name="imgToResize"></param>
      /// <param name="stepper"></param>
      /// <param name="taller"></param>
      /// <returns></returns>
      public static Image ResizeImage(Image imgToResize, int stepper, bool taller)
      {
         if (taller)
            return new Bitmap(imgToResize, new Size(imgToResize.Width * stepper, imgToResize.Height * stepper));
         else
            return new Bitmap(imgToResize, new Size(imgToResize.Width / stepper, imgToResize.Height / stepper));
      }

      /// <summary>
      /// Resize an Image
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="size"></param>
      /// <returns></returns>
      public static Bitmap ResizeImage(Bitmap bitmap, Size size)
      {
         return new Bitmap(bitmap, size);
      }

      /// <summary>
      /// Resize an Image dynamic
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="stepper"></param>
      /// <param name="taller"></param>
      /// <returns></returns>
      public static Bitmap ResizeImage(Bitmap bitmap, int stepper, bool taller)
      {
         if (taller)
            return new Bitmap(bitmap, new Size(bitmap.Width * stepper, bitmap.Height * stepper));
         else
            return new Bitmap(bitmap, new Size(bitmap.Width / stepper, bitmap.Height / stepper));
      }

      #endregion

      #region Image Gray Scale Filter

      /// <summary>
      /// Add gray Overlay over Image
      /// </summary>
      /// <param name="bitmap"></param>
      /// <returns></returns>
      public static Bitmap CreateGrayScaleImage(Bitmap bitmap)
      {
         Bitmap grayScale = new Bitmap(bitmap.Width, bitmap.Height);

         for (Int32 y = 0; y < grayScale.Height; y++)
            for (Int32 x = 0; x < grayScale.Width; x++)
            {
               Color c = bitmap.GetPixel(x, y);

               Int32 gs = (Int32)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);

               grayScale.SetPixel(x, y, Color.FromArgb(gs, gs, gs));
            }
         return grayScale;
      }

      /// <summary>
      /// Add gray Overlay over Image
      /// </summary>
      /// <param name="image"></param>
      /// <returns></returns>
      public static Image CreateGrayScaleImage(Image image)
      {
         Bitmap grayScale = new Bitmap(image.Width, image.Height);
         Bitmap bitmap = new Bitmap(image);

         for (Int32 y = 0; y < grayScale.Height; y++)
            for (Int32 x = 0; x < grayScale.Width; x++)
            {
               Color c = bitmap.GetPixel(x, y);

               Int32 gs = (Int32)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);

               grayScale.SetPixel(x, y, Color.FromArgb(gs, gs, gs));
            }
         return grayScale;
      }
      #endregion

      #region Image Watermark Filter

      /// <summary>
      /// Create Image Watermark
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="watermarkText"></param>
      /// <param name="color"></param>
      /// <param name="font"></param>
      /// <returns></returns>
      public static Bitmap CreateWatermarkedImage(Bitmap bitmap, string watermarkText, Color color, Font font)
      {

         Image image = bitmap; // set image
         Point atpoint = new Point(image.Width / 2, image.Height / 2);//Text Centered
         SolidBrush brush = new SolidBrush(color);
         Graphics graphics = Graphics.FromImage(image);
         StringFormat sf = new StringFormat();
         sf.Alignment = StringAlignment.Center;
         sf.LineAlignment = StringAlignment.Center;
         graphics.DrawString(watermarkText, font, brush, atpoint, sf);
         graphics.Dispose();

         return new Bitmap(image);
      }

      /// <summary>
      /// Create Image Watermark
      /// </summary>
      /// <param name="image"></param>
      /// <param name="watermarkText"></param>
      /// <param name="color"></param>
      /// <param name="font"></param>
      /// <returns></returns>
      public static Image CreateWatermarkedImage(Image image, string watermarkText, Color color, Font font)
      {

         Point atpoint = new Point(image.Width / 2, image.Height / 2);//Text Centered
         SolidBrush brush = new SolidBrush(color);
         Graphics graphics = Graphics.FromImage(image);
         StringFormat sf = new StringFormat();
         sf.Alignment = StringAlignment.Center;
         sf.LineAlignment = StringAlignment.Center;
         graphics.DrawString(watermarkText, font, brush, atpoint, sf);
         graphics.Dispose();

         return image;
      }

      #endregion

      #region Negative Image Filter

      /// <summary>
      /// Create negativ Image
      /// </summary>
      /// <param name="bitmap"></param>
      /// <returns></returns>
      public static Bitmap CreateNegativeImage(Bitmap bitmap)
      {

         Bitmap bmpNew = bitmap;
         BitmapData bmpData = bmpNew.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

         IntPtr ptr = bmpData.Scan0;

         byte[] byteBuffer = new byte[bmpData.Stride * bmpNew.Height];

         Marshal.Copy(ptr, byteBuffer, 0, byteBuffer.Length);
         byte[] pixelBuffer = null;

         int pixel = 0;

         for (int k = 0; k < byteBuffer.Length; k += 4)
         {
            pixel = ~BitConverter.ToInt32(byteBuffer, k);
            pixelBuffer = BitConverter.GetBytes(pixel);

            byteBuffer[k] = pixelBuffer[0];
            byteBuffer[k + 1] = pixelBuffer[1];
            byteBuffer[k + 2] = pixelBuffer[2];
         }

         Marshal.Copy(byteBuffer, 0, ptr, byteBuffer.Length);

         bmpNew.UnlockBits(bmpData);

         return bmpNew;
      }

      /// <summary>
      /// Create negativ Image
      /// </summary>
      /// <param name="image"></param>
      /// <returns></returns>
      public static Image CreateNegativeImage(Image image)
      {

         Bitmap bmpNew = new Bitmap(image);
         BitmapData bmpData = bmpNew.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

         IntPtr ptr = bmpData.Scan0;

         byte[] byteBuffer = new byte[bmpData.Stride * bmpNew.Height];

         Marshal.Copy(ptr, byteBuffer, 0, byteBuffer.Length);
         byte[] pixelBuffer = null;

         int pixel = 0;

         for (int k = 0; k < byteBuffer.Length; k += 4)
         {
            pixel = ~BitConverter.ToInt32(byteBuffer, k);
            pixelBuffer = BitConverter.GetBytes(pixel);

            byteBuffer[k] = pixelBuffer[0];
            byteBuffer[k + 1] = pixelBuffer[1];
            byteBuffer[k + 2] = pixelBuffer[2];
         }

         Marshal.Copy(byteBuffer, 0, ptr, byteBuffer.Length);

         bmpNew.UnlockBits(bmpData);

         return bmpNew;
      }

      #endregion

      #region Transparent Image Filter

      /// <summary>
      /// Change the Visibility of the Image
      /// </summary>
      /// <param name="sourceImage"></param>
      /// <returns></returns>
      public static Image CreateTransparentImage(Image sourceImage)
      {
         ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                             {
                            new float[]{1, 0, 0, 0, 0},
                            new float[]{0, 1, 0, 0, 0},
                            new float[]{0, 0, 1, 0, 0},
                            new float[]{0, 0, 0, 0.3f, 0},
                            new float[]{0, 0, 0, 0, 1}
                             });


         return ApplyColorMatrix(sourceImage, colorMatrix);
      }

      /// <summary>
      /// Change the Visibility of the Image
      /// </summary>
      /// <param name="sourceImage"></param>
      /// <returns></returns>
      public static Bitmap CreateTransparentImage(Bitmap sourceImage)
      {
         ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                             {
                            new float[]{1, 0, 0, 0, 0},
                            new float[]{0, 1, 0, 0, 0},
                            new float[]{0, 0, 1, 0, 0},
                            new float[]{0, 0, 0, 0.3f, 0},
                            new float[]{0, 0, 0, 0, 1}
                             });


         return ApplyColorMatrix(sourceImage, colorMatrix);
      }

      /// <summary>
      /// Create a Color ofer a Image
      /// For Example Color = red | alpha = 128
      /// </summary>
      /// <param name="image"></param>
      /// <param name="alpha"></param>
      /// <param name="color"></param>
      /// <returns></returns>
      public static Image CreateTransparentColorOverImage(Image image, int alpha, Color color)
      {

         if (alpha == null)
            alpha = 128;

         Bitmap bmp = new Bitmap(image);
         Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);

         using (Graphics g = Graphics.FromImage(bmp))
         {
            using (Brush cloud_brush = new SolidBrush(Color.FromArgb(alpha, color)))
            {
               g.FillRectangle(cloud_brush, r);
            }
         }

         return bmp;
      }

      /// <summary>
      /// Create a Color ofer a Image
      /// For Example Color = red | alpha = 128
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="alpha"></param>
      /// <param name="color"></param>
      /// <returns></returns>
      public static Bitmap CreateTransparentColorOverImage(Bitmap bitmap, int alpha, Color color)
      {

         if (alpha == null)
            alpha = 128;

         Rectangle r = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

         using (Graphics g = Graphics.FromImage(bitmap))
         {
            using (Brush cloud_brush = new SolidBrush(Color.FromArgb(alpha, color)))
            {
               g.FillRectangle(cloud_brush, r);
            }
         }

         return bitmap;
      }

      #endregion

      #region Brown Scale Image Filter (Sepia Tone)

      /// <summary>
      /// Create Image with brown Effect
      /// </summary>
      /// <param name="sourceImage"></param>
      /// <returns></returns>
      public static Image CreateBrownFilterImage(Image sourceImage)
      {
         ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                    {
                        new float[]{.393f, .349f, .272f, 0, 0},
                        new float[]{.769f, .686f, .534f, 0, 0},
                        new float[]{.189f, .168f, .131f, 0, 0},
                        new float[]{0, 0, 0, 1, 0},
                        new float[]{0, 0, 0, 0, 1}
                    });


         return ApplyColorMatrix(sourceImage, colorMatrix);
      }

      /// <summary>
      /// Create Image with brown Effect
      /// </summary>
      /// <param name="sourceImage"></param>
      /// <returns></returns>
      public static Bitmap CreateBrownFilterImage(Bitmap sourceImage)
      {
         ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                    {
                        new float[]{.393f, .349f, .272f, 0, 0},
                        new float[]{.769f, .686f, .534f, 0, 0},
                        new float[]{.189f, .168f, .131f, 0, 0},
                        new float[]{0, 0, 0, 1, 0},
                        new float[]{0, 0, 0, 0, 1}
                    });


         return ApplyColorMatrix(sourceImage, colorMatrix);
      }

      #endregion

      #region Collage Image Filter

      /// <summary>
      /// Create Image Collection ( Combind multiple Images in one )
      /// </summary>
      /// <param name="images"></param>
      /// <returns></returns>
      private static Image CreateImageCollection(Image[] images)
      {

         int width = 1920;
         int height = 1080;
         int imageSize = images.Length;

         using (Bitmap bmp = new Bitmap(width, height))
         {
            using (Graphics g = Graphics.FromImage(bmp))
            {
               switch (imageSize)
               {

                  case 2:
                     g.DrawImage(images[0], 0, 0, width / 2, height / 2);
                     g.DrawImage(images[1], width / 2, 0, width / 2, height / 2);
                     break;

                  case 4:
                     g.DrawImage(images[0], 0, 0, width / 2, height / 2);
                     g.DrawImage(images[1], width / 2, 0, width / 2, height / 2);

                     g.DrawImage(images[2], 0, height / 2, width / 2, height / 2);
                     g.DrawImage(images[3], width / 2, height / 2, width / 2, height / 2);
                     break;

                  case 5:
                     g.DrawImage(images[0], 0, 0, width / 2, height / 2);
                     g.DrawImage(images[1], width / 2, 0, width / 2, height / 2);

                     g.DrawImage(images[2], 0, height / 2, width / 2, height / 2);
                     g.DrawImage(images[3], width / 2, height / 2, width / 2, height / 2);

                     g.DrawImage(images[4], width / 2 / 2, height / 2 / 2, width / 2, height / 2);
                     break;

                  case 6:
                     g.DrawImage(images[0], 0, 0, width / 3, height / 3);
                     g.DrawImage(images[1], width / 3, 0, width / 3, height / 3);
                     g.DrawImage(images[2], width / 3 * 2, 0, width / 3, height / 3);

                     g.DrawImage(images[3], 0, height / 3, width / 3, height / 3);
                     g.DrawImage(images[4], width / 3, height / 3, width / 3, height / 3);
                     g.DrawImage(images[5], width / 3 * 2, height / 3, width / 3, height / 3);
                     break;

                  case 8:
                     g.DrawImage(images[0], 0, 0, width / 4, height / 4);
                     g.DrawImage(images[1], width / 4, 0, width / 4, height / 4);
                     g.DrawImage(images[2], width / 4 * 2, 0, width / 4, height / 4);
                     g.DrawImage(images[3], width / 4 * 3, 0, width / 4, height / 4);

                     g.DrawImage(images[4], 0, height / 4, width / 4, height / 4);
                     g.DrawImage(images[5], width / 4, height / 4, width / 4, height / 4);
                     g.DrawImage(images[6], width / 4 * 2, height / 4, width / 4, height / 4);
                     g.DrawImage(images[7], width / 4 * 3, height / 4, width / 4, height / 4);
                     break;

                  case 9:
                     g.DrawImage(images[0], 0, 0, width / 3, height / 3);
                     g.DrawImage(images[1], width / 3, 0, width / 3, height / 3);
                     g.DrawImage(images[2], width / 3 * 2, 0, width / 3, height / 3);

                     g.DrawImage(images[3], 0, height / 3, width / 3, height / 3);
                     g.DrawImage(images[4], width / 3, height / 3, width / 3, height / 3);
                     g.DrawImage(images[5], width / 3 * 2, height / 3, width / 3, height / 3);

                     g.DrawImage(images[6], 0, height / 3 * 2, width / 3, height / 3);
                     g.DrawImage(images[7], width / 3, height / 3 * 2, width / 3, height / 3);
                     g.DrawImage(images[8], width / 3 * 2, height / 3 * 2, width / 3, height / 3);
                     break;

                  default:
                     throw new Exception("You need rather 2,4,5,6,8,9 Images");
                     break;

               }
            }
            return bmp;
         }

      }

      /// <summary>
      /// Create Image Collection ( Combind multiple Images in one )
      /// </summary>
      /// <param name="images"></param>
      /// <returns></returns>
      private static Bitmap CreateImageCollection(Bitmap[] images)
      {

         int width = 1920;
         int height = 1080;
         int imageSize = images.Length;

         using (Bitmap bmp = new Bitmap(width, height))
         {
            using (Graphics g = Graphics.FromImage(bmp))
            {
               switch (imageSize)
               {

                  case 2:
                     g.DrawImage(images[0], 0, 0, width / 2, height / 2);
                     g.DrawImage(images[1], width / 2, 0, width / 2, height / 2);
                     break;

                  case 4:
                     g.DrawImage(images[0], 0, 0, width / 2, height / 2);
                     g.DrawImage(images[1], width / 2, 0, width / 2, height / 2);

                     g.DrawImage(images[2], 0, height / 2, width / 2, height / 2);
                     g.DrawImage(images[3], width / 2, height / 2, width / 2, height / 2);
                     break;

                  case 5:
                     g.DrawImage(images[0], 0, 0, width / 2, height / 2);
                     g.DrawImage(images[1], width / 2, 0, width / 2, height / 2);

                     g.DrawImage(images[2], 0, height / 2, width / 2, height / 2);
                     g.DrawImage(images[3], width / 2, height / 2, width / 2, height / 2);

                     g.DrawImage(images[4], width / 2 / 2, height / 2 / 2, width / 2, height / 2);
                     break;

                  case 6:
                     g.DrawImage(images[0], 0, 0, width / 3, height / 3);
                     g.DrawImage(images[1], width / 3, 0, width / 3, height / 3);
                     g.DrawImage(images[2], width / 3 * 2, 0, width / 3, height / 3);

                     g.DrawImage(images[3], 0, height / 3, width / 3, height / 3);
                     g.DrawImage(images[4], width / 3, height / 3, width / 3, height / 3);
                     g.DrawImage(images[5], width / 3 * 2, height / 3, width / 3, height / 3);
                     break;

                  case 8:
                     g.DrawImage(images[0], 0, 0, width / 4, height / 4);
                     g.DrawImage(images[1], width / 4, 0, width / 4, height / 4);
                     g.DrawImage(images[2], width / 4 * 2, 0, width / 4, height / 4);
                     g.DrawImage(images[3], width / 4 * 3, 0, width / 4, height / 4);

                     g.DrawImage(images[4], 0, height / 4, width / 4, height / 4);
                     g.DrawImage(images[5], width / 4, height / 4, width / 4, height / 4);
                     g.DrawImage(images[6], width / 4 * 2, height / 4, width / 4, height / 4);
                     g.DrawImage(images[7], width / 4 * 3, height / 4, width / 4, height / 4);
                     break;

                  case 9:
                     g.DrawImage(images[0], 0, 0, width / 3, height / 3);
                     g.DrawImage(images[1], width / 3, 0, width / 3, height / 3);
                     g.DrawImage(images[2], width / 3 * 2, 0, width / 3, height / 3);

                     g.DrawImage(images[3], 0, height / 3, width / 3, height / 3);
                     g.DrawImage(images[4], width / 3, height / 3, width / 3, height / 3);
                     g.DrawImage(images[5], width / 3 * 2, height / 3, width / 3, height / 3);

                     g.DrawImage(images[6], 0, height / 3 * 2, width / 3, height / 3);
                     g.DrawImage(images[7], width / 3, height / 3 * 2, width / 3, height / 3);
                     g.DrawImage(images[8], width / 3 * 2, height / 3 * 2, width / 3, height / 3);
                     break;

                  default:
                     throw new Exception("You need rather 2,4,5,6,8,9 Images");
                     break;

               }
            }
            return bmp;
         }

      }

      #endregion

      #region Lightning Image Filter

      /// <summary>
      /// Create a lightning Effect on your Image
      /// The Image gehts lighter
      /// </summary>
      /// <param name="image"></param>
      /// <param name="alpha"></param>
      /// <returns></returns>
      public static Image LightningImage(Image image, int alpha)
      {

         if (alpha == null)
            alpha = 128;

         Bitmap bmp = new Bitmap(image);
         Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);

         using (Graphics g = Graphics.FromImage(bmp))
         {
            using (Brush cloud_brush = new SolidBrush(Color.FromArgb(alpha, Color.White)))
            {
               g.FillRectangle(cloud_brush, r);
            }
         }
         return bmp;
      }

      /// <summary>
      /// Create a lightning Effect on your Image
      /// The Image gehts lighter
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="alpha"></param>
      /// <returns></returns>
      public static Bitmap LightningImage(Bitmap bitmap, int alpha)
      {

         if (alpha == null)
            alpha = 128;

         Rectangle r = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

         using (Graphics g = Graphics.FromImage(bitmap))
         {
            using (Brush cloud_brush = new SolidBrush(Color.FromArgb(alpha, Color.White)))
            {
               g.FillRectangle(cloud_brush, r);
            }
         }
         return bitmap;
      }

      /// <summary>
      /// Create a darker Image Effect
      /// The Image gets darker
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="alpha"></param>
      /// <returns></returns>
      public static Bitmap DarkerImage(Bitmap bitmap, int alpha)
      {

         if (alpha == null)
            alpha = 128;

         Rectangle r = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

         using (Graphics g = Graphics.FromImage(bitmap))
         {
            using (Brush cloud_brush = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
            {
               g.FillRectangle(cloud_brush, r);
            }
         }

         return bitmap;
      }

      /// <summary>
      /// Create a darker Image Effect
      /// The Image gets darker
      /// </summary>
      /// <param name="image"></param>
      /// <param name="alpha"></param>
      /// <returns></returns>
      public static Image DarkerImage(Image image, int alpha)
      {

         if (alpha == null)
            alpha = 128;

         Bitmap bitmap = new Bitmap(image);

         Rectangle r = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

         using (Graphics g = Graphics.FromImage(bitmap))
         {
            using (Brush cloud_brush = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
            {
               g.FillRectangle(cloud_brush, r);
            }
         }

         return bitmap;
      }

      #endregion

      #region Image Overflow Filter

      /// <summary>
      /// The Image creates a Border Effect with itself
      /// </summary>
      /// <param name="image"></param>
      /// <returns></returns>
      public static Image CreateOverflowImage(Image image)
      {

         ImageAttributes imageAttributes = new ImageAttributes();
         int width = image.Width;
         int height = image.Height;

         float[][] colorMatrixElements = {
   new float[] {2,  0,  0,  0, 0},        // red scaling factor of 2
   new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
   new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
   new float[] {.2f, .2f, .2f, 0, 1}};    // three translations of 0.2

         ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

         imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

         Graphics graphics = Graphics.FromImage(image);

         graphics.DrawImage(image, 10, 10);
         graphics.DrawImage(image, 20, 20);
         graphics.DrawImage(image, 30, 30);
         graphics.DrawImage(image, 40, 40);

         graphics.DrawImage(
            image,
            new Rectangle(0, 0, width, height),  // destination rectangle
            0, 0,        // upper-left corner of source rectangle
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel,
            imageAttributes);

         return image;
      }

      /// <summary>
      /// The Image creates a Border Effect with itself
      /// </summary>
      /// <param name="bitmap"></param>
      /// <returns></returns>
      public static Bitmap CreateOverflowImage(Bitmap bitmap)
      {
         Image image = bitmap;
         ImageAttributes imageAttributes = new ImageAttributes();
         int width = bitmap.Width;
         int height = bitmap.Height;

         float[][] colorMatrixElements = {
   new float[] {2,  0,  0,  0, 0},        // red scaling factor of 2
   new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
   new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
   new float[] {.2f, .2f, .2f, 0, 1}};    // three translations of 0.2

         ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

         imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

         Graphics graphics = Graphics.FromImage(image);

         graphics.DrawImage(image, 10, 10);
         graphics.DrawImage(image, 20, 20);
         graphics.DrawImage(image, 30, 30);
         graphics.DrawImage(image, 40, 40);

         graphics.DrawImage(
            image,
            new Rectangle(0, 0, width, height),  // destination rectangle
            0, 0,        // upper-left corner of source rectangle
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel,
            imageAttributes);

         return new Bitmap(image);
      }

      //With other Images
      //NOT DONE
      private static Bitmap CreateOverflowImage(Bitmap bitmap, Bitmap[] images)
      {
         Image image = bitmap;
         ImageAttributes imageAttributes = new ImageAttributes();
         int width = bitmap.Width;
         int height = bitmap.Height;

         float[][] colorMatrixElements = {
   new float[] {2,  0,  0,  0, 0},        // red scaling factor of 2
   new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
   new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
   new float[] {.2f, .2f, .2f, 0, 1}};    // three translations of 0.2

         ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

         imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

         Graphics graphics = Graphics.FromImage(image);

         graphics.DrawImage(image, 10, 10);
         graphics.DrawImage(image, 20, 20);
         graphics.DrawImage(image, 30, 30);
         graphics.DrawImage(image, 40, 40);

         graphics.DrawImage(
            image,
            new Rectangle(0, 0, width, height),  // destination rectangle
            0, 0,        // upper-left corner of source rectangle
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel,
            imageAttributes);

         return new Bitmap(image);
      }

      #endregion

      #region Pixel Image Filter

      /// <summary>
      /// Create image with a Pixel Effect
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="pixelateSize"></param>
      /// <returns></returns>
      public static Bitmap CreatePixelatedImage(Bitmap bitmap, Int32 pixelateSize)
      {
         Bitmap pixelated = new Bitmap(bitmap.Width, bitmap.Height);
         Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

         // make an exact copy of the bitmap provided
         using (Graphics graphics = Graphics.FromImage(pixelated))
            graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);

         // look at every pixel in the rectangle while making sure we're within the image bounds
         for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < bitmap.Width; xx += pixelateSize)
         {
            for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < bitmap.Height; yy += pixelateSize)
            {
               Int32 offsetX = pixelateSize / 2;
               Int32 offsetY = pixelateSize / 2;

               // make sure that the offset is within the boundry of the image
               while (xx + offsetX >= bitmap.Width) offsetX--;
               while (yy + offsetY >= bitmap.Height) offsetY--;

               // get the pixel color in the center of the soon to be pixelated area
               Color pixel = pixelated.GetPixel(xx + offsetX, yy + offsetY);

               // for each pixel in the pixelate size, set it to the center color
               for (Int32 x = xx; x < xx + pixelateSize && x < bitmap.Width; x++)
                  for (Int32 y = yy; y < yy + pixelateSize && y < bitmap.Height; y++)
                     pixelated.SetPixel(x, y, pixel);
            }
         }

         return pixelated;
      }

      /// <summary>
      /// Create image with a Pixel Effect
      /// </summary>
      /// <param name="image"></param>
      /// <param name="pixelateSize"></param>
      /// <returns></returns>
      public static Image CreatePixelatedImage(Image image, Int32 pixelateSize)
      {
         Bitmap pixelated = new Bitmap(image.Width, image.Height);
         Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);

         // make an exact copy of the bitmap provided
         using (Graphics graphics = Graphics.FromImage(pixelated))
            graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

         // look at every pixel in the rectangle while making sure we're within the image bounds
         for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < image.Width; xx += pixelateSize)
         {
            for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < image.Height; yy += pixelateSize)
            {
               Int32 offsetX = pixelateSize / 2;
               Int32 offsetY = pixelateSize / 2;

               // make sure that the offset is within the boundry of the image
               while (xx + offsetX >= image.Width) offsetX--;
               while (yy + offsetY >= image.Height) offsetY--;

               // get the pixel color in the center of the soon to be pixelated area
               Color pixel = pixelated.GetPixel(xx + offsetX, yy + offsetY);

               // for each pixel in the pixelate size, set it to the center color
               for (Int32 x = xx; x < xx + pixelateSize && x < image.Width; x++)
                  for (Int32 y = yy; y < yy + pixelateSize && y < image.Height; y++)
                     pixelated.SetPixel(x, y, pixel);
            }
         }

         return pixelated;
      }

      /// <summary>
      /// Create image with a Pixel Effect
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="rectangle"></param>
      /// <param name="pixelateSize"></param>
      /// <returns></returns>
      public static Bitmap CreatePixelatedImage(Bitmap bitmap, Rectangle rectangle, Int32 pixelateSize)
      {
         Bitmap pixelated = new Bitmap(bitmap.Width, bitmap.Height);

         // make an exact copy of the bitmap provided
         using (Graphics graphics = Graphics.FromImage(pixelated))
            graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);

         // look at every pixel in the rectangle while making sure we're within the image bounds
         for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < bitmap.Width; xx += pixelateSize)
         {
            for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < bitmap.Height; yy += pixelateSize)
            {
               Int32 offsetX = pixelateSize / 2;
               Int32 offsetY = pixelateSize / 2;

               // make sure that the offset is within the boundry of the image
               while (xx + offsetX >= bitmap.Width) offsetX--;
               while (yy + offsetY >= bitmap.Height) offsetY--;

               // get the pixel color in the center of the soon to be pixelated area
               Color pixel = pixelated.GetPixel(xx + offsetX, yy + offsetY);

               // for each pixel in the pixelate size, set it to the center color
               for (Int32 x = xx; x < xx + pixelateSize && x < bitmap.Width; x++)
                  for (Int32 y = yy; y < yy + pixelateSize && y < bitmap.Height; y++)
                     pixelated.SetPixel(x, y, pixel);
            }
         }

         return pixelated;
      }

      /// <summary>
      /// Create image with a Pixel Effect
      /// </summary>
      /// <param name="image"></param>
      /// <param name="rectangle"></param>
      /// <param name="pixelateSize"></param>
      /// <returns></returns>
      public static Image CreatePixelatedImage(Image image, Rectangle rectangle, Int32 pixelateSize)
      {
         Bitmap pixelated = new Bitmap(image.Width, image.Height);

         // make an exact copy of the bitmap provided
         using (Graphics graphics = Graphics.FromImage(pixelated))
            graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

         // look at every pixel in the rectangle while making sure we're within the image bounds
         for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width && xx < image.Width; xx += pixelateSize)
         {
            for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height && yy < image.Height; yy += pixelateSize)
            {
               Int32 offsetX = pixelateSize / 2;
               Int32 offsetY = pixelateSize / 2;

               // make sure that the offset is within the boundry of the image
               while (xx + offsetX >= image.Width) offsetX--;
               while (yy + offsetY >= image.Height) offsetY--;

               // get the pixel color in the center of the soon to be pixelated area
               Color pixel = pixelated.GetPixel(xx + offsetX, yy + offsetY);

               // for each pixel in the pixelate size, set it to the center color
               for (Int32 x = xx; x < xx + pixelateSize && x < image.Width; x++)
                  for (Int32 y = yy; y < yy + pixelateSize && y < image.Height; y++)
                     pixelated.SetPixel(x, y, pixel);
            }
         }

         return pixelated;
      }

      #endregion

      #region Pixel Color Overwrite %

      /// <summary>
      /// Change all Pixels prozentual by Color Value
      /// </summary>
      /// <param name="r"></param>
      /// <param name="g"></param>
      /// <param name="b"></param>
      /// <param name="a"></param>
      /// <param name="treeTranslation"></param>
      /// <returns></returns>
      public static Image ChangeImageColorPixelProzentual(Image image, int r, int g, int b, int a, float treeTranslation)
      {
         if (treeTranslation == null)
            treeTranslation = .2f;

         ImageAttributes imageAttributes = new ImageAttributes();
         int width = image.Width;
         int height = image.Height;

         float[][] colorMatrixElements = {
   new float[] {2,  0,  0,  0, 0},        // red scaling factor of 2
   new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
   new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
   new float[] {.2f, .2f, .2f, 0, 1}};    // three translations of 0.2

         ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

         imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

         Graphics graphics = Graphics.FromImage(image);

         graphics.DrawImage(
            image,
            new Rectangle(0, 0, width, height),  // destination rectangle
            0, 0,        // upper-left corner of source rectangle
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel,
            imageAttributes);

         return image;
      }

      /// <summary>
      /// Change all Pixels prozentual by Color Value
      /// </summary>
      /// <param name="r"></param>
      /// <param name="g"></param>
      /// <param name="b"></param>
      /// <param name="a"></param>
      /// <param name="treeTranslation"></param>
      /// <returns></returns>
      public static Bitmap ChangeImageColorPixelProzentual(Bitmap bitmap, int r, int g, int b, int a, float treeTranslation)
      {
         if (treeTranslation == null)
            treeTranslation = .2f;

         Image image = bitmap;
         ImageAttributes imageAttributes = new ImageAttributes();
         int width = image.Width;
         int height = image.Height;

         float[][] colorMatrixElements = {
   new float[] {2,  0,  0,  0, 0},        // red scaling factor of 2
   new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
   new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
   new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
   new float[] {.2f, .2f, .2f, 0, 1}};    // three translations of 0.2

         ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

         imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

         Graphics graphics = Graphics.FromImage(image);

         graphics.DrawImage(
            image,
            new Rectangle(0, 0, width, height),  // destination rectangle
            0, 0,        // upper-left corner of source rectangle
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel,
            imageAttributes);

         return new Bitmap(image);
      }

      #endregion

      #region Matrix

      /// <summary>
      /// Get Color Matrix from Image
      /// </summary>
      /// <param name="bitmap"></param>
      /// <returns></returns>
      public static Color[][] GetImageColorMatrix(Bitmap bitmap)
      {

         int hight = bitmap.Height;
         int width = bitmap.Width;

         Color[][] colorMatrix = new Color[width][];
         for (int i = 0; i < width; i++)
         {
            colorMatrix[i] = new Color[hight];
            for (int j = 0; j < hight; j++)
            {
               colorMatrix[i][j] = bitmap.GetPixel(i, j);
               //Console.WriteLine(colorMatrix[i][j]);
            }
         }
         return colorMatrix;
      }

      /// <summary>
      /// Get Color Matrix from Image
      /// </summary>
      /// <param name="image"></param>
      /// <returns></returns>
      public static Color[][] GetImageColorMatrix(Image image)
      {

         Bitmap bitmap = new Bitmap(image);
         int hight = bitmap.Height;
         int width = bitmap.Width;

         Color[][] colorMatrix = new Color[width][];
         for (int i = 0; i < width; i++)
         {
            colorMatrix[i] = new Color[hight];
            for (int j = 0; j < hight; j++)
            {
               colorMatrix[i][j] = bitmap.GetPixel(i, j);
               //Console.WriteLine(colorMatrix[i][j]);
            }
         }
         return colorMatrix;
      }

      #endregion

      /// <summary>
      /// Create Image with rounded Corners
      /// </summary>
      /// <param name="image"></param>
      /// <param name="CornerRadius"></param>
      /// <param name="backgroundColor"></param>
      /// <returns></returns>
      public static Image CreateRoundedCornerImage(Image image, int CornerRadius, Color backgroundColor)
      {
         if (backgroundColor == null)
            backgroundColor = Color.FromArgb(0, 0, 0, 0);

         CornerRadius *= 2;
         Bitmap RoundedImage = new Bitmap(image.Width, image.Height);
         using (Graphics g = Graphics.FromImage(RoundedImage))
         {
            g.Clear(backgroundColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Brush brush = new TextureBrush(image);
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            g.FillPath(brush, gp);
            return RoundedImage;
         }
      }

      /// <summary>
      /// Create Image with rounded Corners
      /// </summary>
      /// <param name="bitmap"></param>
      /// <param name="CornerRadius"></param>
      /// <param name="backgroundColor"></param>
      /// <returns></returns>
      public static Bitmap CreateRoundedCornerImage(Bitmap bitmap, int CornerRadius, Color backgroundColor)
      {
         if (backgroundColor == null)
            backgroundColor = Color.FromArgb(0, 0, 0, 0);

         CornerRadius *= 2;
         Bitmap RoundedImage = new Bitmap(bitmap.Width, bitmap.Height);
         using (Graphics g = Graphics.FromImage(RoundedImage))
         {
            g.Clear(backgroundColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Brush brush = new TextureBrush(bitmap);
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            g.FillPath(brush, gp);
            return RoundedImage;
         }
      }

      /// <summary>
      /// Get the Meta Data from the Image
      /// </summary>
      /// <param name="image"></param>
      /// <returns></returns>
      public static string GetImageMetaData(Image image)
      {
         var userComment = Encoding.UTF8.GetString(image.GetPropertyItem(0x9286).Value);

         Console.WriteLine(userComment);

         return userComment;
      }

      /// <summary>
      /// Create Argb Copy of Image
      /// </summary>
      /// <param name="sourceImage"></param>
      /// <returns></returns>
      private static Bitmap GetArgbCopy(Image sourceImage)
      {
         Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);


         using (Graphics graphics = Graphics.FromImage(bmpNew))
         {
            graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), GraphicsUnit.Pixel);
            graphics.Flush();
         }


         return bmpNew;
      }

      /// <summary>
      /// Apply Color Matrix to Image
      /// </summary>
      /// <param name="sourceImage"></param>
      /// <param name="colorMatrix"></param>
      /// <returns></returns>
      private static Bitmap ApplyColorMatrix(Image sourceImage, ColorMatrix colorMatrix)
      {
         Bitmap bmp32BppSource = GetArgbCopy(sourceImage);
         Bitmap bmp32BppDest = new Bitmap(bmp32BppSource.Width, bmp32BppSource.Height, PixelFormat.Format32bppArgb);


         using (Graphics graphics = Graphics.FromImage(bmp32BppDest))
         {
            ImageAttributes bmpAttributes = new ImageAttributes();
            bmpAttributes.SetColorMatrix(colorMatrix);

            graphics.DrawImage(bmp32BppSource, new Rectangle(0, 0, bmp32BppSource.Width, bmp32BppSource.Height),
                                0, 0, bmp32BppSource.Width, bmp32BppSource.Height, GraphicsUnit.Pixel, bmpAttributes);


         }


         bmp32BppSource.Dispose();


         return bmp32BppDest;
      }

   }
}
