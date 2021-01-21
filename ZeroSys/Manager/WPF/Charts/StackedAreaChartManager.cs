using LiveCharts;
using LiveCharts.Wpf;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// StackedAreaChartManager
   /// </summary>
   public class StackedAreaChartManager
   {

      //Labels

      //
      public StackedAreaSeries CreateNewStackedAreaSerie(string title, double[] values)
      {
         StackedAreaSeries stackedAreaSeries = new StackedAreaSeries()
         {
            Title = title,
            Values = new ChartValues<double>(values)
         };
         return stackedAreaSeries;
      }

      //
      public void AddStackedAreaSerieToStackedAreaChart(CartesianChart cartesianChart, ColumnSeries columnSeries)
      {
         cartesianChart.Series.Add(columnSeries);
      }

   }
}
