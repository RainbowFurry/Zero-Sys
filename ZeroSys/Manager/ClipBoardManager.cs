using System.Collections.Generic;
using System.Windows;

namespace ZeroSys.Manager
{
    /// <summary>
    /// ClipBoardManager
    /// </summary>
    public class ClipBoardManager
    {

        #region Windows

        /// <summary>
        /// Add Text to Clip Board
        /// </summary>
        /// <param name="content"></param>
        public static void AddToClipBoard(string content)
        {
            Clipboard.SetText(content);
        }

        /// <summary>
        /// Cet Latest Text from Clip Board
        /// </summary>
        /// <returns></returns>
        public static string GetTextFromClipBoard()
        {
            return Clipboard.GetText();
        }

        /// <summary>
        /// Cleat the Clip Board
        /// </summary>
        public static void ClearClipBoard()
        {
            Clipboard.Clear();
        }

        #endregion

        #region Zero

        //add Text
        //add image
        //add image by Image / string path

        private static List<string> zeroClipboard = new List<string>();

        /// <summary>
        /// Add Text to Zero Clip Board
        /// </summary>
        /// <param name="text"></param>
        public static void AddToZeroClipBoard(string text)
        {
            zeroClipboard.Add(text);
        }

        /// <summary>
        /// Add Text to Zero Clip Board from Clip Board
        /// </summary>
        public static void AddToZeroClipBoardFromClipBoard()
        {
            zeroClipboard.Add(Clipboard.GetText());
        }

        /// <summary>
        /// Check if Text exists in Zero Clip Board
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ExistInZeroClipBoard(string text)
        {
            if (zeroClipboard.Contains(text))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Remove Text from Zero Clip Board
        /// </summary>
        /// <param name="text"></param>
        public static void RemoveFromZeroClipboard(string text)
        {
            zeroClipboard.Remove(text);
        }

        /// <summary>
        /// Clear the Zero Clip Board
        /// </summary>
        public static void ClearZeroClipBoard()
        {
            zeroClipboard.Clear();
        }

        #endregion

    }
}
