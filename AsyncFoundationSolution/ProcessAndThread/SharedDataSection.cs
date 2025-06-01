using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessAndThread
{
    internal class SharedDataSection
    {
        private static int sharedCounter = 0;

        // The data section (static fields, heap objects)
        // Threads can access and modify shared data, such as static fields or objects on the heap.
        // Both threads increment the same sharedCounter variable. (This is not thread-safe!)

        // for small number of iterations it may work fine, but for larger numbers of iterations,
        // the final value of sharedCounter may not be what you expect.

        // The reason for small number of iterations it may work fine is likely due to the following factors:
        // Modern CPU cache coherency protocols
        // The simplicity and speed of the increment operation
        // The relatively small number of iterations
        public static void SharedDataDemo()
        {
            // Example of  Read-Modify-Write
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Thread.Sleep(0);
                    sharedCounter++;
                }
            } );
            t1.Start();
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Thread.Sleep(0);
                    sharedCounter++;
                }
            });
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine($"Expected: 200000, Actual: {sharedCounter}");
        }

        public static void SharedDataDemoWithLock()
        {
            // Creates a private lockObject that acts as a synchronization token
            object lockObject = new object();
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Thread.Sleep(0);
                    lock (lockObject) // Acquire lock before modifying shared data
                    {
                        sharedCounter++; // Safe increment operation
                    }   // Release lock
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Thread.Sleep(0);
                    lock (lockObject) // Acquire lock before modifying shared data
                    {
                        sharedCounter++;
                    }
                }
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine($"Using LockObject:- Expected: 200000, Actual: {sharedCounter}");
        }

        public static void SharedDataDemoWithInterlocked() 
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Thread.Sleep(0);
                    Interlocked.Increment(ref sharedCounter); // Safe increment operation
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Thread.Sleep(0);
                    Interlocked.Increment(ref sharedCounter); // Safe increment operation
                }
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine($"Using Interlocked:- Expected: 200000, Actual: {sharedCounter}");
        }
    }
}
