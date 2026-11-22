// Lesson 08: Input, Output and Strings
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Read console input, format output, and manipulate strings safely.

Console.Write("Enter your name: ");\nstring name = Console.ReadLine() ?? "";\nstring cleaned = name.Trim();\nConsole.WriteLine($"Hello, {cleaned}!");

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
