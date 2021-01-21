using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// ColumnChartManager
   /// </summary>
   public class ColumnChartManager
   {

      //https://lvcharts.net/App/examples/v1/wpf/Basic%20Column

      //how to bind - LABEL

      //
      public ColumnSeries CreateNewColumnSerie(string title, double[] values)
      {
         ColumnSeries columnSeries = new ColumnSeries()
         {
            Title = title,
            Values = new ChartValues<double>(values)
         };
         return columnSeries;
      }

      //
      public ColumnSeries CreateNewColumnSerie(string title, double[] values, Brush brush)
      {
         ColumnSeries columnSeries = new ColumnSeries()
         {
            Title = title,
            Values = new ChartValues<double>(values),
            Fill = brush
         };
         return columnSeries;
      }

      //
      public void AddColumnSerieToColumnChart(CartesianChart cartesianChart, ColumnSeries columnSeries)
      {
         cartesianChart.Series.Add(columnSeries);
      }

   }
}
