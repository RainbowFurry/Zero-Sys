using System;
using System.Drawing;

namespace ZeroSys.Converter
{
    /// <summary>
    /// ColorConverter
    /// </summary>
    public class ColorConverter
    {

        /// <summary>
        /// Convert Color from Hexa to RGBA
        /// </summary>
        /// <param name="hexa"></param>
        /// <returns></returns>
        public static Color FromHexToRGBA(string hexa)
        {
            Color color = new Color();
            color = ColorTranslator.FromHtml(hexa);
            Console.WriteLine(color);
            return color;
        }

        /// <summary>
        /// Convert Color from RGBA to Hexa
        /// </summary>
        /// <param name="rgba"></param>
        /// <returns></returns>
        public static Color FromRGBAToHex(Color rgba)
        {
            Color color;
            color = ColorTranslator.FromHtml("#" + rgba.A + rgba.R + rgba.G + rgba.B);
            Console.WriteLine(color);
            return color;
            //ColorTranslator.ToHtml(Color.FromArgb(1, 33, 33, 33))
        }

        /// <summary>
        /// Convert Color from RGBA to Hexa
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Color FromRGBAToHex(string r, string g, string b, string a)
        {
            Color color = new Color();
            color = ColorTranslator.FromHtml("#" + r + g + b + a);
            Console.WriteLine(color);
            return color;
        }

    }
}
