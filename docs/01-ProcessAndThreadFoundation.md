# ProcessAndThread Demo

This project demonstrates fundamental concepts of multithreading and process management in C# using .NET Framework 4.8. It includes practical examples of thread creation, synchronization, race conditions, and process/thread inspection.

## Features

- **Process Management:** Launch and inspect processes and their threads.
- **Thread Basics:** Create threads using named methods, delegates, and lambda expressions.
- **Thread Lifecycle:** Demonstrate thread states and lifecycle management.
- **Thread-Local Storage:** Show how each thread has its own stack.
- **Shared Data Section:** Illustrate race conditions and thread-safe techniques using `lock` and `Interlocked`.
- **Race Condition Patterns:** Examples of Check-Then-Act, Read-Modify-Write, and Initialization Races.
- **Shared OS Resources:** Demonstrate sharing OS-level resources between threads.

## Getting Started

### Prerequisites

- Visual Studio 2022 or later
- .NET Framework 4.8

### Running the Project

1. Clone the repository.
2. Open the AsyncDemoSolution/AsyncDemoSolution.sln in Visual Studio.
3. Set `ProcessAndThread` as the startup project.
4. Build and run (`F5`).

You can enable or comment out different demo methods in `Program.cs` to explore various threading and process scenarios.

## Key Files

- `Program.cs` – Entry point; select which demo to run.
- `ThreadingBasics.cs` – Thread creation patterns.
- `ThreadLifecycle.cs` – Thread state management.
- `SharedDataSection.cs` – Shared data and synchronization.
- `CheckThenAct.cs` – Check-then-act race condition demo.
- `InitializationRaces.cs` – Initialization race condition demo.
- `SharedOSResources.cs` – OS resource sharing demo.
- `PrivateStacks.cs` – Thread-local storage demo.

## License

This project is for educational purposes.

---

*Powered by C# and .NET Framework 4.8*
