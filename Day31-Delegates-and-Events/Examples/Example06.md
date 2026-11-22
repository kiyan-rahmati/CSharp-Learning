# Example 06 — Delegates and Events

## Goal
Experiment with a small C# idea while studying **delegate, Action, Func, Predicate, events, subscribe/unsubscribe**.

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
