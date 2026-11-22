// Lesson 29: LINQ
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Query collections declaratively and compose transformations.

var numbers = new[] { 7, 2, 9, 4, 6 };\nvar result = numbers.Where(n => n > 4).OrderBy(n => n).Select(n => n * 2);\nConsole.WriteLine(string.Join(", ", result));

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
