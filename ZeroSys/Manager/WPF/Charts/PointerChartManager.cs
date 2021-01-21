using LiveCharts.Wpf;
using System.Windows.Media;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// PointerChartManager
   /// </summary>
   public class PointerChartManager
   {

      /// <summary>
      /// Create new Pointer Serie
      /// </summary>
      /// <param name="from"></param>
      /// <param name="to"></param>
      /// <param name="brush"></param>
      /// <returns></returns>
      public AngularSection CreateNewPointerSeries(int from, int to, Brush brush)
      {
         AngularSection angularSection = new AngularSection()
         {
            FromValue = from,
            ToValue = to,
            Fill = brush,
         };
         return angularSection;
      }

      /// <summary>
      /// Add Pointer Series to Pointer Chart
      /// </summary>
      /// <param name="angularGauge"></param>
      /// <param name="angularSection"></param>
      public void AddPointerSerieToPointerChart(AngularGauge angularGauge, AngularSection angularSection)
      {
         angularGauge.Sections.Add(angularSection);
      }

      /// <summary>
      /// Add Settings to Pointer Chart
      /// </summary>
      /// <param name="angularGauge"></param>
      /// <param name="min"></param>
      /// <param name="max"></param>
      /// <param name="steps"></param>
      /// <param name="showValue"></param>
      /// <returns></returns>
      public AngularGauge AddSettingsToPointerChart(AngularGauge angularGauge, int min, int max, int steps, int showValue)
      {
         angularGauge = new AngularGauge()
         {
            Value = showValue,
            FromValue = min,
            ToValue = max,
            LabelsStep = steps,
         };
         return angularGauge;
      }

   }
}
