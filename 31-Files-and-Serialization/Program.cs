// Lesson 31: Files and Serialization
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Persist data and work with text, JSON, and file paths.

string path = "tasks.txt";\nFile.WriteAllLines(path, new[] { "Learn C#", "Practice LINQ" });\nstring[] lines = File.ReadAllLines(path);\nConsole.WriteLine(string.Join(Environment.NewLine, lines));

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
