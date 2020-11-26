using mathCalculator = System.Math;

namespace ZeroSys.Math.Geometry
{
   /// <summary>
   /// Circle
   /// </summary>
   public class Circle
   {

      /// <summary>
      /// Calculate the Volume of the Circle - (Volumen)
      /// </summary>
      /// <param name="radius"></param>
      /// <param name="height"></param>
      /// <returns></returns>
      public static double Volume(double radius, double height)
      {
         return mathCalculator.PI * (radius * radius) * height;
      }

      /// <summary>
      /// Calculate the Scope of the Circle - (Umfang)
      /// </summary>
      /// <param name="radius"></param>
      /// <returns></returns>
      public static double Scope(double radius)
      {
         return 2 * mathCalculator.PI * radius;
      }

      /// <summary>
      /// Calculate the Area of the Circle - (Flächeninhalt)
      /// </summary>
      /// <param name="radius"></param>
      /// <returns></returns>
      public static double Area(double radius)
      {
         return mathCalculator.PI * (radius * radius);
      }

      //Radius
      public static double Radius()
      {
         //
         return 0;
      }

      //Durchmesser
      public static double Diameter()
      {
         //
         return 0;
      }

   }
}
