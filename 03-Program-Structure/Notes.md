# Lesson 03: Program Structure in C#

## 1. Introduction

Every C# application follows a specific structure that defines how its code is organized and executed.

Understanding this structure is essential for writing clean, maintainable, and organized applications.

## 2. Using Directives

The `using` directive allows developers to access types and members defined in namespaces without writing their fully qualified names.

Example:

```csharp
using System;

Console.WriteLine("Hello World!");
```

The `System` namespace provides fundamental classes such as `Console`.

## 3. Namespaces

Namespaces organize related classes and prevent naming conflicts.

Example:

```csharp
namespace Customers
{
    class User
    {
    }
}

namespace Employees
{
    class User
    {
    }
}
```

Both classes can have the same name because they belong to different namespaces.

## 4. Classes

A class is a blueprint for creating objects.

Classes can contain:

- Fields
- Properties
- Methods
- Constructors
- Events

Example:

```csharp
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello from C#!");
    }
}
```

## 5. Main Method

In the traditional C# application structure, the `Main` method is the entry point of the application.

Example:

```csharp
static void Main(string[] args)
{
    Console.WriteLine("Application Started!");
}
```

### Main Method Components

- `static`: Allows the method to be called without creating an instance of the class.
- `void`: Indicates that the method does not return a value.
- `Main`: The conventional entry point method name.
- `string[] args`: Contains command-line arguments passed to the application.

## 6. Top-Level Statements

Modern C# supports Top-Level Statements, which allow developers to write executable code without explicitly declaring a class or Main method.

Example:

```csharp
Console.WriteLine("Hello Kiyan!");
Console.WriteLine("Welcome to C# Learning Journey.");
```

This feature was introduced in C# 9.

The compiler generates the necessary entry-point structure automatically.

## 7. Comments

Comments are used to explain code and improve readability. They are ignored during normal program execution.

### Single-Line Comments

```csharp
// This is a single-line comment.
```

### Multi-Line Comments

```csharp
/*
This is a multi-line comment.
It can contain multiple lines.
*/
```

### XML Documentation Comments

```csharp
/// <summary>
/// Displays a welcome message.
/// </summary>
```

XML documentation comments help developers document classes and methods.

## 8. Code Blocks

Code blocks are sections of code enclosed within curly braces `{ }`.

They define the body of classes, methods, loops, and conditional statements.

Example:

```csharp
if (true)
{
    Console.WriteLine("Hello!");
}
```

## 9. Key Concepts Learned

- Using Directives
- Namespaces
- Classes
- Main Method
- Static and Void
- Top-Level Statements
- Comments
- Code Blocks

## Conclusion

Understanding the structure of C# programs helps developers write organized and maintainable code.

These concepts are fundamental for learning Object-Oriented Programming and building larger applications with C# and .NET.