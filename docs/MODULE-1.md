# Module 1: Foundation 

## 1. Introduction to Multithreading
- ### [What is a Thread?](#What-is-Thread)
- ### [What is Multithreading?](#What-is-Multithreading)
- ### [Why Do We Need Multithreading?](#Why-Do-We-Need-Multithreading)
- ### [Common Challenges in Multithreading](#Common-Challenges-in-Multithreading)
- ### [Real-World Examples](#Real-World-Examples)

## 2. Introduction to Concurrency and Parallelism
- ### Why use multithreading, async, and parallel programming?
- ### CPU-bound vs I/O-bound tasks
- ### Common pitfalls: deadlocks, race conditions, etc.
## 3. Asynchronous Programming Models in .NET
- ### APM – Asynchronous Programming Model
- ### EAP – Event-based Asynchronous Pattern
- ### TAP – Task-based Asynchronous Pattern
## [4. Threading Basics](#Threading-Basics)
- ### Thread class and manual thread creation
- ### Thread lifecycle, naming, joining, sleeping
- ### Thread safety and shared data access

## 1. Introduction to Multithreading
<a name ="What-is-Thread"></a>
### What is a Thread?
Let’s begin with the basics: a thread is the smallest unit of execution within a process.
When you launch an application, the operating system gives it a process with at least one thread — known as the main thread.
Every line of code you write runs on some thread.
Threads allow us to perform multiple operations at once — for example, updating the user interface while downloading a file in the background.

<a name="What-is-Multithreading"></a>
### What is Multithreading?
Multithreading means running two or more threads concurrently within the same application.
It’s a way to achieve concurrency and parallelism — doing multiple things at once.

For example, one thread might be waiting for data from the network while another continues processing data or responding to user input.

<a name="Why-Do-We-Need-Multithreading"></a>
Why Do We Need Multithreading?
So why use multithreading in the first place?
Here are three main reasons:
- **Responsiveness** – Especially in desktop and mobile apps, long-running operations on the main thread can freeze the UI. Running those tasks on background threads keeps your app responsive.
- **Performance** – On multi-core CPUs, threads can execute in parallel, making better use of hardware.
- **Scalability** – Servers can handle more simultaneous requests by running them across multiple threads efficiently.

<a name="Common-Challenges-in-Multithreading"></a>
### Common Challenges in Multithreading
While multithreading is powerful, it’s also notoriously tricky.
Some common pitfalls include:
- **Race conditions** – two threads accessing the same data at the same time
- **Deadlocks** – two threads waiting on each other forever
- **Thread safety** – protecting shared resources from concurrent access
- **Complex debugging** – bugs may not appear consistently

These are exactly the kinds of problems modern .NET features like Task and async/await are designed to help with — but to understand how, we first need to understand why.

<a name="Real-World-Examples"></a>
### Real-World Examples
Let’s look at a few common places where multithreading is used:
- In a web server, to handle hundreds of incoming HTTP requests at the same time
- In a game engine, to load assets or process AI while rendering frames
- In a desktop or mobile app, to fetch data from the internet without freezing the UI

<a name="Threading-Basics"></a>
## 4. Threading Basics
With the introduction of async/await and the Task Parallel Library (TPL), the need to manually create threads using the Thread class has become extremely rare in modern .NET applications. These higher-level abstractions provide more efficient, scalable, and safer ways to handle concurrency. In most scenarios, developers can rely on Task, Task.Run, async/await, or parallel constructs like Parallel.For to execute work concurrently, without ever needing to manually spin up threads.

That said, threads are still the foundation of all concurrency in .NET. While you may not create threads directly in everyday development, understanding how they work is crucial. Modern constructs like Task, async/await, and the ThreadPool all rely on threads under the hood. Without understanding threads, it becomes difficult to fully grasp how concurrency works in .NET — such as what a Task actually does, how the ThreadPool schedules work, and why issues like deadlocks or race conditions occur.

Moreover, having a solid understanding of threads significantly improves your ability to debug and troubleshoot real-world applications. When you're analyzing logs, you may encounter thread IDs or stack traces involving raw threads. Problems like deadlocks or race conditions often stem from shared state accessed across multiple threads. Knowing how threads behave helps you reason through and resolve these issues — even when working primarily with async/await.

Finally, many enterprise systems still contain legacy code that uses manual threading constructs such as Thread.Start(), Thread.Sleep(), and Thread.Join(). If you're ever tasked with maintaining or migrating such applications, you'll need to understand how these raw threads work and why they were used. While the manual thread approach is no longer best practice for most modern development, it's still a vital piece of the concurrency puzzle — and a topic every .NET developer should understand.

## Thread lifecycle, naming, joining, sleeping

The thread lifecycle in .NET describes the various states a thread goes through from creation to termination. Here’s a summary of the main states and transitions, with C# context:

| State            | Description                                      | 
|------------------|--------------------------------------------------| 
| Unstarted        | Created, not started                             | 
| Running          | Actively executing code                          | 
| WaitSleepJoin    | Waiting, sleeping, or joining another thread     | 
| Stopped          | Finished execution                               |

Suspended (Obsolete, not recommended)
•	The thread is suspended. (Not used in modern .NET; avoid using Thread.Suspend.)

## In .NET (and most operating systems), threads within the same process share
 - The code section (the program’s instructions)
   - All threads execute code from the same program. For example, multiple threads can call the same method:
 - The data section (static fields, heap objects)
   - Threads can access and modify shared data, such as static fields or objects on the heap:
 - Operating system resources (open files, handles, etc.)
   - Threads can use the same file handles or other OS resources
 - However, each thread has its own stack, so local variables are private to each thread.
   - Each thread has its own private stack, which means that local variables declared inside a method are unique to each thread. They are not shared between threads, so changes made to a local variable in one thread do not affect the same-named variable in another thread.
 

| Resource Type         | Shared Between Threads? | Example                       | 
|-----------------------|------------------------|--------------------------------| 
| Code Section          | Yes                    | Same method executed           | 
| Data Section (static) | Yes                    | Static fields, heap objects    | 
| OS Resources          | Yes                    | File handles, sockets, etc.    | 
| Stack (locals)        | No (private per thread)| Local variables in methods     |

### Thread Safety

Thread safety means that shared data is accessed and modified by multiple threads in a way that prevents data corruption or unexpected behavior. When multiple threads access the same variable or object without proper synchronization, you can get race conditions or inconsistent results.

If two threads update a shared variable at the same time, the final value may be unpredictable. This is called a race condition.

#### Synchronization Mechanisms

1. Lock (uses Monitor under the hood)
   - The lock statement ensures that only one thread can enter the critical section at a time.
3. Monitor
   - Provides more control than lock, such as Monitor.Enter, Monitor.Exit, and Monitor.TryEnter.
   - Allows explicit wait and pulse operations for advanced scenarios.
3. Mutex
   - Can synchronize threads across different processes
   - Useful for inter-process synchronization
4. Semaphore / SemaphoreSlim
   - Limits the number of threads that can access a resource or pool of resources concurrently.
   - SemaphoreSlim is a lightweight, in-process alternative.
5. ReaderWriterLock / ReaderWriterLockSlim
   - Allows multiple threads to read shared data simultaneously, but only one thread to write.
   - ReaderWriterLockSlim is recommended for most scenarios.
6. AutoResetEvent / ManuakResetEvent
   - Used for signaling between threads.
   - One thread can signal another to proceed.
7. CountdownEvent
   - Allows threads to wait until a set of operations being performed in other threads completes.
9. Barrier
    - Enables multiple threads to work concurrently on an algorithm in phases.
9. SpinLock / SpinWait
   - Useful for very short, low-contention critical sections where threads can "spin" instead of sleeping.
