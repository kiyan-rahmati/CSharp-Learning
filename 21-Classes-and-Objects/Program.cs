// Lesson 21: Classes and Objects
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Model entities with classes, fields, properties, and instances.

var book = new Book("Clean Code", "Robert C. Martin");\nConsole.WriteLine(book.Title);\n\nclass Book(string title, string author)\n{ public string Title { get; } = title; public string Author { get; } = author; }

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
