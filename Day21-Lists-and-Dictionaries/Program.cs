// Day 21: Collections: List and Dictionary
// Run with dotnet run. Modify values and observe the behavior.
using System;
using System.Linq;

Console.WriteLine("Day 21 — Collections: List and Dictionary");
Console.WriteLine(new string('-', 38));

// Experiment 1
Console.WriteLine("Start here");

// Experiment 2
string subject = "Collections: List and Dictionary";
Console.WriteLine(subject);

// Experiment 3
int x = 12;
int y = 5;
Console.WriteLine($"Result: {x + y}");

// Experiment 4
bool isReady = true;
Console.WriteLine(isReady ? "Ready" : "Not ready");

// Experiment 5
foreach (int item in new[] { 2, 4, 6 })
{
    Console.WriteLine(item);
}

// Experiment 6
string input = "42";
if (int.TryParse(input, out int value))
{
    Console.WriteLine(value * 2);
}

// Experiment 7
int[] values = { 3, 7, 11 };
Console.WriteLine($"Count={values.Length}, Sum={values.Sum()}");

// Experiment 8
Console.WriteLine("Change a value, predict the output, then run again.");
