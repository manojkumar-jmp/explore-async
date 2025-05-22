using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProcessAndThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get current process id
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine($"Main process ID:{currentProcess.Id}");
            // Start new process to Notepad
            Process notepadProcess = Process.Start("notepad.exe");
            ListThreadOfSpecificProcess(currentProcess.Id);
            Console.WriteLine($"Notepad process ID:{notepadProcess.Id}");
            ListThreadOfSpecificProcess(notepadProcess.Id);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void ListThreadOfSpecificProcess(int processId)
        {            
            try
            {
                Process process = Process.GetProcessById(processId);
                Console.WriteLine($"Current Process: {process.ProcessName} ID: {process.Id} has {process.Threads.Count} threads");
                Console.WriteLine("Thread in current process");
                foreach (ProcessThread thread in process.Threads)
                {
                    Console.WriteLine($"Thread ID: {thread.Id} Name {Thread.CurrentThread.Name} State: {thread.ThreadState} Priority {thread.PriorityLevel} CPU Time {thread.TotalProcessorTime}");
    
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
