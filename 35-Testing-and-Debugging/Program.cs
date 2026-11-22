// Lesson 35: Testing and Debugging
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Write tests and use debugger tools to locate defects.

static int Divide(int a, int b) => b == 0 ? throw new ArgumentException("Divisor cannot be zero.") : a / b;\nConsole.WriteLine(Divide(10, 2));\n// In real projects, test this behavior with a unit-testing framework.

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
