// Lesson 24: Inheritance and Polymorphism
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Reuse and specialize behavior through base and derived classes.

Animal[] animals = { new Dog(), new Cat() };\nforeach (Animal animal in animals) animal.Speak();\n\nclass Animal { public virtual void Speak() => Console.WriteLine("Sound"); }\nclass Dog : Animal { public override void Speak() => Console.WriteLine("Bark"); }\nclass Cat : Animal { public override void Speak() => Console.WriteLine("Meow"); }

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
