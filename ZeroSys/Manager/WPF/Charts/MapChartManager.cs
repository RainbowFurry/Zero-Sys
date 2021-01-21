using LiveCharts.Wpf;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace ZeroSys.Manager.WPF.Charts
{
   /// <summary>
   /// MapChartManager
   /// </summary>
   public class MapChartManager
   {

      //LanguagePack = new Dictionary<string, string>();
      //LanguagePack["DE"] = "Deutsch"; // change the language if necessary


      private Dictionary<string, double> Values { get; set; }

      /// <summary>
      /// Initialize MapChartManager
      /// </summary>
      public MapChartManager()
      {
         Values = new Dictionary<string, double>();
      }

      /// <summary>
      /// Add new Map Marker
      /// </summary>
      /// <param name="countryShortcut"></param>
      /// <param name="value"></param>
      public void AddNewMapSeries(string countryShortcut, int value)
      {
         Values[countryShortcut] = value;
      }

      /// <summary>
      /// Add Map Marker to GeoMap
      /// </summary>
      /// <param name="geoMap"></param>
      public void AddMapSeriesToMapChart(GeoMap geoMap)
      {
         geoMap.HeatMap = Values;
         geoMap.Source = Directory.GetCurrentDirectory() + @"\src\Maps\World.xml";
      }

      /// <summary>
      /// Add Map Marker to GeoMap and set Path for Map
      /// </summary>
      /// <param name="geoMap"></param>
      /// <param name="mapPath"></param>
      public void AddMapSeriesToMapChart(GeoMap geoMap, string mapPath)
      {
         geoMap.HeatMap = Values;
         geoMap.Source = Directory.GetCurrentDirectory() + mapPath;
      }

      /// <summary>
      /// Change Color of GeoMap
      /// </summary>
      /// <param name="geoMap"></param>
      /// <param name="hexLandFill"></param>
      /// <param name="hexBackground"></param>
      public void ChangeMapChartColor(GeoMap geoMap, string hexLandFill, string hexBackground)
      {
         var converter = new BrushConverter();
         var brushWater = (Brush)converter.ConvertFromString(hexBackground);//108de6
         var brushLand = (Brush)converter.ConvertFromString(hexLandFill);//32a852

         geoMap.DefaultLandFill = brushLand;//land
         geoMap.Background = brushWater;//water
      }

   }
}
