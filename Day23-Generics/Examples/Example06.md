# Example 06 — Generics

## Goal
Experiment with a small C# idea while studying **generic types, generic methods, type parameters, constraints**.

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
