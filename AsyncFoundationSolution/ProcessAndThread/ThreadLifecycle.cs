using System;
using System.Threading;

namespace ProcessAndThread
{
    internal class ThreadLifecycle
    {
        public static void ThreadLifecycleDemo()
        {
            Thread thread = new Thread(()=>
            {
                Console.WriteLine("Thread running ...");
                Thread.Sleep(2000);  // WaitSleepJoin
                Console.WriteLine("Thread finishing ...");
            });
            Console.WriteLine($"State before start: {thread.ThreadState}"); // Unstarted
            thread.Start();
            Thread.Sleep(1000); // Give thread time to start
            Console.WriteLine($"State after start: {thread.ThreadState}"); // Running or WaitSleepJoin
            thread.Join(); // Main thread waits here until 'thread' finishes. Join(); 
                           // Join() is used for synchronization, not for keeping the process alive. It ensures the main thread waits for the worker thread to finish before continuing.
                           // When you call t.Join();, the main thread pauses and waits for thread t to complete.               
                           // Once t finishes its work and exits, the main thread resumes execution.               
                           // If you forget to call Join(), the main thread may finish and exit before your worker thread completes, especially in console applications.

            Console.WriteLine($"State after join: {thread.ThreadState}"); // Stopped
        }
    }
}
