using System;
using System.Threading;
using System.Windows;

namespace ZeroSys.Manager.WPF
{
    /// <summary>
    /// SplashScreenManager
    /// </summary>
    public class SplashScreenManager
    {

        /// <summary>
        /// Show Selfe Managed SpashScreen
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="showTimerInSeconds"></param>
        public static void ShowSplashScreen(string imagePath, int showTimerInSeconds)
        {
            SplashScreen splashScreen = new SplashScreen(imagePath);
            splashScreen.Show(false);//show Loading/Logo Image and stop own managing

            Thread.Sleep(showTimerInSeconds);//set Loading Image timeout
            splashScreen.Close(TimeSpan.FromSeconds(0));//fadeout the Logo Welcome/Loading Image
        }

        /// <summary>
        /// Show Selfe Managed SpashScreen
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="showTimerInSeconds"></param>
        /// <param name="fadeoutTimerInSeconds"></param>
        public static void ShowSplashScreen(string imagePath, int showTimerInSeconds, int fadeoutTimerInSeconds)
        {
            SplashScreen splashScreen = new SplashScreen(imagePath);
            splashScreen.Show(false);//show Loading/Logo Image and stop own managing

            Thread.Sleep(showTimerInSeconds);//set Loading Image timeout
            splashScreen.Close(TimeSpan.FromSeconds(fadeoutTimerInSeconds));//fadeout the Logo Welcome/Loading Image
        }

        //
        public static void StartShowingSplashScreen()
        {

        }

        //
        public static void StopShowingSpashScreen()
        {

        }

        //start aber mit neuem thread...

    }
}
