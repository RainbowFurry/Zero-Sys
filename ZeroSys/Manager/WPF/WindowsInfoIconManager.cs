using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZeroSys.Manager.WPF
{
    /// <summary>
    /// WindowsInfoIconManager
    /// </summary>
    public class WindowsInfoIconManager
    {

        private NotifyIcon notifyIcon = PushNotificationManager.notifyIcon1;
        private ContextMenu contextMenu;
        private System.ComponentModel.IContainer components = PushNotificationManager.components;

        /// <summary>
        /// Initialize Programm Icon in Windows Task Bar
        /// </summary>
        public void CreateWindowsInfoIcon(MenuItem[] menuItems, string iconPath, string applicationName)
        {

            // Initialize contextMenu
            foreach (MenuItem menuItem in menuItems)
            {
                contextMenu.MenuItems.AddRange(new MenuItem[] { menuItem });
            }

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon.Icon = SystemIcons.Application;

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Icon = new Icon(iconPath);

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon.Text = applicationName;
            notifyIcon.Visible = true;

            // Create the NotifyIcon.
            notifyIcon = new NotifyIcon(components);

        }

        /// <summary>
        /// Create Menu Item
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        /// <param name="eventHandler"></param>
        /// <returns></returns>
        public MenuItem CreateMenuItem(string content, int index, EventHandler<EventArgs> eventHandler)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Index = index;
            menuItem.Text = content;//E&xit
            menuItem.Click += new EventHandler(eventHandler);

            return menuItem;
        }

        /// <summary>
        /// Clean up any Component from being used
        /// </summary>
        protected void Dispose(bool disposing)
        {
            if (disposing)
                if (components != null)
                    components.Dispose();

            Dispose(disposing);
        }

    }
}
