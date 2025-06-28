# Module 1: Foundation update

## 1. Introduction to Multithreading
- ### [What is a Thread?](#What-is-Thread)
- ### [What is Multithreading?](#What-is-Multithreading)
- ### [Why Do We Need Multithreading?](#Why-Do-We-Need-Multithreading)
- ### [Real-World Examples](#Real-World-Examples)

---

## 2. Introduction to Concurrency and Parallelism
- ### Why use multithreading, async, and parallel programming?
- ### CPU-bound vs I/O-bound tasks
- ### Common pitfalls: deadlocks, race conditions, etc.

---

## 3. Asynchronous Programming Models in .NET
- ### APM – Asynchronous Programming Model
- ### EAP – Event-based Asynchronous Pattern
- ### TAP – Task-based Asynchronous Pattern

---

## [4. Threading Basics](#Threading-Basics)
- ### [Thread class and manual thread creation](#Thread-Class)
- ### [Thread lifecycle, naming, joining, sleeping](#ThreadLifecycle)
- ### [Common Challenges in Multithreading](#CommonChallenges)

---

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

<a name="Thread-Class"></a>
### Thread Class

> Refer to ThreadingBasics.StartThreadWithNamedMethod(), ThreadingBasics.StartThreadWithLamdada() and ThreadingBasics.StartThreadWithParameter()

#### Why Notepad Has Fewer Threads Than Your Main Process
When you run the code that compares threads between your main program and Notepad, you'll typically see that Notepad has significantly fewer threads than your application. This is completely normal and expected for several reasons:

**Why Your Main Application Has More Threads**  \
Your main application (especially in a .NET environment) creates many background threads because:
1.	Runtime Infrastructure:
    - The .NET runtime creates multiple thread pool threads
    - Garbage collection threads
    - Finalizer threads
    - Just-In-Time (JIT) compilation threads
2. Framework Services:
   - Asynchronous I/O completion threads
   - Timer management threads
   - UI message loop (for WPF/Windows Forms apps)
   - Background task threads
3.	Application-Specific:
    - Any Task.Run() or new Thread() operations in your code
    - Async/await continuations
    - Framework components that create their own threads

**Why Notepad Has Fewer Threads**  \
Notepad is a much simpler application because:
    - Native Application: Notepad is written in native code (C/C++), not managed code like .NET, so it doesn't need runtime infrastructure threads.
    - Simple Architecture: Notepad has a minimal feature set with basic functionality.
    - Single-Purpose Design: It focuses only on text editing without background services.
    - Minimal Resource Usage: It's designed to be lightweight and efficient.

A typical breakdown of threads in Notepad:
 - Main UI thread
 - File I/O thread
 - Possibly 1-2 system service threads

#### In .NET (and most operating systems), threads within the same process share
 - The code section (the program’s instructions)
   - All threads execute code from the same program. For example, multiple threads can call the same method:
   > Refer to SharedCodeSection.SharedCodeDemo()
 - The data section (static fields, heap objects)
   - Threads can access and modify shared data, such as static fields or objects on the heap:
   > Refer to SharedDataSection.SharedDataDemo()
 - Operating system resources (open files, handles, etc.)
   - Threads can use the same file handles or other OS resources
   > Refer to SharedOSResources.SharedOSResourcesDemo()
 - However, each thread has its own stack, so local variables are private to each thread.
   - Each thread has its own private stack, which means that local variables declared inside a method are unique to each thread. They are not shared between threads, so changes made to a local variable in one thread do not affect the same-named variable in another thread.
   > Refer to PrivateStacks.ThreadLocalStacks() 

| Resource Type         | Shared Between Threads? | Example                       | 
|-----------------------|------------------------|--------------------------------| 
| Code Section          | Yes                    | Same method executed           | 
| Data Section (static) | Yes                    | Static fields, heap objects    | 
| OS Resources          | Yes                    | File handles, sockets, etc.    | 
| Stack (locals)        | No (private per thread)| Local variables in methods     |

<a name="ThreadLifecycle"></a>
### Thread lifecycle, naming, joining, sleeping

> Refer to ThreadLifecycle.ThreadLifecycleDemo()

The thread lifecycle in .NET describes the various states a thread goes through from creation to termination. Here’s a summary of the main states and transitions, with C# context:

| State            | Description                                                          | 
|------------------|----------------------------------------------------------------------| 
| Unstarted        | Created, not started                                                 | 
| Running          | Actively executing code                                              | 
| WaitSleepJoin    | Thread is blocked (Waiting, sleeping, or joining another thread)     | 
| Stopped          | Finished execution                                                   |

**Suspended (Obsolete, not recommended)**
 - In C#, a thread can be suspended or resumed using the deprecated methods Suspend and Resume. These methods are deprecated and their use is discouraged in .NET Framework and .NET Core. This is because if you suspend a thread that’s already inside a critical section where it’s holding a lock on a critical resource, the entire application might deadlock. A better way to handle this is by using WaitHandle.
 - WaitHandlers help threads communicate with one another using signaling where a particular thread waits until it receives a notification from another thread. In C#, you can have two types that represent EventWaitHandlers, **AutoResetEvent** and **ManualResetEvent**. The basic difference between an AutoResetEvent and a ManualResetEvent is that an AutoResetEvent only allows one waiting thread to continue, and a ManualResetEvent allows multiple threads to continue until you stop it. 

**Terminating a Thread**
- The Thread.Abort() method can be used to abort a running thread.  However, this isn’t a recommended approach and has been deprecated in .NET Core because it adopts an unsafe approach to terminating threads. A recommended approach to thread termination is by using CancellationToken, 

<a name="CommonChallenges"></a>
### Common Challenges in Multithreading
While multithreading is powerful, it’s also notoriously tricky.
Some common pitfalls include:
- **Race conditions** – two threads accessing the same data at the same time
- **Deadlocks** – two threads waiting on each other forever
- **Thread safety** – protecting shared resources from concurrent access
- **Complex debugging** – bugs may not appear consistently

These are exactly the kinds of problems modern .NET features like Task and async/await are designed to help with — but to understand how, we first need to understand why.
#### Race conditions
A race condition occurs when two or more threads access shared data concurrently, and at least one thread modifies the data. The outcome depends on the exact timing and sequence of operations, leading to unpredictable results.
#### Common Race Condition Patterns
- Check-Then-Act: A thread checks a condition and then acts on it, but the check and the action are not performed atomically. Another thread can change the condition between the check and the act, leading to unexpected behavior.
  > Refer to CheckThenAct.CheckThenActDemo()
- Read-Modify-Write: A thread reads a value, modifies it, and writes it back. If multiple threads do this simultaneously, updates can be lost because the operations are not atomic.
  > Refer to SharedDataSection.SharedDataDemo()
- Initialization Races: Multiple threads try to initialize a shared resource at the same time, possibly resulting in multiple initializations or inconsistent state.
  > Refer to InitializationRaces.InitializationRacesDemo()

#### Ways to Prevent Race Conditions:
The key to avoiding race conditions is to identify shared resources and ensure their access is properly synchronized using appropriate thread-safety mechanisms.

##### A. Synchronization primitives:
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

##### B. Atomic operations:
- Interlocked class methods

##### C. Thread-safe collections:
- ConcurrentDictionary
- ConcurrentQueue
- ConcurrentBag

##### D. Immutable objects

##### E. Thread-local storage

#### Best Practices:
- Minimize shared state
- Make shared data immutable when possible
- Use thread-safe collections
- Keep critical sections as small as possible
- Avoid nested locks to prevent deadlocks
- Use higher-level synchronization when possible (Tasks, async/await)

**Thread Safety**  \
Thread safety means that shared data is accessed and modified by multiple threads in a way that prevents data corruption or unexpected behavior. When multiple threads access the same variable or object without proper synchronization, you can get race conditions or inconsistent results.
