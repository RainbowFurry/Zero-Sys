using System;
using System.Threading.Tasks;

namespace ZeroSys.Manager
{
    /// <summary>
    /// ThreadManager
    /// </summary>
    public class ThreadManager
    {

        //Start new task in thread - main projekt arbeitet weiter und Thread arbeitet
        //Start new task in thread - main projekt arbeitet, wartet auf Thread

        private static Task task;

        /// <summary>
        /// Create new Task
        /// </summary>
        /// <param name="action"></param>
        /// <param name="waitForTask"></param>
        public void StartTaskInNewThread(Action action, bool waitForTask)
        {
            task = new Task(action);

            if (waitForTask)
                task.Wait();
            else
                task.Start();

        }

        public void test()
        {
            //Thread thread1 = new Thread();
            //thread1.Start();
        }

    }
}
