using System;
using System.Collections;
using System.Resources;

/**********************************************
* Porject Name : ZeroSys                      *
* Company Name : ZeroWorks                    *
*      Webside : ZeroWorks.de                 *
*  Description : Translate DB Values          *
*       Author : Jason Hoffmann               *
*   Copy Right : All Rights reserved to       *
*                ZeroWorks (Jason Hoffmann)   *
**********************************************/

namespace ZeroSys.Database
{
   /// <summary>
   /// Translate DB Values
   /// </summary>
   public class TranslateDB
   {

      private static String[] languages = { "English", "French", "Italian", "Russia", "Spanish", "China" }; //German is default

      private static String[] hashDB_Key = new String[2000];
      private static String[] hashDB_Value = new String[2000];
      private static int position = 0;

      /// <summary>
      /// Translate the DB in all Languages
      /// </summary>
      /// <param name="languagePath"></param>
      public static void Translate(String languagePath)
      {
         for (int i = 0; i < languages.Length; i++)
         {
            position = i;

            LoadContenetForDB(languagePath);
            WriteContentToDB(languagePath);
         }
      }

      /// <summary>
      /// Load Existing DB Values
      /// </summary>
      /// <param name="languagePath"></param>
      private static void LoadContenetForDB(String languagePath)
      {
         ResXResourceReader resxReader = new ResXResourceReader(languagePath);

         int step = -1;

         foreach (DictionaryEntry entry in resxReader)
         {
            Console.WriteLine("Key: " + entry.Key);
            Console.WriteLine("Value: " + entry.Value);

            if (entry.Value != null && entry.Key != null)
            {

               step++;
               hashDB_Key[step] = entry.Key.ToString();
               hashDB_Value[step] = entry.Value.ToString();

            }

         }


      }

      /// <summary>
      /// Create new DB with translated Content
      /// </summary>
      /// <param name="languagePath"></param>
      private static void WriteContentToDB(String languagePath)
      {

         ResXResourceWriter resx = new ResXResourceWriter(languagePath.Replace(".resx", "_").Replace("_German", "") + languages[position] + @".resx");

         for (int i = 0; i < hashDB_Value.Length; i++)
         {
            if (hashDB_Key[i] != null && hashDB_Value[i] != null)
               resx.AddResource(hashDB_Key[i], hashDB_Value[i]);//TranslateText.translateText(hashDB_Value[i]).Result);
         }
         resx.Generate();

      }

   }
}
