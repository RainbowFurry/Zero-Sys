﻿namespace ZeroSys.Math.Geometry
{
   /// <summary>
   /// Square
   /// </summary>
   public class Square
   {

      //DURCH x TEILEN ERGIBT WIE OFT PASST DAS IN KLEINER IN DAS ORIGINAL?!
      //WINKEL BERECHNEN?!

      /// <summary>
      /// Calculate the Volume of the Square - (Volumen)
      /// </summary>
      /// <param name="pageLength"></param>
      /// <returns></returns>
      public static double Volume(double pageLength)
      {
         return (pageLength * pageLength * pageLength);
      }

      /// <summary>
      /// Calculate the Scope of the Square - (Umfang)
      /// </summary>
      /// <param name="pageLength"></param>
      /// <returns></returns>
      public static double Scope(double pageLength)
      {
         return (4 * pageLength);
      }

      /// <summary>
      /// Calculate the Area of the Square - (Flächeninhalt)
      /// </summary>
      /// <param name="pageLength"></param>
      /// <returns></returns>
      public static double Area(double pageLength)
      {
         return (pageLength * pageLength);
      }

      //
      public static void PageLength()
      {
         //
      }

   }
}
