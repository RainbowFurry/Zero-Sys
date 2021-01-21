using System;

namespace ZeroSys.Manager
{
   /// <summary>
   /// ExeptionManager
   /// </summary>
   public class ExeptionManager
   {
      /// <summary>
      /// Create new Custom Exeption
      /// </summary>
      /// <param name="exeption"></param>
      public static void CreateCustomExeption(string exeption)
      {
         throw new Exception(exeption);
      }

      /*
         {
              throw new Exception();
          }
          catch (Exception ex)
          {
              var stackTrace = new StackTrace(ex, true);
              var frame = stackTrace.GetFrame(0);

              Console.WriteLine("Exception message: {0}", ex.Message);
              Console.WriteLine("Exception in file: {0}", frame.GetFileName());
              Console.WriteLine("Exception in method: {0}", frame.GetMethod());
              Console.WriteLine("Exception at line numer: {0}", frame.GetFileLineNumber());

              Console.Read();
          }
       */

   }
}
