using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ZeroSys.Manager
{
    /// <summary>
    /// ColorManager
    /// </summary>
    public class ColorManager
    {

        //x stufen farb ton bekommen

        /// <summary>
        /// Create Shadow Effect
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <param name="direction"></param>
        /// <param name="depth"></param>
        /// <param name="opacity"></param>
        /// <returns></returns>
        public static DropShadowEffect ShadowEffect(byte r, byte g, byte b, byte a, int direction, int depth, int opacity)
        {
            DropShadowEffect shadowEffect = new DropShadowEffect()
            {
                Color = new Color { A = a, R = r, G = g, B = b },
                Direction = direction,
                ShadowDepth = depth,
                Opacity = opacity
            };
            return shadowEffect;
        }

        /// <summary>
        /// Create Shadwo Effect
        /// </summary>
        /// <param name="color"></param>
        /// <param name="direction"></param>
        /// <param name="depth"></param>
        /// <param name="opacity"></param>
        /// <returns></returns>
        public static DropShadowEffect ShadowEffect(Color color, int direction, int depth, int opacity)
        {
            DropShadowEffect shadowEffect = new DropShadowEffect()
            {
                Color = color,
                Direction = direction,
                ShadowDepth = depth,
                Opacity = opacity
            };
            return shadowEffect;
        }

    }
}
