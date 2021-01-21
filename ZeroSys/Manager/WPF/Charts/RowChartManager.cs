using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// RowChartManager
   /// </summary>
   public class RowChartManager
   {

      // Labels = new[] {"Chrome", "Mozilla", "Opera", "IE"};
      //Formatter = value => value + " Mill";


      //
      public RowSeries CreateNewRowSerie(string title, double[] values)
      {
         RowSeries rowSeries = new RowSeries()
         {
            Title = title,
            Values = new ChartValues<double>(values)
         };
         return rowSeries;
      }

      //
      public RowSeries CreateNewRowSerie(string title, double[] values, Brush brush)
      {
         RowSeries rowSeries = new RowSeries()
         {
            Title = title,
            Values = new ChartValues<double>(values),
            Fill = brush
         };
         return rowSeries;
      }

      //
      public void AddRowSerieToRowChart(CartesianChart cartesianChart, RowSeries rowSeries)
      {
         cartesianChart.Series.Add(rowSeries);
      }

   }
}
