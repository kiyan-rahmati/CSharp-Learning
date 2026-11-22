# Example 06 — Type Conversion

## Goal
Experiment with a small C# idea while studying **implicit, explicit cast, Convert, Parse, TryParse, conversion safety**.

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
