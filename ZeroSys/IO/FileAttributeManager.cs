using System.IO;

namespace ZeroSys.IO
{
   /// <summary>
   /// FileAttributeManager
   /// </summary>
   public class FileAttributeManager
   {

      /// <summary>
      /// Add new Attribute to File
      /// </summary>
      /// <param name="filePath"></param>
      /// <param name="fileAttribute"></param>
      public static void AddFileAttribute(string filePath, FileAttributes fileAttribute)
      {
         File.SetAttributes(filePath, fileAttribute);
      }

      /// <summary>
      /// Add multiple Attributes to File
      /// </summary>
      /// <param name="filePath"></param>
      /// <param name="fileAttributes"></param>
      public static void AddFileAttributes(string filePath, FileAttributes[] fileAttributes)
      {
         foreach (FileAttributes fileAttribute in fileAttributes)
         {
            File.SetAttributes(filePath, fileAttribute);
         }
      }

      /// <summary>
      /// Remove Attribute from File
      /// </summary>
      /// <param name="filePath"></param>
      /// <param name="fileAttribute"></param>
      public static void RemoveFileAttribute(string filePath, FileAttributes fileAttribute)
      {
         FileAttributes attributes = File.GetAttributes(filePath);
         attributes = RemoveAttribute(attributes, fileAttribute);
         File.SetAttributes(filePath, attributes);
      }

      /// <summary>
      /// Remove multiple Attributes from File
      /// </summary>
      /// <param name="filePath"></param>
      /// <param name="fileAttributes"></param>
      public static void RemoveFileAttributes(string filePath, FileAttributes[] fileAttributes)
      {
         FileAttributes attributes = File.GetAttributes(filePath);
         foreach (FileAttributes attribute in fileAttributes)
         {
            attributes = RemoveAttribute(attributes, attribute);
            File.SetAttributes(filePath, attributes);
         }
      }

      /// <summary>
      /// Clear all Attributes from File
      /// </summary>
      /// <param name="filePath"></param>
      public static void ClearFileAttributes(string filePath)
      {
         RemoveAttribute(File.GetAttributes(filePath), FileAttributes.ReadOnly);
         RemoveAttribute(File.GetAttributes(filePath), FileAttributes.Hidden);
         RemoveAttribute(File.GetAttributes(filePath), FileAttributes.System);
         RemoveAttribute(File.GetAttributes(filePath), FileAttributes.Archive);
      }

      /// <summary>
      /// Check if the File has the Attribute
      /// </summary>
      /// <param name="filePath"></param>
      public static void HasFileAttribute(string filePath)
      {
         FileAttributes attributes = File.GetAttributes(filePath);
      }

      #region Direct Attributes

      /// <summary>
      /// Hide the File
      /// </summary>
      /// <param name="filePath"></param>
      public static void HideFile(string filePath)
      {
         File.SetAttributes(filePath, FileAttributes.Hidden);
      }

      /// <summary>
      /// Show the File
      /// </summary>
      /// <param name="filePath"></param>
      public static void ShowFile(string filePath)
      {
         //Wenn attribut hat
         if (true)
         {
            RemoveAttribute(File.GetAttributes(filePath), FileAttributes.Hidden);
         }
      }

      /// <summary>
      /// Lock the File from Editing
      /// </summary>
      /// <param name="filePath"></param>
      public static void LockFile(string filePath)
      {
         File.SetAttributes(filePath, FileAttributes.ReadOnly);
      }

      /// <summary>
      /// UnLock the File from Editing
      /// </summary>
      /// <param name="filePath"></param>
      public static void UnLockFile(string filePath)
      {
         //Wenn attribut hat
         if (true)
         {
            RemoveAttribute(File.GetAttributes(filePath), FileAttributes.ReadOnly);
         }
      }

      #endregion

      /// <summary>
      /// Remove Attributes from File
      /// </summary>
      /// <param name="attributes"></param>
      /// <param name="attributesToRemove"></param>
      /// <returns></returns>
      private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
      {
         return attributes & ~attributesToRemove;
      }

   }
}
