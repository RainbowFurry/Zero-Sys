using LiveCharts.Wpf;
using System.Windows.Media;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// GaugeChartManager
   /// </summary>
   public class GaugeChartManager
   {

      /// <summary>
      /// Create new Gauge Chart
      /// </summary>
      /// <param name="gauge">Gauge</param>
      /// <param name="from">From</param>
      /// <param name="to">To</param>
      /// <param name="value">Value</param>
      /// <param name="brush">Brush</param>
      /// <param name="use360Degrese">true = circle | false = half circle</param>
      public void CreateNewGaugeChart(Gauge gauge, int from, int to, int value, Brush brush, bool use360Degrese)
      {

         var converter = new BrushConverter();
         var b = (Brush)converter.ConvertFromString("#333");

         if (brush == null)
            brush = b;

         gauge.Uses360Mode = use360Degrese;
         gauge.From = from;
         gauge.To = to;
         gauge.Value = value;
         gauge.GaugeActiveFill = brush;

      }

      /// <summary>
      /// Create new Gauge Chart
      /// </summary>
      /// <param name="gauge">Gauge</param>
      /// <param name="from">From</param>
      /// <param name="to">To</param>
      /// <param name="value">Value</param>
      /// <param name="brush">Brush</param>
      /// <param name="use360Degrese">true = circle | false = half circle</param>
      public void CreateNewGaugeChart(Gauge gauge, int from, int to, int value, LinearGradientBrush brush, bool use360Degrese)
      {
         gauge.Uses360Mode = use360Degrese;
         gauge.From = from;
         gauge.To = to;
         gauge.Value = value;
         gauge.GaugeActiveFill = brush;
      }

      /// <summary>
      /// Create new Gauge Chart
      /// </summary>
      /// <param name="gauge"></param>
      /// <param name="from"></param>
      /// <param name="to"></param>
      /// <param name="value"></param>
      /// <param name="innerRadius"></param>
      /// <param name="brush"></param>
      /// <param name="use360Degrese"></param>
      public void CreateNewGaugeChart(Gauge gauge, int from, int to, int value, double innerRadius, Brush brush, bool use360Degrese)
      {

         var converter = new BrushConverter();
         var b = (Brush)converter.ConvertFromString("#333");

         if (brush == null)
            brush = b;

         if (innerRadius <= 0)
            innerRadius = 0.1;

         gauge.Uses360Mode = use360Degrese;
         gauge.From = from;
         gauge.To = to;
         gauge.Value = value;
         gauge.GaugeActiveFill = brush;
         gauge.InnerRadius = innerRadius;

      }

      /// <summary>
      /// Create new Gauge Chart
      /// </summary>
      /// <param name="gauge"></param>
      /// <param name="from"></param>
      /// <param name="to"></param>
      /// <param name="value"></param>
      /// <param name="innerRadius"></param>
      /// <param name="brush"></param>
      /// <param name="use360Degrese"></param>
      public void CreateNewGaugeChart(Gauge gauge, int from, int to, int value, double innerRadius, LinearGradientBrush brush, bool use360Degrese)
      {

         var converter = new BrushConverter();
         var b = (LinearGradientBrush)converter.ConvertFromString("#333");

         if (brush == null)
            brush = b;

         if (innerRadius <= 0)
            innerRadius = 0.1;

         gauge.Uses360Mode = use360Degrese;
         gauge.From = from;
         gauge.To = to;
         gauge.Value = value;
         gauge.GaugeActiveFill = brush;
         gauge.InnerRadius = innerRadius;

      }

      /// <summary>
      /// Create Linear Gradient Brush
      /// </summary>
      /// <param name="color"></param>
      /// <returns></returns>
      public LinearGradientBrush CreateLinearGradientBrush(Color[] color)
      {

         GradientStopCollection gradientStops = new GradientStopCollection();
         LinearGradientBrush linearGradientBrush = new LinearGradientBrush();

         foreach (Color c in color)
         {
            GradientStop gs = new GradientStop();
            gs.Color = c;
            gradientStops.Add(gs);
         }

         linearGradientBrush.GradientStops = gradientStops;

         return linearGradientBrush;
      }

   }

}
