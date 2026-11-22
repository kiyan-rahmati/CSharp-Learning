// Lesson 06: Type Conversion
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Convert values safely using casts, Convert, Parse, and TryParse.

string input = "42";\nif (int.TryParse(input, out int number))\n    Console.WriteLine($"Parsed value: {number}");\nelse\n    Console.WriteLine("Invalid number");

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
