using System;
using System.Diagnostics;
using System.Threading;

namespace ProcessAndThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // By default, the main thread’s Name property is null unless you explicitly set it.
            // The Name property can only be set once per thread.
            Thread.CurrentThread.Name = "MainThread";
            // Name can only be set once per thread
            // This would throw an exception:
            // Thread.CurrentThread.Name = "MainThread-1";

            // LaunchAndCheckProcess();
            // CheckThreads();
            // ThreadingBasics.StartThreadWithNamedMethod();
            // ThreadingBasics.StartThreadWithLamdada();
            // ThreadingBasics.StartThreadWithParameter();
            // ThreadPool.ThreadPoolDemo();
            // DeadlockExample.DeadlockExampleDemo();
            // DeadlockExample.AvoidingCiscularDependenciesDemo();
            // DeadlockExample.MonitorAvoidDeadlockDemo();
            // ThreadLifecycle.ThreadLifecycleDemo();
            // PrivateStacks.ThreadLocalStacks();
            // SharedCodeSection.SharedCodeDemo();
            // SharedDataSection.SharedDataDemo();
            // SharedDataSection.SharedDataDemoWithLock();
            // SharedDataSection.SharedDataDemoWithInterlocked();
            // SharedOSResources.SharedOSResourcesDemo();
            // CheckThenAct.CheckThenActDemo();
            // InitializationRaces.InitializationRacesDemo();
            // InitializationRaces.InitializationRacesDemo();
            // ExceptionHandling.ExceptionHandlingDemo();
            // ExceptionHandling.CaughtNonThreadedMethodException();
            // ExceptionHandling.DemonstrateThreadExceptionNotPropagating();
             ExceptionHandling.DemonstrateThreadExceptionUnhandledException();

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
                    // thread.Id is the unique identifier for the thread within the process.
                    // thread.ThreadState indicates the current state of the thread (e.g., Running, Waiting, etc.)
                    // thread.PriorityLevel indicates the priority of the thread (e.g., Normal, High, etc.)
                    // thread.TotalProcessorTime indicates the total amount of time the thread has spent using the processor.
                    // thread.UserProcessorTime indicates the amount of time the thread has spent executing user code.
                    
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
