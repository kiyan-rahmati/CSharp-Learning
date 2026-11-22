# Lesson 13 - Exception Handling

## The model
```csharp
try        { /* risky code */ }
catch (SpecificException ex) { /* recover */ }
catch (Exception ex)         { /* last resort */ }
finally    { /* always runs: cleanup */ }
```
- When `throw` happens, execution jumps to the nearest matching `catch` up the call stack.
- Order catches from **specific to general**; the compiler rejects an unreachable order.

## Good practices
1. **Catch only what you can handle.** Do not swallow errors with an empty `catch {}`.
2. **Do not use exceptions for expected situations** (invalid user input): use `TryParse`, null checks, validation.
3. **Re-throw with `throw;`**, not `throw ex;`.
4. **Wrap** low-level exceptions in meaningful ones and keep `InnerException`.
5. **Use `using`** for anything that implements `IDisposable` (files, connections, streams).
6. Log exceptions with message + stack trace (`ex.ToString()`).
7. Throw the most specific built-in type, or create a custom one when callers need to react to it.

## Useful members
`ex.Message`, `ex.StackTrace`, `ex.InnerException`, `ex.GetType().Name`, `ex.Data`.

## Guard helpers (modern C#)
```csharp
ArgumentNullException.ThrowIfNull(arg);
ArgumentException.ThrowIfNullOrEmpty(text);
ArgumentOutOfRangeException.ThrowIfNegative(number);
```

## Run it
```bash
dotnet run --project 13-Exceptions
```

## Exercises
1. Write `int SafeDivide(int a, int b)` that returns 0 and prints a message when `b == 0`.
2. Read a file path; handle `FileNotFoundException` and `UnauthorizedAccessException` separately.
3. Create `InvalidAgeException` and throw it from a `Person` constructor when age < 0.
4. Why does `finally` still run if the `try` block has a `return`?

<details><summary>Solutions</summary>

```csharp
int SafeDivide(int a, int b)
{
    try { return a / b; }
    catch (DivideByZeroException) { Console.WriteLine("Cannot divide by zero"); return 0; }
}

try { Console.WriteLine(File.ReadAllText("missing.txt")); }
catch (FileNotFoundException) { Console.WriteLine("File not found"); }
catch (UnauthorizedAccessException) { Console.WriteLine("No permission"); }

class InvalidAgeException : Exception
{
    public InvalidAgeException(int age) : base($"Invalid age: {age}") { }
}

// 4) The runtime guarantees finally executes before control leaves the try block.
```
</details>
