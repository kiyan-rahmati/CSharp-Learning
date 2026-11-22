// Lesson 26: Exception Handling
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Handle exceptional conditions without hiding programming errors.

try\n{\n    int value = int.Parse("not-a-number");\n    Console.WriteLine(value);\n}\ncatch (FormatException) { Console.WriteLine("Input format was invalid."); }

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
