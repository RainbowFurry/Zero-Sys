using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZeroSys.Manager.Images
{
    /// <summary>
    /// Load SVG Image to the View Object
    /// </summary>
    public class LoadSVG
    {
        /// <summary>
        /// Load the SVG to the Image Object
        /// </summary>
        /// <param name="svgFile"></param>
        /// <param name="source"></param>
        public static void Load(string svgFile, Image source)
        {
            WpfDrawingSettings settings = new WpfDrawingSettings
            {
                TextAsGeometry = true
            };

            FileSvgReader converter = new FileSvgReader(settings);
            DrawingGroup drawing = converter.Read(svgFile);

            if (drawing != null)
                source.Source = new DrawingImage(drawing);
        }

    }
}
