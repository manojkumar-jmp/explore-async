using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

namespace ProcessAndThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //By default, the main thread’s Name property is null unless you explicitly set it.
            //•	The Name property can only be set once per thread.
            Thread.CurrentThread.Name = "MainThread";
            //Thread.CurrentThread.Name = "MainThread-1";
            // 1 LaunchAndCheckProcess();
            // 2 CheckThreads();
            // 3 ThreadingBasics.StartThreadWithNamedMethod();
            // 4 ThreadingBasics.StartThreadWithLamdada();
            // 5 ThreadingBasics.StartThreadWithParameter();
            // 6 ThreadLifecycle.ThreadLifecycleDemo();

            Console.WriteLine($"Thread Name: {Thread.CurrentThread.Name} Press any key to exit");
            Console.ReadKey();
        }

        static void LaunchAndCheckProcess()
        {
            // Get current process id
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine($"Main process ID:{currentProcess.Id}");
            // Start new process to Notepad
            Process notepadProcess = Process.Start("notepad.exe");            
            Console.WriteLine($"Notepad process ID:{notepadProcess.Id}");           
        }

        static void CheckThreads()
        {
            // Get current process id
            Process currentProcess = Process.GetCurrentProcess();
            ListThreadOfSpecificProcess(currentProcess.Id);

            // Start new process to Notepad
            Process notepadProcess = Process.Start("notepad.exe");
            ListThreadOfSpecificProcess(notepadProcess.Id);
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
                    Console.WriteLine($"Thread ID: {thread.Id} State: {thread.ThreadState} Priority {thread.PriorityLevel} CPU Time {thread.TotalProcessorTime}");
    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
