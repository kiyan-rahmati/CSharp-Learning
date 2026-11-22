// Lesson 22: Constructors and Properties
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Initialize objects consistently and expose state safely.

var item = new Product("Notebook", 4.50m);\nConsole.WriteLine($"{item.Name}: {item.Price:C}");\n\nclass Product(string name, decimal price)\n{ public string Name { get; } = name; public decimal Price { get; } = price; }

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
