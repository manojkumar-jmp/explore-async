using System;
using System.Threading;

namespace ProcessAndThread
{
    internal class SharedCodeSection
    {
        public static void SharedCodeDemo() 
        {
            Thread t1 = new Thread(SharedCode);
            t1.Name = "Thread1";
            t1.Start();
            Thread t2 = new Thread(SharedCode); 
            t2.Name = "Thread2";
            t2.Start();
            t1.Join();
            t2.Join();
        }

        private static void SharedCode()
        {
            // The code section (the program’s instructions)
            // All threads execute code from the same program. For example, multiple threads can call the same method.
            // Both threads execute the same method (PrintSharedMessage).
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} is executing SharedCode.");
        }
    }
}
