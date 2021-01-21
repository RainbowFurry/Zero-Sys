using System.Drawing;

namespace ZeroSys.Manager.Images
{
    /// <summary>
    /// GraphicsManager
    /// </summary>
    public class GraphicsManager
    {

        //save graphic

        private Graphics graphics;
        private Bitmap bitmap;

        /// <summary>
        /// Create new empty Graphics
        /// </summary>
        /// <param name="imgWidth"></param>
        /// <param name="imgHeight"></param>
        public GraphicsManager(int imgWidth, int imgHeight)
        {
            bitmap = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            graphics = Graphics.FromImage(bitmap);
        }

        /// <summary>
        /// Load Own Graphics maby from File?
        /// </summary>
        /// <param name="graphics"></param>
        public GraphicsManager(Graphics graphics)
        {
            this.graphics = graphics;
        }

        /// <summary>
        /// Create drawing Pen
        /// </summary>
        /// <param name="color"></param>
        /// <param name="thicknes"></param>
        /// <returns></returns>
        public Pen CreatePen(Color color, int thicknes)
        {
            return new Pen(color, thicknes);
        }

        /// <summary>
        /// Draw a Rectangle
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="stopX"></param>
        /// <param name="stopY"></param>
        public void DrawRectangle(Pen pen, int startX, int startY, int stopX, int stopY)
        {
            Rectangle rectangle = new Rectangle(startX, startY, stopX, stopY);
            graphics.DrawRectangle(pen, rectangle);
        }

        /// <summary>
        /// Draw a Rectangle Filled out
        /// </summary>
        /// <param name="color"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="stopX"></param>
        /// <param name="stopY"></param>
        public void DrawRectangle(Color color, int startX, int startY, int stopX, int stopY)
        {
            Rectangle rectangle = new Rectangle(startX, startY, stopX, stopY);
            graphics.FillRectangle(new SolidBrush(color), rectangle);
        }

        /// <summary>
        /// Draw a Circle
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="stopX"></param>
        /// <param name="stopY"></param>
        public void DrawCircle(Pen pen, int startX, int startY, int stopX, int stopY)
        {
            Rectangle myRectangle = new Rectangle(startX, startY, stopX, stopY);
            graphics.DrawEllipse(pen, myRectangle);
        }

        /// <summary>
        /// Draw a Circle Filled out
        /// </summary>
        /// <param name="color"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="stopX"></param>
        /// <param name="stopY"></param>
        public void DrawCircle(Color color, int startX, int startY, int stopX, int stopY)
        {
            Rectangle myRectangle = new Rectangle(startX, startY, stopX, stopY);
            graphics.FillEllipse(new SolidBrush(color), myRectangle);
        }

        /// <summary>
        /// Draw a Pie
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="stopX"></param>
        /// <param name="stopY"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public void DrawPie(Pen pen, int startX, int startY, int stopX, int stopY, float start, float stop)
        {
            Rectangle myRectangle = new Rectangle(startX, startY, stopX, stopY);
            graphics.DrawPie(pen, myRectangle, start, stop);
        }

        /// <summary>
        /// Draw a Pie Filled out
        /// </summary>
        /// <param name="color"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="stopX"></param>
        /// <param name="stopY"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public void DrawPie(Color color, int startX, int startY, int stopX, int stopY, float start, float stop)
        {
            Rectangle myRectangle = new Rectangle(startX, startY, stopX, stopY);
            graphics.FillPie(new SolidBrush(color), myRectangle, start, stop);
        }

        /// <summary>
        /// Draw a Polygon
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="points"></param>
        public void DrawPolygon(Pen pen, PointF[] points)
        {
            graphics.DrawPolygon(pen, points);
        }

        /// <summary>
        /// Draw a Polygon Filled out
        /// </summary>
        /// <param name="color"></param>
        /// <param name="points"></param>
        public void DrawPolygon(Color color, PointF[] points)
        {
            graphics.FillPolygon(new SolidBrush(color), points);
        }

        /// <summary>
        /// Create Point/Marker
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Point CreatePoint(int x, int y)
        {
            return new Point(x, y);
        }

        /// <summary>
        /// Draw a Line (not take a line)
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="stopX"></param>
        /// <param name="stopY"></param>
        public void DrawLine(Pen pen, int startX, int startY, int stopX, int stopY)
        {
            graphics.DrawLine(pen, startX, startY, stopX, stopY);
        }

        /// <summary>
        /// Draw a Text
        /// </summary>
        /// <param name="content"></param>
        /// <param name="textColor"></param>
        /// <param name="fontName"></param>
        /// <param name="fontSize"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public void DrawText(string content, Color textColor, string fontName, int fontSize, int startX, int startY)
        {
            Font font = new Font(fontName, fontSize, FontStyle.Regular);
            Brush brush = new SolidBrush(textColor);
            graphics.DrawString(content, font, brush, startX, startY);
        }

        /// <summary>
        /// Draw a Text
        /// </summary>
        /// <param name="content"></param>
        /// <param name="textColor"></param>
        /// <param name="font"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public void DrawText(string content, Color Color, Font font, int startX, int startY)
        {
            Brush brush = new SolidBrush(Color);
            graphics.DrawString(content, font, brush, startX, startY);
        }

        /// <summary>
        /// Return your Created Graphics
        /// </summary>
        /// <returns></returns>
        public Graphics Build()
        {
            return graphics;
        }

        /// <summary>
        /// Save as Image
        /// </summary>
        /// <param name="savePath"></param>
        public void Save(string savePath)
        {
            bitmap.Save(savePath);
        }

    }
}
