using System;
using System.Drawing;

namespace ZeroSys.Converter
{
   public class ColorCode
   {

      public static Color FromHexToRGBA(string hexa)
      {
         Color color = new Color();
         color = ColorTranslator.FromHtml(hexa);
         Console.WriteLine(color);
         return color;
      }

      public static Color FromRGBAToHex(Color rgba)
      {
         Color color;
         color = ColorTranslator.FromHtml("#" + rgba.A + rgba.R + rgba.G + rgba.B);
         Console.WriteLine(color);
         return color;
         //ColorTranslator.ToHtml(Color.FromArgb(1, 33, 33, 33))
      }

      public static Color FromRGBAToHex(string r, string g, string b, string a)
      {
         Color color = new Color();
         color = ColorTranslator.FromHtml("#" + r + g + b + a);
         Console.WriteLine(color);
         return color;
      }

   }
}
