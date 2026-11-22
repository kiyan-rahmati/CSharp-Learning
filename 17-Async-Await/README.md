# Lesson 17 - async / await

## Synchronous vs asynchronous
- **Synchronous**: line by line; a slow call blocks everything.
- **Asynchronous**: start the slow call, free the thread, continue when it finishes.

## The `Task` family
| Type | Meaning |
|---|---|
| `Task` | an operation that will finish (no result) |
| `Task<T>` | an operation that will produce a `T` |
| `ValueTask<T>` | lighter variant for hot paths |
| `IAsyncEnumerable<T>` | async sequence, used with `await foreach` |

## Essential rules
1. `async` method -> returns `Task` / `Task<T>`; use `await` inside.
2. **Never block** on async code with `.Result` or `.Wait()` (deadlock risk, wasted thread). Use `await`.
3. Avoid `async void` (exceptions cannot be caught); only for event handlers.
4. Start tasks first, `await` later to run them **concurrently** (`Task.WhenAll`).
5. Pass a `CancellationToken` through long operations.
6. `Task.Run` is for CPU-heavy work; for I/O, use the real async APIs (`HttpClient.GetStringAsync`, `File.ReadAllTextAsync`, EF Core `ToListAsync`).
7. In library code consider `ConfigureAwait(false)`; ASP.NET Core and console apps do not need it.

## Real-world examples (need internet; here only as reference)
```csharp
using var http = new HttpClient();
string html = await http.GetStringAsync("https://example.com");
string text = await File.ReadAllTextAsync("data.txt");
```

## Run it
```bash
dotnet run --project 17-Async-Await
```

## Exercises
1. Write `async Task<int> SlowSquareAsync(int n)` that waits 300 ms then returns `n*n`. Call it for 1..5 **in parallel** and print the results.
2. Time the difference between awaiting five 200 ms tasks sequentially and with `Task.WhenAll`.
3. Add a timeout: cancel a 5-second task after 1 second.

<details><summary>Solutions</summary>

```csharp
async Task<int> SlowSquareAsync(int n) { await Task.Delay(300); return n * n; }

var tasks = Enumerable.Range(1, 5).Select(SlowSquareAsync);   // starts all five
int[] squares = await Task.WhenAll(tasks);
Console.WriteLine(string.Join(", ", squares));

using var cts = new CancellationTokenSource(1000);
try { await Task.Delay(5000, cts.Token); }
catch (TaskCanceledException) { Console.WriteLine("Timeout"); }
```
</details>
