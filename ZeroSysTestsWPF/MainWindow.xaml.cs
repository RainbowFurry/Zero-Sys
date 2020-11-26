using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using ZeroSys.Manager.WPF.Charts;

namespace ZeroSysTestsWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Init
        /// </summary>
        public MainWindow()
        {

            InitializeComponent();

            //...


            //GraphicsManager gm = new GraphicsManager(1920, 1080);
            //System.Drawing.Pen penRed = gm.CreatePen(System.Drawing.Color.Red, 4);
            //System.Drawing.Pen penBlue = gm.CreatePen(System.Drawing.Color.Blue, 4);
            //System.Drawing.Pen penGreen = gm.CreatePen(System.Drawing.Color.Green, 4);

            ////PointF[] points = new PointF[] { gm.CreatePoint(0, 0), gm.CreatePoint(400, 900), gm.CreatePoint(1500, 800), gm.CreatePoint(1200, 600), gm.CreatePoint(600, 600) };
            //PointF[] points = new PointF[] { gm.CreatePoint(0, 0), gm.CreatePoint(400, 900), gm.CreatePoint(1500, 800), gm.CreatePoint(1200, 600), gm.CreatePoint(600, 600), gm.CreatePoint(300, 200), gm.CreatePoint(700, 900) };

            ////gm.DrawPolygon(penRed, points);
            //gm.DrawPolygon(System.Drawing.Color.Red, points);

            //gm.DrawText("JasonJT", System.Drawing.Color.Blue, "Arial", 50, 800, 800);

            //gm.DrawCircle(penRed, 0, 0, 400, 500);
            //gm.DrawCircle(penBlue, 0, 0, 500, 400);
            //gm.DrawCircle(penGreen, 0, 0, 500, 500);


            //gm.DrawRectangle(pen, 0, 0, 600, 600);
            //gm.DrawRectangle(pen, 0, 0, 700, 700);
            //gm.DrawRectangle(pen, 0, 0, 800, 800);
            //gm.DrawRectangle(pen, 0, 0, 900, 900);
            //gm.DrawRectangle(System.Drawing.Color.Red, 0, 0, 900, 900);
            //gm.DrawRectangle(System.Drawing.Color.Yellow, 0, 0, 800, 800);
            //gm.DrawRectangle(System.Drawing.Color.Blue, 0, 0, 700, 700);
            //gm.DrawRectangle(System.Drawing.Color.Orange, 0, 0, 600, 600);

            //gm.Save(@"C:\Users\DarkS\Documents\HeimServer\Test.png");
            gm.Save(@"C:\Users\DarkS\Documents\HeimServer\" + Guid.NewGuid().ToString() + ".png");

        }

        private void GaugeCh()
        {
            var converter = new BrushConverter();
            var brushWater = (System.Windows.Media.Brush)converter.ConvertFromString("#333");

            GaugeChartManager g = new GaugeChartManager();
            g.CreateNewGaugeChart(TestChart, 0, 100, 52, brushWater, true);
        }

        private void Angular()
        {
            ////convert color to brush...
            //var converter = new BrushConverter();
            //var brushWater = (System.Windows.Media.Brush)converter.ConvertFromString("#108de6");

            //PointerChartManager pcm = new PointerChartManager();
            //pcm.AddSettingsToPointerChart(TestChart, 0, 100, 10, 32);
            //pcm.AddPointerSerieToPointerChart(TestChart, pcm.CreateNewPointerSeries(0, 38, brushWater));
        }

        private void GraphicTest()
        {

            //GraphicsManager gm = new GraphicsManager(1920, 1080);
            //System.Drawing.Pen penRed = gm.CreatePen(System.Drawing.Color.Red, 4);
            //System.Drawing.Pen penBlue = gm.CreatePen(System.Drawing.Color.Blue, 4);
            //System.Drawing.Pen penGreen = gm.CreatePen(System.Drawing.Color.Green, 4);

            //PointF[] points = new PointF[] { gm.CreatePoint(0, 0), gm.CreatePoint(400, 900), gm.CreatePoint(1500, 800) };

            //gm.DrawPolygon(penRed, points);
            //gm.DrawPolygon(System.Drawing.Color.Red, points);


            //gm.DrawCircle(penRed, 0, 0, 400, 500);
            //gm.DrawCircle(penBlue, 0, 0, 500, 400);
            //gm.DrawCircle(penGreen, 0, 0, 500, 500);


            //gm.DrawRectangle(pen, 0, 0, 600, 600);
            //gm.DrawRectangle(pen, 0, 0, 700, 700);
            //gm.DrawRectangle(pen, 0, 0, 800, 800);
            //gm.DrawRectangle(pen, 0, 0, 900, 900);
            //gm.DrawRectangle(System.Drawing.Color.Red, 0, 0, 900, 900);
            //gm.DrawRectangle(System.Drawing.Color.Yellow, 0, 0, 800, 800);
            //gm.DrawRectangle(System.Drawing.Color.Blue, 0, 0, 700, 700);
            //gm.DrawRectangle(System.Drawing.Color.Orange, 0, 0, 600, 600);

            //gm.Save(@"C:\Users\DarkS\Documents\HeimServer\Test.png");


        }

        private void myHeatSerieChart()
        {

            //string[] t = new string[] {
            //"Monday",
            //"Tuesday"};

            //string[] t2 = new string[] {
            //      "Test1",
            //      "Test2"};

            //Color[] c = new Color[] { Color.FromArgb(12, 22, 44, 200) };

            //HeatSeriesChartManager hscm = new HeatSeriesChartManager();
            //hscm.AddDescriptionsToHeatSeries(t, t2);
            //hscm.AddHeatSerieToHeatChart(TestChart, hscm.CreateNewHeatSeries("Te1", 0, 0, 8));
            //hscm.AddHeatSerieToHeatChart(TestChart, hscm.CreateNewHeatSeries("Te2", 0, 1, 2));
        }

        private void myMapChart()
        {
            //MapChartManager mcm = new MapChartManager();
            //mcm.AddNewMapSeries("DE", 18);
            //mcm.AddNewMapSeries("US", 40);
            //mcm.AddNewMapSeries("RU", 90);
            //mcm.AddNewMapSeries("AU", 2);
            //mcm.AddMapSeriesToMapChart(TestChart);
        }

        private void myPieChart()
        {
            //PieChartManager pm = new PieChartManager();
            //TestChart.Series.Add(pm.CreateNewPieSeries("Test2", 8));
        }

        private void GeoMapOriginal()
        {
            //var r = new Random();

            //Values = new Dictionary<string, double>();

            //Values["MX"] = r.Next(0, 100);
            //Values["CA"] = r.Next(0, 100);
            //Values["US"] = r.Next(0, 100);
            //Values["IN"] = r.Next(0, 100);
            //Values["CN"] = r.Next(0, 100);
            //Values["JP"] = r.Next(0, 100);
            //Values["BR"] = r.Next(0, 100);
            //Values["DE"] = r.Next(0, 100);
            //Values["FR"] = r.Next(0, 100);
            //Values["GB"] = r.Next(0, 100);
            //Values["IT"] = r.Next(0, 100);
            //Values["RU"] = r.Next(0, 100);
            //Values["AU"] = r.Next(0, 100);

            //TestChart.HeatMap = Values;
            //TestChart.Source = Directory.GetCurrentDirectory() + @"\src\Maps\World.xml";
        }

        public Dictionary<string, double> Values { get; set; }
        public Dictionary<string, string> LanguagePack { get; set; }

    }
}
