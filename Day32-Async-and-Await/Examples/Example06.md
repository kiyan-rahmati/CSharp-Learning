# Example 06 — Async and Await

## Goal
Experiment with a small C# idea while studying **Task, Task<T>, async, await, cancellation, asynchronous I/O**.

```csharp
string input = "42";
if (int.TryParse(input, out int value))
{
    Console.WriteLine(value * 2);
}
```

## Try it
- Change a value or input.
- Predict the output before running.
- Add a validation or boundary case.
