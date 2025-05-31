using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ProcessAndThread
{
    internal class SharedOSResources
    {
        public static void SharedOSResourcesDemo()
        {
            // The OS resources (files, network sockets, etc.)
            // Threads can share OS resources like files or network sockets.
            // Both threads write to the same file.
            string filePath = "sharedFile.txt";
            Thread t1 = new Thread(() => WriteToFile(filePath, "Thread 1 writing to file.\n"));
            t1.Name = "Thread1"; // Set thread name for identification
            t1.Start();
            Thread t2 = new Thread(() => WriteToFile(filePath, "Thread 2 writing to file.\n"));
            t2.Name = "Thread2"; // Set thread name for identification  
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine($"Data written to {filePath}. Check the file for contents.");
        }
        private static void WriteToFile(string path, string content)
        {
            lock (path) // Ensure that only one thread writes at a time
            {
                File.AppendAllText(path, content);
                Console.WriteLine($"{Thread.CurrentThread.Name} wrote to the file.");
            }
        }


    }
}
