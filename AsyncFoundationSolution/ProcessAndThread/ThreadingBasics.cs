using System;
using System.Threading;

namespace ProcessAndThread
{
    internal class ThreadingBasics
    {
        public static void StartThreadWithNamedMethod()
        {
            // A new Thread is created with a method(PrintMessage) as the entry point. thread.Start() begins execution on a new thread.
            // Create a new thread and pass the method name as a parameter
            // Once the method is completed, the thread will automatically end. 
            // Sequence of execution of method can not predict.

            // you’ve only instantiated a Thread object.
            // At this point it exists in the “Unstarted” (dormant) state—no OS thread has been scheduled yet.
            Thread thread = new Thread(PrintMessage); 
            thread.Name = "MyThread";
            thread.Start();

            Thread threadWithDlegate = new Thread(new ThreadStart(PrintMessage));
            threadWithDlegate.Name = "MyThreadWithDelegate";

            // tells the CLR to hand your Thread object off to the OS scheduler.
            // The thread’s state transitions to “Running” as soon as the scheduler allocates CPU time to it.
            threadWithDlegate.Start();

            // What Start() Actually Does
            //   Enqueues your method(or lambda) onto a fresh OS thread.
            //   Returns immediately—your calling thread and the new worker thread now run concurrently.
            //   Throws a ThreadStateException if you call Start() more than once on the same instance.
        }
        public static void StartThreadWithLamdada()
        {
            //A thread is started using a lambda expression, which is useful for short or inline code.
            Thread thread = new Thread(() =>
            {
                Console.WriteLine("Hello from Lamda method.");
            });
            thread.Start();
        }
        public static void StartThreadWithParameter()
        {
            // ParameterizedThreadStart allows passing a single object parameter to the thread method. The method must accept an object parameter.
            Thread threadWithParameter = new Thread(PrintNumber);
            threadWithParameter.Start(45);
        }
        private static void PrintMessage()
        {
            Console.WriteLine($"Thread Nmae: {Thread.CurrentThread.Name} Message printed from a separate thread");
        }

        private static void PrintNumber(object number)
        {
            Console.WriteLine($"Number from parameter {number}");
        }

        public static void ForegroundThread()
        {
            // Foreground Threads (default)
            // By default, threadsyou create with new Thread(..) are foreground threads.
            // The process will not exit until all foreground threads have completed.
            
            Thread foregroundThread = new Thread(() =>
            {
                Console.WriteLine("Foreground thread is running.");
                // A call to the Thread.Sleep method puts the current execution context to sleep by invoking the sleep function of the OS kernel,
                // allowing the CPU to continue to do other work.

                Thread.Sleep(2000);
                Console.WriteLine("Foreground thread is finishing.");
            });
            foregroundThread.Start();
        }

        public static void BackgroundThread()
        {
            // Background Threads
            // You can create a background thread by setting the IsBackground property to true.
            // The process will exit as soon as the main thread and all foreground threads finish, even if background threads are still running.
            // Any unfinished background threads are terminated when the process exits.

            Thread backgroundThread = new Thread(() =>
            {
                Console.WriteLine("Background thread is running.");
                Thread.Sleep(2000);
                Console.WriteLine("Background thread is finishing.");
            });
            backgroundThread.IsBackground = true; // Set the thread as a background thread
            backgroundThread.Start();

        }
    }
}
