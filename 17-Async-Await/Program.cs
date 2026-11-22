// LESSON 17 - Asynchronous programming: async / await
//
// PROBLEM: some operations WAIT (network, disk, database, timers). If the thread just sits and waits,
// a UI freezes and a web server wastes threads that could serve other users.
//
// SOLUTION: async/await. While we await, the thread is released to do other work.
// When the awaited operation completes, the method resumes after the 'await'.
//
// Rules:
//  - A method that uses 'await' must be marked 'async'.
//  - It returns Task (no result) or Task<T> (result of type T). (async void only for event handlers.)
//  - Name async methods with the suffix "Async".
//  - Async is about WAITING efficiently; it is not the same thing as multi-threading for CPU work.

using System.Diagnostics;

// Top-level statements can use 'await' directly (the compiler makes Main async for us).

Console.WriteLine("=== 1. Sequential awaits ===");
var sw = Stopwatch.StartNew();
string a = await FetchAsync("A", 500);
string b = await FetchAsync("B", 500);
Console.WriteLine($"{a}, {b} -> {sw.ElapsedMilliseconds} ms");        // about 1000 ms

Console.WriteLine("=== 2. Parallel with Task.WhenAll ===");
sw.Restart();
Task<string> taskA = FetchAsync("A", 500);           // starts immediately, doesn't wait yet
Task<string> taskB = FetchAsync("B", 500);           // starts immediately too
string[] results = await Task.WhenAll(taskA, taskB); // waits for BOTH
Console.WriteLine($"{string.Join(", ", results)} -> {sw.ElapsedMilliseconds} ms");   // about 500 ms

Console.WriteLine("=== 3. Task.WhenAny (first one wins) ===");
Task<string> fast = FetchAsync("fast", 200);
Task<string> slow = FetchAsync("slow", 800);
Task<string> winner = await Task.WhenAny(fast, slow);
Console.WriteLine($"Winner: {await winner}");

Console.WriteLine("=== 4. Exceptions flow through await ===");
try
{
    await FailAsync();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught async exception: {ex.Message}");
}

Console.WriteLine("=== 5. Cancellation ===");
using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(300));   // auto-cancel after 300 ms
try
{
    await LongJobAsync(cts.Token);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Job was cancelled");
}

Console.WriteLine("=== 6. CPU-bound work: Task.Run ===");
long sum = await Task.Run(() =>
{
    long s = 0;
    for (int i = 1; i <= 100_000_000; i++) s += i;       // heavy loop runs on a thread-pool thread
    return s;
});
Console.WriteLine($"Sum = {sum}");

Console.WriteLine("=== 7. Async streams (await foreach) ===");
await foreach (int number in CountAsync(3))
{
    Console.WriteLine($"Got {number}");
}

Console.WriteLine("Done.");

// ================= Async methods =================

async Task<string> FetchAsync(string name, int delayMs)
{
    // Task.Delay is the async version of Thread.Sleep: it does NOT block the thread.
    await Task.Delay(delayMs);
    return $"Result-{name}";
}

async Task FailAsync()
{
    await Task.Delay(50);
    throw new InvalidOperationException("Something failed in the background");
}

async Task LongJobAsync(CancellationToken token)
{
    for (int i = 1; i <= 10; i++)
    {
        token.ThrowIfCancellationRequested();            // cooperative cancellation
        await Task.Delay(100, token);
        Console.WriteLine($"  step {i}");
    }
}

async IAsyncEnumerable<int> CountAsync(int max)
{
    for (int i = 1; i <= max; i++)
    {
        await Task.Delay(100);
        yield return i;
    }
}
