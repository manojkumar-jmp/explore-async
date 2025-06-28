using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessAndThread
{
    internal class ExceptionHandling
    {
        private static MyResource myResource = null;
        public static void ExceptionHandlingDemo()
        {
            Thread t1 = new Thread(CreateResourceWithExceptionHandling) { Name = "Thread-1" };
            Thread t2 = new Thread(CreateResourceWithExceptionHandling) { Name = "Thread-2" };
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }

        public static void DemonstrateThreadExceptionNotPropagating()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Console.WriteLine($"Main thread: Caught unhandled exception: {((Exception)args.ExceptionObject).Message}");
                Console.WriteLine($"Is Terminating: {args.IsTerminating}");
            };
            try
            {
                Console.WriteLine("Main thread: Starting a thread that will throw an exception...");
                Thread safe = new Thread(() =>
                {
                    try
                    {
                        throw new InvalidOperationException("Exception caught in child thread!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Safely caught in thread: {ex.Message}");
                    }
                });
                safe.Start();

            }
            catch (Exception ex)
            {
                // This will NOT be executed!
                Console.WriteLine($"Main thread: Caught exception: {ex.Message}");
            }

            Console.WriteLine("Main thread: If you see this message and no exception was caught above, the exception in the thread did NOT propagate to the main thread.");
        }

        public static void DemonstrateThreadExceptionUnhandledException()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Console.WriteLine($"Main thread: Caught unhandled exception: {((Exception)args.ExceptionObject).Message}");
                Console.WriteLine($"Is Terminating: {args.IsTerminating}");
            };
            try
            {
                Console.WriteLine("Main thread: Starting a thread that will throw an exception...");
                Thread safe = new Thread(() =>
                {
                    throw new InvalidOperationException("Exception caught in child thread!");
                });
                safe.Start();

            }
            catch (Exception ex)
            {
                // This will NOT be executed!
                Console.WriteLine($"Main thread: Caught exception: {ex.Message}");
            }

            Console.WriteLine("Main thread: If you see this message and no exception was caught above, the exception in the thread did NOT propagate to the main thread.");
        }

        public static void CaughtNonThreadedMethodException()
        {
            try
            {
                Console.WriteLine("Calling non-threaded method that throws an exception...");
                NonThreadedMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception in caller method: {ex.Message}");
            }
        }

       
        private static void CreateResourceWithExceptionHandling()
        {
            try
            {
                // Simulate a possible exception during resource creation
                if (Thread.CurrentThread.Name == "Thread-2")
                    throw new InvalidOperationException("Simulated exception in Thread-2");

                if (myResource == null)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.Name} is initializing the resource.");
                    Thread.Sleep(1000); // Simulate some delay in initialization
                    myResource = new MyResource();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in {Thread.CurrentThread.Name}: {ex.Message}");
            }
        }
        private static void NonThreadedMethod()
        {
            throw new InvalidOperationException("Exception from non-threaded method");
        }
    }
}
