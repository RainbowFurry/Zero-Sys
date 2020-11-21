using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shell;

namespace ZeroSys.Manager.WPF.Taskbar
{
    /// <summary>
    /// ThumbnailManager
    /// </summary>
    public class ThumbnailManager
    {
        //ThumbnailButtonClickedEventArgs,object sender
        private static TaskbarItemInfo taskbarItemInfo;

        /// <summary>
        /// Initialize and Create Thumbnail Entrie Options
        /// </summary>
        public static void CreateThumbnailToolbar(Window window, ThumbnailToolBarButton[] thumbnailToolBarButtons)
        {

            taskbarItemInfo = new TaskbarItemInfo();
            WindowInteropHelper interopHelper = new WindowInteropHelper(window);

            TaskbarManager.Instance.ThumbnailToolBars.AddButtons(interopHelper.Handle, thumbnailToolBarButtons);

        }

        /// <summary>
        /// Create TaskBar Thumbnail
        /// </summary>
        public static void CreateTaskbarThumbnail(Window window, string iconPath)
        {
            Icon icon = new Icon(iconPath);
            taskbarItemInfo.Overlay = ToImageSource(icon);
            window.TaskbarItemInfo = taskbarItemInfo;
        }

        /// <summary>
        /// Create ThumbnailIcon
        /// </summary>
        /// <param name="iconPath"></param>
        /// <param name="content"></param>
        /// <param name="thumbnailButtonClickedEventArgs"></param>
        /// <returns></returns>
        public static ThumbnailToolBarButton CreateThumbnialIcon(string iconPath, string content, EventHandler<ThumbnailButtonClickedEventArgs> thumbnailButtonClickedEventArgs)
        {
            ThumbnailToolBarButton thumbnailToolBarButton = new ThumbnailToolBarButton(new Icon(iconPath), content);
            thumbnailToolBarButton.Click += thumbnailButtonClickedEventArgs;
            return thumbnailToolBarButton;
        }

        /// <summary>
        /// Convert Icon to ImageSource
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static ImageSource ToImageSource(Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
        }

    }
}
