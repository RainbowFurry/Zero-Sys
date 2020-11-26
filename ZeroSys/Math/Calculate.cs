using System;
using System.Data;

namespace ZeroSys.Math
{
   /// <summary>
   /// Calculate
   /// </summary>
   public class Calculate
   {

      public static double MathCalculate(string content)
      {
         return Convert.ToDouble(new DataTable().Compute(content, null));
      }

   }
}
