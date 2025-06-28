# Module 3: Asynchronous Programming (Async/Await)
## 1. Async/Await Basics
- ### async and await keywords
- ### How async/await transforms code
- ### Task, Task<T>, ValueTask
- ### Synchronous vs asynchronous methods
## 2. ConfigureAwait and Context
- ### Understanding ConfigureAwait(false)
- ### Synchronization contexts
- ### Avoiding deadlocks
## 3. Error Handling in Async Code
- ### Try/catch patterns with async methods
- ### Task exception handling
- ### AggregateExceptions and how to properly handle them
## 4. Cancellation Support
- ### Using CancellationToken and CancellationTokenSource
- ### Implementing cancellable operations
- ### Cooperative cancellation patterns
## 5. Task Composition
- ### Task.WhenAll for parallel execution
- ### Task.WhenAny for racing tasks
- ### Chaining tasks with ContinueWith
## 6. Custom Task Schedulers
- ### Creating custom schedulers
- ### Controlling thread affinity
- ### UI thread scheduling considerations
## 7. Asynchronous Streams (for .NET Core/.NET 8)
- ### Working with IAsyncEnumerable<T>
- ### await foreach loops
- ### Converting between synchronous and asynchronous streams
## 8. Best Practices and Patterns
- ### Naming conventions (method suffixes with Async)
- ### Avoiding common pitfalls
  - #### Blocking Async Code
  - #### Missing ConfigureAwait(false)
  - #### async void Methods
  - #### Ignoring Returned Tasks
  - #### Improper Exception Handling
  - #### Resource Cleanup in Async Methods
  - #### Async Lambdas in Synchronous Delegates
  - #### Deadlocks with UI/ASP.NET Contexts
  - #### Improper Cancellation Handling
- ### Performance considerations
- ### Avoiding async void
- ### Composing async methods
## 9. Retry Patterns and Policies
- ### Implementing retry logic
- ### Using Polly for resilience policies
- ### Circuit breaker patterns
## 10. Testing Asynchronous Code
- ### Unit testing async methods
- ### Mocking async dependencies
- ### Handling timeouts in tests
## 11. Framework-specific Implementations
- ### ASP.NET Web APIs
  - #### Async controllers and actions
  - #### Middleware and filters with async
  - #### erformance considerations for web applications
- ### Entity Framework and Data Access
  - #### Async database operations
  - #### Avoiding N+1 query issues
  - #### Transaction management in async contexts
- ### Integration with Message Queues and Event-based Systems
  - #### Async event handling
  - #### Working with distributed systems
  - ### Messaging patterns
## 3. Real-world I/O Scenarios
- ### File I/O
- ### HTTP calls using HttpClient
- ### Database access with EF Core async

---

### The async and await Keywords

The async keyword converts a method into an asynchronous one enabling the use of the await keyword inside the method body. Note that Task and Task<T>v are two awaitable types provided by .NET Core. An async method 
returns a Task or Task<T> object and performs non-blocking operations. You must use the await keyword to call an async method

### Some key features of the async keyword include: 
- You can use the async keyword for methods, lambda expressions, and anonymous methods, but not for constructors or properties.
- An async method should have a minimum of one await expression in its body. In an async method, you can have multiple await keywords to handle multiple non-blocking operations.
- Methods that are async can be chained together.

when the await keyword is used to invoke an asynchronous method, it pauses execution of the awaited method and asynchronously waits for the Task to complete while the currently executing thread is sent back to the thread pool in lieu of keeping it in a blocked state. It should be noted that the await keyword can be used only in an async method.
