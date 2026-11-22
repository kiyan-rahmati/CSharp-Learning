// Lesson 30: Lambda Expressions
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Write concise anonymous functions and understand their use.

Func<int, bool> isEven = number => number % 2 == 0;\nConsole.WriteLine(isEven(8));\nvar doubled = new[] { 1, 2, 3 }.Select(n => n * 2);\nConsole.WriteLine(string.Join(", ", doubled));

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
