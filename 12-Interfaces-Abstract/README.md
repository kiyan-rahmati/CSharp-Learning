# Lesson 12 - Interfaces and Abstract Classes

## Interface vs abstract class
| | Interface | Abstract class |
|---|---|---|
| Purpose | capability / contract ("can do") | shared base ("is a") |
| Inheritance | a class can implement **many** | a class can extend **one** |
| State (fields) | no | yes |
| Constructors | no | yes |
| Implementation | none (default methods exist, rarely used) | mix of abstract + concrete |
| Naming | starts with `I` (`IDisposable`) | normal name |

**Choose** an interface when unrelated types share a behavior (`IComparable`, `IDisposable`, `IEnumerable`). **Choose** an abstract class when closely-related types share code and state.

## Why interfaces matter
They decouple code. `OrderService` knows only `INotifier`; you can plug in email, SMS, or a fake for tests. This is the basis of **Dependency Injection**, used heavily in ASP.NET Core.

## Built-in interfaces worth knowing
`IDisposable` (cleanup, pairs with `using`), `IEnumerable<T>` (can be looped / LINQ), `IComparable<T>` (default sort order), `IEquatable<T>`, `IComparer<T>`.

## SOLID mini-notes
- **S**ingle responsibility: one reason to change per class.
- **O**pen/closed: extend by adding types, not editing old ones.
- **L**iskov: a child must be usable wherever the parent is.
- **I**nterface segregation: many small interfaces beat one huge one.
- **D**ependency inversion: depend on abstractions.

## Run it
```bash
dotnet run --project 12-Interfaces-Abstract
```

## Exercises
1. Define `IShape { double Area(); double Perimeter(); }` and implement it for `Circle` and `Square`.
2. Create `ILogger` with `ConsoleLogger` and `FileLogger` (appends to a text file); inject it into a class.
3. Make `Product` implement `IComparable<Product>` to sort by price.

<details><summary>Solutions</summary>

```csharp
interface IShape { double Area(); double Perimeter(); }
class Square : IShape
{
    private readonly double _s;
    public Square(double s) => _s = s;
    public double Area() => _s * _s;
    public double Perimeter() => 4 * _s;
}

interface ILogger { void Log(string m); }
class ConsoleLogger : ILogger { public void Log(string m) => Console.WriteLine(m); }
class FileLogger : ILogger
{
    public void Log(string m) => File.AppendAllText("log.txt", m + Environment.NewLine);
}

class Product : IComparable<Product>
{
    public decimal Price { get; init; }
    public int CompareTo(Product? o) => o is null ? 1 : Price.CompareTo(o.Price);
}
```
</details>
