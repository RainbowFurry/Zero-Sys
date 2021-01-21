using LiveCharts;
using LiveCharts.Wpf;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// StackedChartManager
   /// </summary>
   public class StackedChartManager
   {

      // Labels = new[] {"Chrome", "Mozilla", "Opera", "IE"};
      //Formatter = value => value + " Mill";

      //
      public StackedColumnSeries CreateNewStackedSeries(string title, double[] values)
      {
         StackedColumnSeries stackedColumnSeries = new StackedColumnSeries()
         {
            Title = title,
            Values = new ChartValues<double>(values),
            StackMode = StackMode.Values,
            DataLabels = true
         };
         return stackedColumnSeries;
      }

      //
      public void AddStackedSerieToStackedChart(CartesianChart cartesianChart, StackedColumnSeries columnSeries)
      {
         cartesianChart.Series.Add(columnSeries);
      }

   }
}
