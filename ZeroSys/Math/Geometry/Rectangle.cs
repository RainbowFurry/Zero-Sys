namespace ZeroSys.Math.Geometry
{
   /// <summary>
   /// Rectangle
   /// </summary>
   public class Rectangle
   {

      /// <summary>
      /// Calculate the Volume of the Rectangle - (Volumen)
      /// </summary>
      /// <param name="pageLength"></param>
      /// <param name="pageWidth"></param>
      /// <param name="pageHeightHeight"></param>
      /// <returns></returns>
      public static double Volume(double pageLength, double pageWidth, double pageHeightHeight)
      {
         return (pageLength * pageWidth * pageHeightHeight);
      }

      /// <summary>
      /// Calculate the Scope of the Rectangle - (Umfang)
      /// </summary>
      /// <param name="pageLength"></param>
      /// <param name="pageWidth"></param>
      /// <returns></returns>
      public static double Scope(double pageLength, double pageWidth)
      {
         return ((2 * pageLength) + (2 * pageWidth));
      }

      /// <summary>
      /// Calculate the Area of the Rectangle - (Flächeninhalt)
      /// </summary>
      /// <param name="pageLength"></param>
      /// <param name="pageWidth"></param>
      /// <param name="pageHeight"></param>
      /// <returns></returns>
      public static double Area(double pageLength, double pageWidth, double pageHeight)
      {
         return (2 * (pageLength * pageHeight) + (pageHeight * pageWidth) + (pageLength * pageWidth));
      }

   }
}
