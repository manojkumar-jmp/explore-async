using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessAndThread
{
    // The data section (static fields, heap objects)
    // Threads can access and modify shared data, such as static fields or objects on the heap.
    // Both threads increment the same sharedCounter variable. (This is not thread-safe!)

    // for small number of iterations it may work fine, but for larger numbers of iterations,
    // the final value of sharedCounter may not be what you expect.
    
    // The reason for small number of iterations it may work fine is likely due to the following factors:
    // Modern CPU cache coherency protocols
    // The simplicity and speed of the increment operation
    // The relatively small number of iterations
    internal class SharedDataSection
    {
        private static int sharedCounter = 0;

        public static void SharedDataDemo()
        {
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
            Console.WriteLine($"Final value of sharedCounter: {sharedCounter}");
        }
    }
}
