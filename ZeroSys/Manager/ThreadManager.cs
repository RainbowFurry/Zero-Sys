using System;
using System.Threading.Tasks;

namespace ZeroSys.Manager
{
   /// <summary>
   /// ThreadManager
   /// </summary>
   public class ThreadManager
   {

      //wait for task untill complete
      //start multiple tasks gleichzeitig..

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
