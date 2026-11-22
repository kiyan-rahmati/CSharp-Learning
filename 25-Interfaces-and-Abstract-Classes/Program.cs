// Lesson 25: Interfaces and Abstract Classes
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Define contracts and shared base behavior with the right tool.

IShape[] shapes = { new Circle(2), new Rectangle(3, 4) };\nforeach (IShape shape in shapes) Console.WriteLine(shape.Area());\n\ninterface IShape { double Area(); }\nclass Circle(double radius) : IShape { public double Area() => Math.PI * radius * radius; }\nclass Rectangle(double w, double h) : IShape { public double Area() => w * h; }

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
