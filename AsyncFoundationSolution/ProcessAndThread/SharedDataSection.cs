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
    internal class SharedDataSection
    {
        private static int sharedCounter = 0;

        public static void SharedDataDemo()
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    sharedCounter++;
                }
            } );
            t1.Start();
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
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
