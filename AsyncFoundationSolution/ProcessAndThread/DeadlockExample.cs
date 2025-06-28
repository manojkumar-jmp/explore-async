using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessAndThread
{
    internal class DeadlockExample
    {
        private static readonly object lock1 = new object();
        private static readonly object lock2 = new object();
        public static void DeadlockExampleDemo()
        {
            // In this example, Method1 locks lock1 and then tries to lock lock2, while Method2 locks lock2 and then tries to lock lock1.
            Thread thread1 = new Thread(() => Method1());
            Thread thread2 = new Thread(() => Method2());
            thread1.Start();
            thread2.Start();
            thread1.Join(); // Wait for thread1 to finish
            thread2.Join(); // Wait for thread2 to finish
        }

        public static void AvoidingCiscularDependenciesDemo()
        {
            // In this example, Method1 and Method2 are designed to avoid deadlocks by locking resources in a consistent order.
            Thread thread1 = new Thread(() => AvoidingCiscularDependenciesMethod1());
            Thread thread2 = new Thread(() => AvoidingCiscularDependenciesMethod2());
            thread1.Start();
            thread2.Start();
            thread1.Join(); // Wait for thread1 to finish
            thread2.Join(); // Wait for thread2 to finish
        }

        public static void MonitorAvoidDeadlockDemo()
        {
            Thread thread1 = new Thread(MonitorAvoidDeadlockMethod1);
            Thread thread2 = new Thread(MonitorAvoidDeadlockMethod2);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }
        private static void Method1()
        {
            lock (lock1)
            {
                Console.WriteLine("Method1 is holding lock on resource lock1");
                System.Threading.Thread.Sleep(100); // Simulate some work
                Console.WriteLine("Method1 is waiting for res. lock2");
                lock (lock2)
                {
                    Console.WriteLine("Method1 holding lock on resource lock2");
                }
            }
        }
        private static void Method2()
        {
            lock (lock2)
            {
                Console.WriteLine("Method2 holding lock on resource lock2");
                System.Threading.Thread.Sleep(100); // Simulate some work
                Console.WriteLine("Method2 is waiting for res. lock1");
                lock (lock1)
                {
                    Console.WriteLine("Method2 holding lock on resource lock1");
                }
            }
        }

        private static void AvoidingCiscularDependenciesMethod1()
        {
            // To avoid deadlocks, you can use a consistent locking order or timeout mechanisms.
            lock (lock1)
            {
                Console.WriteLine("Method1 is holding lock on resource lock1");
                System.Threading.Thread.Sleep(100); // Simulate some work
                lock (lock2)
                {
                    Console.WriteLine("Method1 holding lock on resource lock2");
                }
            }
        }
        private static void AvoidingCiscularDependenciesMethod2()
        {
            // To avoid deadlocks, you can use a consistent locking order or timeout mechanisms.
            lock (lock1)
            {
                Console.WriteLine("Method2 holding lock on resource lock1");
                System.Threading.Thread.Sleep(100); // Simulate some work
                lock (lock2)
                {
                    Console.WriteLine("Method2 holding lock on resource lock2");
                }
            }
        }

        private static void MonitorAvoidDeadlockMethod1()
        {
            bool lock1Acquired = false;
            bool lock2Acquired = false;
            try
            {
                Monitor.Enter(lock1, ref lock1Acquired);
                Console.WriteLine("MonitorMethod1 acquired lock1");
                Thread.Sleep(100); // Simulate work

                // Try to acquire lock2 with timeout
                if (Monitor.TryEnter(lock2, 500))
                {
                    lock2Acquired = true;
                    Console.WriteLine("MonitorMethod1 acquired lock2");
                }
                else
                {
                    Console.WriteLine("MonitorMethod1 could not acquire lock2, avoiding deadlock");
                }
            }
            finally
            {
                if (lock2Acquired) Monitor.Exit(lock2);
                if (lock1Acquired) Monitor.Exit(lock1);
            }
        }

        private static void MonitorAvoidDeadlockMethod2()
        {
            bool lock1Acquired = false;
            bool lock2Acquired = false;
            try
            {
                Monitor.Enter(lock2, ref lock2Acquired);
                Console.WriteLine("MonitorMethod2 acquired lock2");
                Thread.Sleep(100); // Simulate work

                // Try to acquire lock1 with timeout
                if (Monitor.TryEnter(lock1, 500))
                {
                    lock1Acquired = true;
                    Console.WriteLine("MonitorMethod2 acquired lock1");
                }
                else
                {
                    Console.WriteLine("MonitorMethod2 could not acquire lock1, avoiding deadlock");
                }
            }
            finally
            {
                if (lock1Acquired) Monitor.Exit(lock1);
                if (lock2Acquired) Monitor.Exit(lock2);
            }
        }

    }
}
