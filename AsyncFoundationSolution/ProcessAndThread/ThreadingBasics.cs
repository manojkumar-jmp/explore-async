using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessAndThread
{
    internal class ThreadingBasics
    { 
        public static void StartThreadWithNamedMethod()
        {
            //A new Thread is created with a method(PrintMessage) as the entry point. thread.Start() begins execution on a new thread.
            //Create a new thread and pass the method name as a parameter
            //Once the method is completed, the thread will automatically end. 
            //Sequence of execution of method can not predict.

            Thread thread = new Thread(PrintMessage);
            thread.Name = "MyThread";
            thread.Start();

            Thread threadWithDlegate = new Thread(new ThreadStart(PrintMessage));
            threadWithDlegate.Name = "MyThreadWithDelegate";
            threadWithDlegate.Start();
        }
        public static void StartThreadWithLamdada()
        {
            //A thread is started using a lambda expression, which is useful for short or inline code.
            Thread thread = new Thread(() =>
            {
                Console.WriteLine("Hello from Lamda method.");
            });
            thread.Start();
        }
        public static void StartThreadWithParameter()
        {
            Thread threadWithParameter = new Thread(PrintNumber);
            threadWithParameter.Start(45);
        }
        private static void PrintMessage()
        {
            Console.WriteLine($"Thread Nmae: {Thread.CurrentThread.Name} Message printed from a separate thread");
        }

        private static void PrintNumber(object number)
        {
            Console.WriteLine($"Number from parameter {number}");
        }


    }
}
