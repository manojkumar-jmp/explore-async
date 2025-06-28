using System;
using System.Threading;

namespace ProcessAndThread
{
    internal class InitializationRaces
    {
        private static MyResource myResource = null;
        public static void InitializationRacesDemo()
        {
            //CreateResource(); // Call the method to create a resource
            //CreateResource();

            Thread t1 = new Thread(CreateResource);
            t1.Name = "Thread-1";
            Thread t2 = new Thread(CreateResource);
            t2.Name = "Thread-2";
            t2.Start();
            t1.Start();
            t1.Join(); // Wait for t1 to finish
            t2.Join(); // Wait for t2 to finish
        }

        private static void CreateResource()
        {
            // This method can be used to create a resource.
            // It can be called from multiple threads to demonstrate
            if (myResource == null)
            {
                // If the resource is not initialized, create it
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} is initializing the resource.");
                Thread.Sleep(1000); // Simulate some delay in initialization
                myResource = new MyResource(); // Create an instance of MyResource
            }
        }
    }
}