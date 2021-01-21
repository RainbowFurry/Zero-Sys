using System;
using System.IO;
using System.Security.Principal;

namespace ZeroSys.IO
{
   /// <summary>
   /// FileInfoManager
   /// </summary>
   public class FileInfoManager
   {

      //Get the File Information
      public static FileInfo GetFileInformation(string filePath)
      {
         FileInfo fileInfo = new FileInfo(filePath);
         Console.WriteLine("FullName: " + fileInfo.FullName);
         Console.WriteLine("Name: " + fileInfo.Name);
         Console.WriteLine("FileOwner: " + File.GetAccessControl(filePath).GetOwner(typeof(NTAccount)).ToString());
         Console.WriteLine("CreationTime: " + fileInfo.CreationTime);
         Console.WriteLine("LastAccesTime: " + fileInfo.LastAccessTime);
         Console.WriteLine("LastWriteTime: " + fileInfo.LastWriteTime);
         Console.WriteLine("DirectoryName: " + fileInfo.DirectoryName);
         Console.WriteLine("Extention: " + fileInfo.Extension);
         Console.WriteLine("Attributes: " + fileInfo.Attributes);
         Console.WriteLine("FileSize: " + fileInfo.Length + " bytes");

         return fileInfo;
      }

      //
      private void ChangeFileOwner(string filePath, string ownerName)
      {
         //File.GetAccessControl(filePath).SetOwner(new IdentityReference(""));
      }

   }
}
