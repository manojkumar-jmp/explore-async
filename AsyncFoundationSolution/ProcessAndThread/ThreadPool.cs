using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessAndThread
{
    internal class ThreadPool
    {
        public static void ThreadPoolDemo()
        {
            // Creation and disposal of threads are resource intensive operations,
            // you can use a thread from the managed thread pool to queue tasks without having to manage the threads individually.
            
            // ThreadPool is a pool of worker threads that can be used to execute tasks asynchronously.
            // It manages a pool of threads, allowing you to queue work items without creating and destroying threads manually.
            // The ThreadPool automatically adjusts the number of threads based on the workload.
            // Queue a work item to the ThreadPool
            System.Threading.ThreadPool.QueueUserWorkItem(state =>
            {
                Console.WriteLine($"Thread Pool Worker Thread ID: {Thread.CurrentThread.ManagedThreadId} is executing a task.");
                Thread.Sleep(2000); // Simulate work
                Console.WriteLine($"Thread Pool Worker Thread ID: {Thread.CurrentThread.ManagedThreadId} has completed the task.");
            });
            Console.WriteLine("Main thread continues to run while worker thread is processing.");
        }
    }
}
