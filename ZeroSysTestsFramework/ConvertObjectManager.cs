using System;

namespace ZeroSysTestsFramework
{
   /// <summary>
   /// ConvertObjectManager
   /// </summary>
   public class ConvertObjectManager
   {

      //String Builder
      public static string BuildString(string text, string[] args)
      {
         return string.Format(text, args);
      }



      //Convert Object to Type
      public static object ConvertObj(Object obj, Type type)
      {
         return Convert.ChangeType(obj, type);
      }

      //Convert Object to Type of Object
      public static object ConvertObj(Object obj, Object objectType)
      {
         return Convert.ChangeType(obj, objectType.GetType());
      }

      //Convert String to Int
      public static int ConvertToInt(string content)
      {
         int result;
         int.TryParse(content, out result);
         return result;
      }

      //Convert String to Char 
      public static char ConvertToChar(string content)
      {
         char result;
         char.TryParse(content, out result);
         return result;
      }

      //Convert String do Double
      public static double ConvertToDouble(string content)
      {
         double result;
         double.TryParse(content, out result);
         return result;
      }

   }
}
