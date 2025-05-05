# Module 1: Fundamentals of Concurrency

## 1. Introduction to Concurrency and Parallelism
- ### Why use multithreading, async, and parallel programming?
- ### CPU-bound vs I/O-bound tasks
- ### Common pitfalls: deadlocks, race conditions, etc.
## 2. Asynchronous Programming Models in .NET
- ### APM – Asynchronous Programming Model
- ### EAP – Event-based Asynchronous Pattern
- ### TAP – Task-based Asynchronous Pattern
## [3. Threading Basics](#Threading-Basics)
- ### Thread class and manual thread creation
- ### Thread lifecycle, naming, joining, sleeping
- ### Thread safety and shared data access

<a name="Threading-Basics"></a>
### 2. Threading Basics
With the introduction of async/await and the Task Parallel Library (TPL), the need to manually create threads using the Thread class has become extremely rare in modern .NET applications. These higher-level abstractions provide more efficient, scalable, and safer ways to handle concurrency. In most scenarios, developers can rely on Task, Task.Run, async/await, or parallel constructs like Parallel.For to execute work concurrently, without ever needing to manually spin up threads.

That said, threads are still the foundation of all concurrency in .NET. While you may not create threads directly in everyday development, understanding how they work is crucial. Modern constructs like Task, async/await, and the ThreadPool all rely on threads under the hood. Without understanding threads, it becomes difficult to fully grasp how concurrency works in .NET — such as what a Task actually does, how the ThreadPool schedules work, and why issues like deadlocks or race conditions occur.

Moreover, having a solid understanding of threads significantly improves your ability to debug and troubleshoot real-world applications. When you're analyzing logs, you may encounter thread IDs or stack traces involving raw threads. Problems like deadlocks or race conditions often stem from shared state accessed across multiple threads. Knowing how threads behave helps you reason through and resolve these issues — even when working primarily with async/await.

Finally, many enterprise systems still contain legacy code that uses manual threading constructs such as Thread.Start(), Thread.Sleep(), and Thread.Join(). If you're ever tasked with maintaining or migrating such applications, you'll need to understand how these raw threads work and why they were used. While the manual thread approach is no longer best practice for most modern development, it's still a vital piece of the concurrency puzzle — and a topic every .NET developer should understand.

