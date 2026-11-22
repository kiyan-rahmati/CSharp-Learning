// LESSON 01 - Hello World and the structure of a C# program
//
// This file uses "top-level statements" (C# 9+): the compiler automatically wraps
// everything below in a hidden Main method inside a hidden Program class.
// Execution starts at the first line and ends at the last line.

// Console is a class in the System namespace. "ImplicitUsings" (enabled in the .csproj)
// automatically adds `using System;` so we can write Console directly.

// WriteLine prints text and then moves to a new line.
Console.WriteLine("Hello, World!");

// Write prints text WITHOUT moving to a new line.
Console.Write("Hello, ");
Console.Write("again!");
Console.WriteLine(); // prints just a new line

// Comments:
// 1) Single-line comments start with //
/* 2) Multi-line comments
      are wrapped in slash-star ... star-slash */
/// 3) Three slashes are XML documentation comments (used above methods/classes).

// String interpolation: put $ before the string and wrap expressions in { }.
string name = "Kiyan";
Console.WriteLine($"My name is {name}");

// Escape sequences inside strings:
Console.WriteLine("Line 1\nLine 2");        // \n = new line
Console.WriteLine("Column1\tColumn2");      // \t = tab
Console.WriteLine("She said \"hi\"");       // \" = a literal quote
Console.WriteLine("C:\\Users\\Kiyan");      // \\ = a literal backslash
Console.WriteLine(@"C:\Users\Kiyan");       // @ makes it a "verbatim" string: no escapes needed

// Reading user input (the program pauses until the user presses Enter).
// Console.ReadLine() returns `string?` (the ? means it can be null, e.g. if input is closed).
Console.Write("What is your name? ");
string? input = Console.ReadLine();
Console.WriteLine($"Nice to meet you, {input ?? "stranger"}!"); // ?? gives a fallback if null
