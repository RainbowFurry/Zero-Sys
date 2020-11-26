using System;

namespace ZeroSysTestsFramework
{
   public class Tests
   {

      //Enumerable Flag Check... single/multiple match/es
      public static void tes()
      {
         UUser u = new UUser()
         {
            Name = "Jason",
            type = SingleHue.Blue | SingleHue.Red,
         };
         //SingleHue.
         if (u.type.HasFlag(SingleHue.Blue | SingleHue.Red))
         {
            Console.WriteLine("JA");
         }
         else
         {
            Console.WriteLine("NEIN");
         }
      }

   }

   //FLAGS = Wie miz Z. Permissions. - Ich kann jeden der enum tags miteinander kombinieren...
   //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
   //[Flags]
   public enum SingleHue
   {
      None,
      Black,
      Red,
      Green,
      Blue
   };

   public class UUser
   {
      public string Name { get; set; }
      public SingleHue type { get; set; }
   }


}
