using System;
using System.Threading;

namespace ProcessAndThread
{
    internal class PrivateStacks
    {
        public static void ThreadLocalStacks() 
        {
            // Each thread has its own private stack, which means that local variables declared inside a method are unique to each thread.
            // They are not shared between threads, so changes made to a local variable in one thread do not affect the same-named variable in another thread.

            // Local variables are always thread-safe because each thread gets its own stack.
            // Only shared data (like static or instance fields) require synchronization for thread safety.
            Thread threadOne = new Thread(()=>
            {
                int localValue = 0;
                for (int i = 0; i < 10; i++)
                {
                    localValue++;
                    Console.WriteLine($"ThreadOne: localValue {localValue}");
                }
            });

            Thread threadTwo = new Thread(()=>
            {
                int localValue = 0;
                for(int i = 0; i < 10 ; i++)
                {  
                    localValue++;
                    Console.WriteLine($"ThreadTwo: localValue {localValue}");
                }
            });
            threadOne.Start();
            threadTwo.Start();
            threadOne.Join();
            threadTwo.Join();
        }
    }
}
