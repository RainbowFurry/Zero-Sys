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

            Possibillity p1 = new Possibillity()
            {
                Name = "Red Ball",
                Ammount = 7
            };

            Possibillity p2 = new Possibillity()
            {
                Name = "Blue Ball",
                Ammount = 4
            };

            Possibillity p3 = new Possibillity()
            {
                Name = "Yellow Ball",
                Ammount = 2
            };

            Possibillity[] possibillities = new Possibillity[] { p1, p2, p3 };

            ttt(possibillities);
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

        public static void ttt(Possibillity[] possibillities)
        {

            int maxPossible = 0;

            foreach (Possibillity pc in possibillities)
            {
                maxPossible = maxPossible + pc.Ammount;
            }

            foreach (Possibillity p in possibillities)
            {
                double result = p.Ammount / (double)maxPossible * 100;
                Console.WriteLine(p.Name + ": " + result.ToString("00.00") + " %");
            }

        }

    }


    public class Possibillity
    {
        public string Name { get; set; }
        public int Ammount { get; set; }
    }

}
