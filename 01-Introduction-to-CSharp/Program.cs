// Lesson 01: Introduction to Programming and C#
// The lesson's examples and exercises will be added here.

Console.WriteLine("CSharp Learning Journey - Lesson 01");
Console.WriteLine("Introduction to Programming and C#");

Console.WriteLine("Hellow; world!");

Console.Write("Enter your name : ");
string name = Console.ReadLine()!;

Console.WriteLine($"Welcome {name}");
Console.WriteLine("This project calculates two numbers for you.");

//this is a Calculator
Console.Write("Enter first number: ");
int number1 = int.Parse(Console.ReadLine()!);
Console.Write("Enter second number: ");
int number2 = int.Parse(Console.ReadLine()!);
//result of number 1 + number 2 
int result = number1 + number2;
Console.WriteLine("Result:" + result);