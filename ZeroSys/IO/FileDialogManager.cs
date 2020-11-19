using System.Windows.Forms;

namespace ZeroSys.IO
{
   /// <summary>
   /// FileDialogManager
   /// </summary>
   public class FileDialogManager
   {

      //select multiple files
      //openFile?/return path file

      /// <summary>
      /// Initialize FileDialogManager
      /// </summary>
      public FileDialogManager()
      {
         //
      }

      /// <summary>
      /// Create FileDialog Window
      /// </summary>
      /// <param name="searchPath"></param>
      /// <param name="fileEndingFilter"></param>
      public void CreateFileDialog(string searchPath, string fileEndingFilter)
      {

         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.InitialDirectory = searchPath;
            openFileDialog.Filter = fileEndingFilter;//"txt files(*.txt)|*.txt|All files(*.*)|*.*"
            openFileDialog.FilterIndex = 2;//selected Index
                                           //openFileDialog.Multiselect = true;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               //Get the path of specified file
               string filePath = openFileDialog.FileName;
            }

         }

      }

      /// <summary>
      /// Create FileDialog which showes all Files
      /// </summary>
      /// <param name="searchPath"></param>
      public void CreatFileDialogAll(string searchPath)
      {
         string fileEndingFilter = "All files (*.*)|*.*";
         CreateFileDialog(searchPath, fileEndingFilter);
      }

      /// <summary>
      /// Create FileDialog which showes (Json, Resx, Xml) Files 
      /// </summary>
      /// <param name="searchPath"></param>
      public void CreateFileDialogStorage(string searchPath)
      {
         string fileEndingFilter = "JSON files (.json)|.json|Resource files (.resx)|.resx|XML files (.xml)|.xml|All files (*.*)|*.*";
         CreateFileDialog(searchPath, fileEndingFilter);
      }

      /// <summary>
      /// Create FileDialog which showes (Doc, DocX, PDF, Text) Files
      /// </summary>
      /// <param name="searchPath"></param>
      public void CreateFileDialogText(string searchPath)
      {
         string fileEndingFilter = "Doc files (*.doc)|*.doc|DocX files (*.docx)|*.docx|PDF files (*.pdf)|*.pdf|Text files (*.txt)|*.txt|All files (*.*)|*.*";
         CreateFileDialog(searchPath, fileEndingFilter);
      }

      /// <summary>
      /// Create FileDialog which showes (PNG, JPG, Gif, SVG, Bitmap, Icon) Files
      /// </summary>
      /// <param name="searchPath"></param>
      public void CreateFileDialogImages(string searchPath)
      {
         string fileEndingFilter = "PNG files (*.png)|*.png|JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|ICON files (*.ico)|*ico|SVG files (*.svg)|*.svg|Bitmap files (*.bmp)|*.bmp|All files (*.*)|*.*";
         CreateFileDialog(searchPath, fileEndingFilter);
      }

      /// <summary>
      /// Create FileDialog which showes (MP4) Files
      /// </summary>
      /// <param name="searchPath"></param>
      public void CreateFileDialogVideos(string searchPath)
      {
         string fileEndingFilter = "MP4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
         CreateFileDialog(searchPath, fileEndingFilter);
      }

      /// <summary>
      /// Create FileDialog which showes (MP3) Files
      /// </summary>
      /// <param name="searchPath"></param>
      public void CreateFileDialogAudio(string searchPath)
      {
         string fileEndingFilter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
         CreateFileDialog(searchPath, fileEndingFilter);
      }

      /// <summary>
      /// Create FileDialog which showes (Zip, 7Zip, Rar, WinRar) Files
      /// </summary>
      /// <param name="searchPath"></param>
      public void CreateFileDialogZip(string searchPath)
      {
         string fileEndingFilter = "Zip files (*.zip)|*.zip|7Zip files (*.7zip)|*.7zip|Rar files (*.rar)|*.rar|WinRar files (*.winrar)|*.winrar|All files (*.*)|*.*";
         CreateFileDialog(searchPath, fileEndingFilter);
      }

      /// <summary>
      /// Create Multiple File Filter
      /// </summary>
      /// <param name="fileName"></param>
      /// <param name="fileEnding"></param>
      /// <returns></returns>
      public string CreateFileDialogFilter(string[] fileName, string[] fileEnding)
      {

         if (fileName.Length == fileEnding.Length)
         {
            string fileEndingFilter = string.Empty;
            for (int i = 0; i < fileName.Length - 1; i++)
            {
               if (fileName.Length - 1 < i)
                  fileEndingFilter = string.Format($"{0} files (*.{1})|*.{2}", fileName[i], fileEnding[i], fileEnding[i]);
               else
                  fileEndingFilter = string.Format($"{0} files (*.{1})|*.{2}|", fileName[i], fileEnding[i], fileEnding[i]);
            }
            return fileEndingFilter;
         }
         return string.Empty;
      }

      /// <summary>
      /// Create single File Filter
      /// </summary>
      /// <param name="fileName"></param>
      /// <param name="fileEnding"></param>
      /// <returns></returns>
      public string CreateFileDialogFilter(string fileName, string fileEnding)
      {

         if (fileName.Length == fileEnding.Length)
         {
            string fileEndingFilter = string.Format($"{0} files (*.{1})|*.{2}", fileName, fileEnding, fileEnding); ;
            return fileEndingFilter;
         }
         return string.Empty;
      }

   }
}
