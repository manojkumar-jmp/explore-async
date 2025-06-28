using System;
using System.Threading;

namespace ProcessAndThread
{
    public class MyResource
    {
        private static int _resourceCount = 0;
        // This class can be used to represent a resource that might be shared across threads.
        // It can contain properties and methods to manage the resource.
        public MyResource()
        {
            _resourceCount++;
            Console.WriteLine($"Resource created by thread {Thread.CurrentThread.Name}. Current resource count: {_resourceCount}");
        }
    }
}
