using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// DoughnutChartManager
   /// </summary>
   public class DoughnutChartManager
   {

      //CLICK UPDATE...

      //
      public PieSeries CreateNewDoughnutSerie(string title, double value)
      {
         PieSeries columnSeries = new PieSeries()
         {
            Title = title,
            Values = new ChartValues<ObservableValue> { new ObservableValue(value) },
            DataLabels = true
         };
         return columnSeries;
      }

      //
      public void AddDoughnutSerieToDoughnutChart(CartesianChart cartesianChart, PieSeries pieSeries)
      {
         cartesianChart.Series.Add(pieSeries);
      }

      #region Click Update

      //public SeriesCollection SeriesCollection { get; set; }

      //private void UpdateAllOnClick(object sender, RoutedEventArgs e)
      //{
      //   var r = new Random();

      //   foreach (var series in SeriesCollection)
      //   {
      //      foreach (var observable in series.Values.Cast<ObservableValue>())
      //      {
      //         observable.Value = r.Next(0, 10);
      //      }
      //   }
      //}

      //private void AddSeriesOnClick(object sender, RoutedEventArgs e)
      //{
      //   var r = new Random();
      //   var c = SeriesCollection.Count > 0 ? SeriesCollection[0].Values.Count : 5;

      //   var vals = new ChartValues<ObservableValue>();

      //   for (var i = 0; i < c; i++)
      //   {
      //      vals.Add(new ObservableValue(r.Next(0, 10)));
      //   }

      //   SeriesCollection.Add(new PieSeries
      //   {
      //      Values = vals
      //   });
      //}

      //private void RemoveSeriesOnClick(object sender, RoutedEventArgs e)
      //{
      //   if (SeriesCollection.Count > 0)
      //      SeriesCollection.RemoveAt(0);
      //}

      //private void AddValueOnClick(object sender, RoutedEventArgs e)
      //{
      //   var r = new Random();
      //   foreach (var series in SeriesCollection)
      //   {
      //      series.Values.Add(new ObservableValue(r.Next(0, 10)));
      //   }
      //}

      //private void RemoveValueOnClick(object sender, RoutedEventArgs e)
      //{
      //   foreach (var series in SeriesCollection)
      //   {
      //      if (series.Values.Count > 0)
      //         series.Values.RemoveAt(0);
      //   }
      //}

      //private void RestartOnClick(object sender, RoutedEventArgs e)
      //{
      //   Chart.Update(true, true);
      //}

      #endregion

   }
}
