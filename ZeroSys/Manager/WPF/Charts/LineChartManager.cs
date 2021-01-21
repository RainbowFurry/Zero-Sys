using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace ZeroSys.Manager.WPF.Charts
{
    /// <summary>
    /// LineChartManager
    /// </summary>
    public class LineChartManager
    {

        //color changeable

        /// <summary>
        /// Create new Line Chart Serie
        /// </summary>
        /// <param name="title"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public LineSeries CreateNewLineSerie(string title, double[] values)
        {

            LineSeries lineSeries = new LineSeries()
            {
                Title = title,
                Values = new ChartValues<double>(values)
            };
            return lineSeries;
        }

        /// <summary>
        /// Create new Line Chart Serie
        /// </summary>
        /// <param name="title"></param>
        /// <param name="values"></param>
        /// <param name="defaultGeometries">DefaultGeometries.[Circle]</param>
        /// <param name="size"></param>
        /// <returns></returns>
        public LineSeries CreateNewLineSerie(string title, double[] values, Geometry defaultGeometries, int size)
        {
            LineSeries lineSeries = new LineSeries()
            {
                Title = title,
                PointGeometry = defaultGeometries,
                PointGeometrySize = size,
                Values = new ChartValues<double>(values)
            };
            return lineSeries;
        }

        /// <summary>
        /// Add Line Series to Line Chart
        /// </summary>
        /// <param name="cartesianChart"></param>
        /// <param name="lineSeries"></param>
        public void AddLineSerieToLineChart(CartesianChart cartesianChart, LineSeries lineSeries)
        {
            cartesianChart.Series.Add(lineSeries);
        }

    }
}
