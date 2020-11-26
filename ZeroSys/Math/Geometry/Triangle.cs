namespace ZeroSys.Math.Geometry
{
   /// <summary>
   /// Triangle
   /// </summary>
   public class Triangle
   {

      #region gleich lange Seiten

      /// <summary>
      /// Calculate the Volume of the Triangle - (Volumen)
      /// </summary>
      /// <param name="area"></param>
      /// <param name="height"></param>
      /// <returns></returns>
      public static double Volume(double area, double height)
      {
         return (area * height);
      }

      /// <summary>
      /// Calculate the Scope of the Triangle - (Umfang)
      /// </summary>
      /// <param name="pageLength"></param>
      /// <returns></returns>
      public static double Scope(double pageLength)
      {
         return (pageLength + pageLength + pageLength);
      }

      /// <summary>
      /// Calculate the Area of the Triangle - (Flächeninhalt)
      /// </summary>
      /// <param name="pageLengthA"></param>
      /// <param name="height"></param>
      /// <returns></returns>
      public static double Area(double pageLengthA, double height)
      {
         return (pageLengthA * height) / 2;
      }

      #endregion

      #region nicht gleich lang

      ////
      //public static double Volume(double area, double height)
      //{
      //   return (area * height);
      //}

      ////
      //public static double Scope(double pageLengthA, double pageLengthB, double pageLengthC)
      //{
      //   return (pageLengthA + pageLengthB + pageLengthC);
      //}

      ////
      //public static double Area(double pageLengthA, double height)
      //{
      //   return (pageLengthA * height) / 2;
      //}

      #endregion

   }
}
