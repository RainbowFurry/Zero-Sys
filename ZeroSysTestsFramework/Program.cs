using System;
using System.Drawing;
using ZeroSys.Manager;

namespace ZeroSysTestsFramework
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            //test(new Program());
            //t();
            Console.Read();
        }

        private static void test(object obj)
        {
            //
        }

        private static void t()
        {

            //
            ProcessManager.StartNewConsoleCommand("ping google.de", true);
        }

        private static string Mirro(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //

        public static bool IsMatching(Color a, Color b, int percent)
        {
            //this method is used to identify whether two pixels, 
            //of color a and b match, as in they can be considered
            //a solid color based on the acceptance value (percent)

            int thresh = percent * 255;

            return Math.Abs(a.R - b.R) < thresh &&
                   Math.Abs(a.G - b.G) < thresh &&
                   Math.Abs(a.B - b.B) < thresh;
        }

    }

}
