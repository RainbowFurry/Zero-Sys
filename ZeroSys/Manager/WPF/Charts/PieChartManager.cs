using LiveCharts;
using LiveCharts.Wpf;
using System;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// PieChartManager
   /// </summary>
   public class PieChartManager
   {

      //https://lvcharts.net/App/examples/v1/wpf/Pie%20Chart

      //Values = new ChartValues<DateTimePoint>
      //Color?

      /// <summary>
      /// Create new Pie Chart Serie
      /// </summary>
      /// <param name="title"></param>
      /// <param name="value"></param>
      /// <returns></returns>
      public PieSeries CreateNewPieSeries(string title, double value)
      {

         PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

         PieSeries pieSeries = new PieSeries();
         pieSeries.Title = title;
         pieSeries.DataLabels = true;
         pieSeries.Values = new ChartValues<double>() { value };
         pieSeries.LabelPoint = PointLabel;

         return pieSeries;
      }

      /// <summary>
      /// Add PieSeries to PieChart
      /// </summary>
      /// <param name="pieChart"></param>
      /// <param name="pieSeries"></param>
      public void AddPieSerieToPieChart(PieChart pieChart, PieSeries pieSeries)
      {
         pieChart.Series.Add(pieSeries);
      }

      /// <summary>
      /// Add PieChart click Management
      /// </summary>
      /// <param name="pieChart"></param>
      public void AddChartClickManagement(PieChart pieChart)
      {
         pieChart.DataClick += Chart_OnDataClick;
      }

      /// <summary>
      /// Pointer for Marker
      /// </summary>
      public Func<ChartPoint, string> PointLabel { get; set; }

      private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
      {
         var chart = (PieChart)chartpoint.ChartView;

         //clear selected slice.
         foreach (PieSeries series in chart.Series)
            series.PushOut = 0;

         var selectedSeries = (PieSeries)chartpoint.SeriesView;
         selectedSeries.PushOut = 8;
      }

   }
}
