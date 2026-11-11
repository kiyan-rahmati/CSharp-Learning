// Lesson 01: Introduction to Programming and C#

Console.WriteLine("CSharp Learning Journey - Lesson 01");
Console.WriteLine("Introduction to Programming and C#");

Console.WriteLine("Hello, World!");

Console.Write("Enter your name: ");
string name = Console.ReadLine()!;

Console.WriteLine($"Welcome {name}");

Console.WriteLine("This project calculates two numbers for you.");

Console.Write("Enter first number: ");
int number1 = int.Parse(Console.ReadLine()!);

Console.Write("Enter second number: ");
int number2 = int.Parse(Console.ReadLine()!);

Console.WriteLine();
Console.WriteLine("Choose an operation:");

Console.WriteLine(">>> Addition (press +)");
Console.WriteLine(">>> Subtraction (press -)");
Console.WriteLine(">>> Multiplication (press *)");
Console.WriteLine(">>> Division (press /)");

Console.Write("Enter your operation: ");
string choose = Console.ReadLine()!;

if (choose == "+")
{
    int result = number1 + number2;
    Console.WriteLine($"Result: {result}");
}
else if (choose == "-")
{
    int result = number1 - number2;
    Console.WriteLine($"Result: {result}");
}
else if (choose == "*")
{
    int result = number1 * number2;
    Console.WriteLine($"Result: {result}");
}
else if (choose == "/")
{
    if(number2 != 0)
    {
        double result = (double)number1 / number2;
        Console.WriteLine($"Result: {result}");
    }
    else
    {
        Console.WriteLine("Invalid operation!");
    }
} 