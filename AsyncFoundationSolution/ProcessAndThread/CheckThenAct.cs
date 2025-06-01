using System;
using System.Text;
using System.Threading;

namespace ProcessAndThread
{
    internal class CheckThenAct
    {
        public static void CheckThenActDemo()
        {
            // Check-then-act is a common pattern in multithreading where a thread checks a condition and then acts based on that condition.
            // CreateAFileIfNotExists(); // Work as expected in a single-threaded environment
            
            Thread t1 = new Thread(CreateAFileIfNotExists);
            t1.Name = "Thread-1";
            Thread t2 = new Thread(CreateAFileIfNotExists);
            t2.Name = "Thread-2";
            t1.Start();
            t2.Start();
            t1.Join(); // Wait for t1 to finish
            t2.Join();

        }

        private static void CreateAFileIfNotExists()
        {
            // Define the file path 
            string filePath = "data.txt";
            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                // If not, create the file

                try
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        // Optionally write something to the file
                        byte[] info = new UTF8Encoding(true).GetBytes("File created at " + DateTime.Now + " by " + Thread.CurrentThread.Name);
                        stream.Write(info, 0, info.Length);
                        Thread.Sleep(1000); // Simulate some work
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Exception occured: {ex.Message}"); 
                }

            }
            else
            {
                Console.WriteLine($"File already exists: {filePath}");
            }
        }
    }
}
