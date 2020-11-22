using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ZeroSys.Manager.WPF
{
    /// <summary>
    /// Load SVG Image to the View Object
    /// </summary>
    public class LoadSVGImage
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

        /// <summary>
        /// Load the SVG to the Rectangle Object
        /// </summary>
        /// <param name="svgFile"></param>
        /// <param name="rectangle"></param>
        public static void LoadSvgImage(string svgFile, Rectangle rectangle)
        {
            WpfDrawingSettings settings = new WpfDrawingSettings
            {
                TextAsGeometry = true
            };

            FileSvgReader converter = new FileSvgReader(settings);
            DrawingGroup drawing = converter.Read(svgFile);

            if (drawing != null)
                rectangle.Fill = new ImageBrush()
                {
                    ImageSource = new DrawingImage(drawing)
                };
        }

        /// <summary>
        /// Load the SVG to the Grid Object
        /// </summary>
        /// <param name="svgFile"></param>
        /// <param name="grid"></param>
        public static void LoadSvgImage(string svgFile, Grid grid)
        {
            WpfDrawingSettings settings = new WpfDrawingSettings
            {
                TextAsGeometry = true
            };

            FileSvgReader converter = new FileSvgReader(settings);
            DrawingGroup drawing = converter.Read(svgFile);

            if (drawing != null)
                grid.Background = new ImageBrush()
                {
                    ImageSource = new DrawingImage(drawing)
                };
        }

    }
}
