using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// SeriesChartManager
   /// </summary>
   public class HeatSeriesChartManager
   {

      //Change color...

      public ChartValues<HeatPoint> Values { get; set; }
      public string[] LeftValues { get; set; }
      public string[] BottomValues { get; set; }

      /// <summary>
      /// Initialize HeatSeriesChartManager
      /// </summary>
      public HeatSeriesChartManager()
      {
         Values = new ChartValues<HeatPoint>();
      }

      /// <summary>
      /// Create new Heat Seria
      /// </summary>
      /// <param name="title"></param>
      /// <param name="row"></param>
      /// <param name="col"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public HeatSeries CreateNewHeatSeries(string title, int row, int col, int value)
      {

         Values.Add(new HeatPoint(row, col, value));

         HeatSeries heatSeries = new HeatSeries()
         {
            Title = title,
            Values = Values,
            GradientStopCollection = new System.Windows.Media.GradientStopCollection(),
         };
         return heatSeries;
      }

      //
      public HeatSeries CreateNewHeatSeries(string title, int row, int col, int value, Color[] color)
      {

         GradientStopCollection gr = new GradientStopCollection();
         foreach (Color c in color)
         {
            gr.Add(new GradientStop(c, 0));
         }
         //new GradientStop(Color.FromRgb(0, 0, 0), 0),
         //new GradientStop(Color.FromRgb(0, 255, 0), .25),
         //new GradientStop(Color.FromRgb(0, 0, 255), .5),
         //new GradientStop(Color.FromRgb(255, 0, 0), .75),
         //new GradientStop(Color.FromRgb(255, 255, 255), 1)


         Values.Add(new HeatPoint(row, col, value));

         HeatSeries heatSeries = new HeatSeries()
         {
            Title = title,
            Values = Values,
            GradientStopCollection = gr,
         };
         return heatSeries;
      }

      /// <summary>
      /// Bind Description to Chart
      /// </summary>
      /// <param name="leftValues"></param>
      /// <param name="bottomValues"></param>
      public void AddDescriptionsToHeatSeries(string[] leftValues, string[] bottomValues)
      {
         BottomValues = bottomValues;
         LeftValues = leftValues;
      }

      /// <summary>
      /// Set Created Values to Chart
      /// </summary>
      /// <param name="cartesianChart"></param>
      /// <param name="heatSeries"></param>
      public void AddHeatSerieToHeatChart(CartesianChart cartesianChart, HeatSeries heatSeries)
      {

         //cartesianChart.AxisX.Add(new Axis
         //{
         //   LabelsRotation = -15,
         //   Labels = LeftValues,
         //   Separator = new Separator { Step = 1 }
         //});

         //cartesianChart.AxisY.Add(new Axis
         //{
         //   Labels = RightValues
         //});

         cartesianChart.Series.Add(heatSeries);
      }

   }
}
