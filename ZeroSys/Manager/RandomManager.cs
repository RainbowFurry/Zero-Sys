using System;

namespace ZeroSys.Manager
{
    /// <summary>
    /// RandomManager
    /// </summary>
    public class RandomManager
    {

        /// <summary>
        /// Integer Array
        /// </summary>
        public static int[] intArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        /// <summary>
        /// Upper Char Array
        /// </summary>
        public static char[] charArrayUpper = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        /// <summary>
        /// Lower Char Array
        /// </summary>
        public static char[] charArrayLower = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        /// <summary>
        /// Symbole Array
        /// </summary>
        public static char[] symbols = new char[] { '!', '?' };

        private static Random random = new Random();



        /// <summary>
        /// Get random Upper Char
        /// </summary>
        /// <returns></returns>
        public static char GetRandomUpperChar()
        {
            return charArrayUpper[random.Next(0, charArrayUpper.Length - 1)];
        }

        /// <summary>
        /// Get random Lower Char
        /// </summary>
        /// <returns></returns>
        public static char GetRandomLowerChar()
        {
            return charArrayLower[random.Next(0, charArrayLower.Length - 1)];
        }

        /// <summary>
        /// Get random String
        /// </summary>
        /// <param name="length"></param>
        public static string GetRandomString(int length)
        {

            string result = "";

            for (int i = 0; i < length; i++)
            {

                if (random.Next(0, 1) == 0)
                {
                    result += charArrayUpper[random.Next(0, charArrayUpper.Length - 1)];
                }
                else
                {
                    result += charArrayLower[random.Next(0, charArrayLower.Length - 1)];
                }

            }

            return result;
        }

        /// <summary>
        /// Get random Integer
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomInt(int min, int max)
        {
            return random.Next(min, max);
        }

        //
        private static double GetRandomDouble(double min, double max)
        {
            return 0.0;
        }

    }
}
