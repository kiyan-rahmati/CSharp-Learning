// Lesson 18: Complexity and Big O
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Estimate how algorithm work grows with input size.

// Linear scan examines items one by one: O(n)\nint[] values = { 3, 6, 9, 12 };\nint target = 9;\nint checks = 0;\nforeach (int value in values) { checks++; if (value == target) break; }\nConsole.WriteLine($"Checks: {checks}");

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
