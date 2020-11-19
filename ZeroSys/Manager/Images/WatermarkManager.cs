using System.Drawing;

namespace ZeroSys.Manager.Images
{
   /// <summary>
   /// WatermarkManager
   /// </summary>
   public class WatermarkManager
   {

      /// <summary>
      /// Create Image Watermark
      /// </summary>
      /// <param name="imagePath"></param>
      /// <param name="watermarkText"></param>
      public static void CreateWatermark(string imagePath, string watermarkText)
      {
         string root = @"C:\Users\jhoffmann\Desktop\Server\Wolf.jpg";
         string saveto = @"C:\Users\jhoffmann\Desktop\Server\Wolf2.jpg";

         Image bitmap = Bitmap.FromFile(root); // set image     
         Font font = new Font("Arial", 20, FontStyle.Italic, GraphicsUnit.Pixel);
         Color color = Color.FromArgb(255, 255, 0, 0);
         Point atpoint = new Point(bitmap.Width / 2, bitmap.Height / 2);
         SolidBrush brush = new SolidBrush(color);
         Graphics graphics = Graphics.FromImage(bitmap);
         StringFormat sf = new StringFormat();
         sf.Alignment = StringAlignment.Center;
         sf.LineAlignment = StringAlignment.Center;
         graphics.DrawString(watermarkText, font, brush, atpoint, sf);
         graphics.Dispose();
         System.IO.MemoryStream m = new System.IO.MemoryStream();
         bitmap.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
         byte[] convertedToBytes = m.ToArray();
         System.IO.File.WriteAllBytes(saveto, convertedToBytes);
      }

      /// <summary>
      /// Create Image Watermark
      /// </summary>
      /// <param name="imagePath"></param>
      /// <param name="watermarkText"></param>
      /// <param name="color"></param>
      public static void CreateWatermark(string imagePath, string watermarkText, Color color)
      {
         string root = @"C:\Users\jhoffmann\Desktop\Server\Wolf.jpg";
         string saveto = @"C:\Users\jhoffmann\Desktop\Server\Wolf2.jpg";

         Image bitmap = Bitmap.FromFile(root); // set image     
         Font font = new Font("Arial", 20, FontStyle.Italic, GraphicsUnit.Pixel);
         Point atpoint = new Point(bitmap.Width / 2, bitmap.Height / 2);//Text Centered
         SolidBrush brush = new SolidBrush(color);
         Graphics graphics = Graphics.FromImage(bitmap);
         StringFormat sf = new StringFormat();
         sf.Alignment = StringAlignment.Center;
         sf.LineAlignment = StringAlignment.Center;
         graphics.DrawString(watermarkText, font, brush, atpoint, sf);
         graphics.Dispose();
         System.IO.MemoryStream m = new System.IO.MemoryStream();
         bitmap.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
         byte[] convertedToBytes = m.ToArray();
         System.IO.File.WriteAllBytes(saveto, convertedToBytes);
      }

      /// <summary>
      /// Create Image Watermark
      /// </summary>
      /// <param name="imagePath"></param>
      /// <param name="watermarkText"></param>
      /// <param name="color"></param>
      /// <param name="font"></param>
      public static void CreateWatermark(string imagePath, string watermarkText, Color color, Font font)
      {
         string root = @"C:\Users\jhoffmann\Desktop\Server\Wolf.jpg";
         string saveto = @"C:\Users\jhoffmann\Desktop\Server\Wolf2.jpg";

         Image bitmap = Bitmap.FromFile(root); // set image
         Point atpoint = new Point(bitmap.Width / 2, bitmap.Height / 2);//Text Centered
         SolidBrush brush = new SolidBrush(color);
         Graphics graphics = Graphics.FromImage(bitmap);
         StringFormat sf = new StringFormat();
         sf.Alignment = StringAlignment.Center;
         sf.LineAlignment = StringAlignment.Center;
         graphics.DrawString(watermarkText, font, brush, atpoint, sf);
         graphics.Dispose();
         System.IO.MemoryStream m = new System.IO.MemoryStream();
         bitmap.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
         byte[] convertedToBytes = m.ToArray();
         System.IO.File.WriteAllBytes(saveto, convertedToBytes);
      }

   }
}
