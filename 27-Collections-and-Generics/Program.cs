// Lesson 27: Collections and Generics
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Use flexible collection types and generic reusable code.

var stock = new Dictionary<string, int> { ["pen"] = 12, ["book"] = 4 };\nstock["pen"] -= 1;\nConsole.WriteLine(stock["pen"]);\nvar names = new List<string> { "Ana", "Sam" };\nConsole.WriteLine(names.Count);

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
