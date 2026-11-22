# Lesson 01 - Hello World

## What you will learn
- What C#, .NET, the SDK, and the compiler are
- How to create, build, and run a console app
- Structure of a C# program
- Printing and reading text

## Key concepts

**C#** is the language. **.NET** is the platform (runtime + libraries) that runs it. The **.NET SDK** contains the compiler and the `dotnet` command-line tool.

When you run `dotnet run`:
1. The compiler turns your `.cs` files into an intermediate language (IL) stored in a `.dll`.
2. The runtime (CLR) compiles IL to machine code on the fly (JIT) and runs it.

**Files of a project**
| File | Purpose |
|---|---|
| `Program.cs` | Your code |
| `*.csproj` | Project settings: target framework, nullable, implicit usings |
| `bin/`, `obj/` | Build output (generated, never edit; ignored by git) |

**Top-level statements** let you write code without the `class Program { static void Main() }` boilerplate. Older style (still valid):

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello");
    }
}
```

**Every statement ends with a semicolon `;`**. Blocks use `{ }`. C# is case-sensitive: `Console` is not `console`.

## Run it
```bash
dotnet run --project 01-HelloWorld
```

## Exercises
1. Print your full name, city, and favorite language on three separate lines.
2. Ask the user for their name and age, then print a sentence using string interpolation.
3. Print this using escape sequences: a tab-separated row `Name    Age    City`.

<details><summary>Solutions</summary>

```csharp
// 1
Console.WriteLine("Kiyan Rahmati");
Console.WriteLine("Rasht");
Console.WriteLine("C#");

// 2
Console.Write("Name: ");
string? name = Console.ReadLine();
Console.Write("Age: ");
string? age = Console.ReadLine();
Console.WriteLine($"{name} is {age} years old.");

// 3
Console.WriteLine("Name\tAge\tCity");
```
</details>

## Common mistakes
- Forgetting `;` -> error `CS1002: ; expected`.
- Wrong case: `console.writeline` -> error `CS0103`.
- Mismatched quotes or braces.
