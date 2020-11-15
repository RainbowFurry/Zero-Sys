using System.Windows;

namespace ZeroSys.Manager
{
    /// <summary>
    /// AlertManager
    /// </summary>
    public class AlertManager
    {

        /// <summary>
        /// Create Alert Message Box
        /// </summary>
        /// <param name="content"></param>
        public static void CreateAlertMessageBox(string content)
        {
            MessageBox.Show(content);
        }

        /// <summary>
        /// Create Alert Message Box with Title
        /// </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        public static void CreateAlertMessageBox(string content, string title)
        {
            MessageBox.Show(content, title);
        }

        /// <summary>
        /// Create Alert Message Box with Title and optional Button/s
        /// </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="button"></param>
        public static void CreateOptionMessageBox(string content, string title, MessageBoxButton button)
        {
            MessageBox.Show(content, title, button);
        }

    }
}
