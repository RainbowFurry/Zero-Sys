using System;
using System.Diagnostics;

namespace ZeroSys.Manager
{
    /// <summary>
    /// TimerManager
    /// </summary>
    public class TimerManager
    {

        private Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        /// Start Timer
        /// </summary>
        public void StartTimer()
        {
            stopWatch.Start();
        }

        /// <summary>
        /// Stop Timer
        /// </summary>
        /// <returns>Time needed to stop</returns>
        public string StopTimer()
        {
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            return elapsedTime;
        }

    }
}
