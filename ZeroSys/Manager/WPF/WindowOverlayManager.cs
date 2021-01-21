using System.Windows;
using System.Windows.Controls;

namespace ZeroSys.Manager.WPF
{
    /// <summary>
    /// WindowOverlayManager
    /// </summary>
    public class WindowOverlayManager
    {

        //Selber auswählen welche objects[]
        //filter welche ignoren
        //filter z.b. dark/light aber von user also ersetze die farbe durch die.
        //BEI FILTER MUSS FARBE PER CODE GESETZT WERDEN SONST ERROR FOR NO REASON!!!

        //shadow
        //border
        //color fore/back
        //cursor

        //
        public void UpdateWindow(Window window)
        {

        }

        //
        public void UpdateGrid(Grid grid)
        {

        }

        //
        public void UpdateLabel(Label label)
        {

        }

        //
        public void UpdateImage(Image image)
        {

        }

        //
        public void UpdateTextBox(TextBox textBox)
        {

        }

        public void UpdateCursor(object obj)
        {

        }

        public void UpdateCursor(Window window)
        {

        }

        //public static void updateWindowCursor(Window window)
        //{
        //    Console.WriteLine(Save_Path + @"Cursors\" + ConfigManager.userCursor);
        //    if (ConfigManager.userCursor != "-")
        //    {
        //        Cursor c = new Cursor(Save_Path + @"Cursors\" + ConfigManager.userCursor);
        //        if (c != null)
        //            window.Cursor = c;
        //    }
        //}

    }
}
