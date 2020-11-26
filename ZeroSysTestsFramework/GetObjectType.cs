using System;

namespace ZeroSysTestsFramework
{
   /// <summary>
   /// GetObjectType
   /// </summary>
   public class GetObjectType
   {

      public static Type GetType(object obj)
      {
         return obj.GetType();
      }

      //
      public static bool IsTypeOfString(object obj)
      {
         if (obj.GetType() == typeof(string))
            return true;
         else
            return false;
      }

      //
      public static bool IsTypeOfInteger(object obj)
      {
         if (obj.GetType() == typeof(int))
            return true;
         else
            return false;
      }

      //
      public static bool IsTypeOfDouble(object obj)
      {
         if (obj.GetType() == typeof(double))
            return true;
         else
            return false;
      }

      //
      public static bool IsTypeOfChar(object obj)
      {
         if (obj.GetType() == typeof(char))
            return true;
         else
            return false;
      }

      //
      public static bool IsTypeOfBool(object obj)
      {
         if (obj.GetType() == typeof(bool))
            return true;
         else
            return false;
      }

   }
}
