# C# Learning

A complete, offline-friendly path from zero to a working Web API in C# and .NET.
Every lesson is a small runnable project with:

- `Program.cs`: heavily commented code you can run and modify
- `README.md`: the theory, a cheat sheet, common mistakes, **exercises, and solutions**

Everything uses only what ships with the .NET SDK, so after the one-time setup **no internet is needed**.

## Quick start
```bash
# 1. Install the .NET SDK (see docs/00-Setup.md)
# 2. Set your framework version in Directory.Build.props  (net8.0 / net9.0 / net10.0)
# 3. Check that everything builds
./check-all.sh

# 4. Run any lesson
./run.sh 01
# or
dotnet run --project 01-HelloWorld
```

## Curriculum

### Part 1: Foundations
| # | Lesson | You will learn |
|---|---|---|
| 01 | [Hello World](01-HelloWorld) | program structure, printing, reading input |
| 02 | [Variables & Data Types](02-Variables-DataTypes) | `int`, `double`, `decimal`, `string`, `var`, value vs reference types |
| 03 | [Operators & Conversion](03-Operators-Conversion) | arithmetic, logic, casting, `TryParse` |
| 04 | [Conditionals](04-Conditionals) | `if`, `switch`, pattern matching |
| 05 | [Loops](05-Loops) | `for`, `while`, `foreach`, `break`, `continue` |
| 06 | [Arrays & Lists](06-Arrays-Lists) | arrays, `List<T>`, ranges |
| 07 | [Methods](07-Methods) | parameters, `out`/`ref`, overloading, recursion |
| 08 | [Strings](08-Strings) | string API, `StringBuilder`, formatting |

### Part 2: Object-Oriented Programming
| # | Lesson | You will learn |
|---|---|---|
| 09 | [Classes & Objects](09-Classes-Objects) | classes, constructors, `static` |
| 10 | [Properties & Encapsulation](10-Properties-Encapsulation) | properties, validation, immutability |
| 11 | [Inheritance & Polymorphism](11-Inheritance-Polymorphism) | `virtual`, `override`, `base` |
| 12 | [Interfaces & Abstract Classes](12-Interfaces-Abstract) | contracts, dependency injection idea, `IDisposable` |

### Part 3: Intermediate C#
| # | Lesson | You will learn |
|---|---|---|
| 13 | [Exceptions](13-Exceptions) | `try/catch/finally`, custom exceptions |
| 14 | [Generics & Collections](14-Generics-Collections) | `Dictionary`, `HashSet`, `Queue`, `Stack`, `<T>` |
| 15 | [LINQ](15-LINQ) | filtering, grouping, joining, deferred execution |
| 16 | [Delegates, Lambdas, Events](16-Delegates-Events-Lambdas) | `Func`, `Action`, events, closures |
| 17 | [Async / Await](17-Async-Await) | `Task`, `WhenAll`, cancellation |
| 18 | [Files & JSON](18-Files-JSON) | `System.IO`, `System.Text.Json` |
| 19 | [Records, Patterns, Nullable](19-Records-Patterns-Nullable) | modern C# features |

### Part 4: Putting it together
| # | Lesson | You will learn |
|---|---|---|
| 20 | [Mini Project: To-Do App](20-MiniProject-TodoApp) | layered architecture, persistence |
| 21 | [Algorithms & Data Structures](21-Algorithms) | Big-O, sorting, searching, linked list, BFS |
| 22 | [Web API (ASP.NET Core)](22-WebApi-Minimal) | REST, middleware, DI, CRUD endpoints |

Extra material: [Setup guide](docs/00-Setup.md) and [Cheat sheet](docs/CHEATSHEET.md).

## How to study each lesson (the method that works)
1. **Read** the lesson `README.md` (5-10 min).
2. **Run** `Program.cs`, then read it line by line next to the output.
3. **Break it on purpose**: change values, remove a line, introduce an error. Read the compiler message. This is how you learn what each piece does.
4. **Do the exercises** in a new project *without* looking at the solutions. Struggling for 15 minutes is where the learning happens.
5. **Compare** with the solutions, then re-write the solution in your own style.
6. **Explain it** in your own words (a comment, a note, or out loud). If you cannot explain it, you do not own it yet.

## Suggested schedule (about 8 weeks, 1 to 2 hours a day)
| Week | Lessons |
|---|---|
| 1 | 01-05 |
| 2 | 06-08 + redo exercises |
| 3 | 09-10 |
| 4 | 11-12 |
| 5 | 13-15 |
| 6 | 16-18 |
| 7 | 19-20 (extend the To-Do app with the challenges) |
| 8 | 21-22 |

## After this repo
- **Entity Framework Core** and a real database (SQLite/PostgreSQL)
- **Authentication** (JWT, ASP.NET Core Identity)
- **Unit testing** (xUnit) and clean architecture
- **Docker** and deployment
- Pair a C# API with a **React** frontend: a strong full-stack portfolio project

## Notes
- Lessons are written for .NET 8+ (C# 12). They are version-agnostic as long as you set the right `TargetFramework`.
- If a lesson fails to build, read the first error line; it normally names the file, line, and cause. Run `dotnet --version` and compare with `Directory.Build.props`.
- Created for personal learning; feel free to fork and extend.
