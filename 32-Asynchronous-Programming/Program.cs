// Lesson 32: Asynchronous Programming
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Avoid blocking while waiting for I/O using async/await.

static async Task MainAsync()\n{\n    await Task.Delay(300); // Simulates asynchronous waiting\n    Console.WriteLine("Finished waiting without blocking this async flow.");\n}\nawait MainAsync();

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
