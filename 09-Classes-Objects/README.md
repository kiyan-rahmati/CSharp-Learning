# Lesson 09 - Classes and Objects

## The big idea
OOP models real-world things as **objects** that combine data and behavior. A **class** is the template.

```csharp
class Car                       // the blueprint
{
    public string Brand { get; set; }      // data
    public void Drive() { ... }            // behavior
}
var c = new Car();              // an object (instance)
```

## Members of a class
| Member | Meaning |
|---|---|
| Field | variable inside the class (usually `private`) |
| Property | smart accessor over data (`get`/`set`) |
| Method | action |
| Constructor | runs when you do `new`; initializes the object |
| `static` | belongs to the class, shared, accessed as `ClassName.Member` |

## Access modifiers
`public` (everyone), `private` (only this class; **default for members**), `protected` (this class + children), `internal` (same project), `protected internal`, `private protected`.

## `this`
Refers to the current object. Needed when a parameter has the same name as a field: `this.name = name;`.

## Reference semantics
`Car b = a;` copies the *reference*. Both variables see the same object. To get an independent copy you must create a new object (or use `record`/`with`, Lesson 19).

## File organization tip
One class per file in real projects (`Car.cs`). In this lesson classes are at the bottom of `Program.cs` for simplicity; with top-level statements, type declarations must come after the statements.

## Run it
```bash
dotnet run --project 09-Classes-Objects
```

## Exercises
1. Create a `Student` class with `Name`, `Grade` and a method `IsPassing()` (true if grade >= 10).
2. Create `BankAccount` with `Balance`, `Deposit(amount)`, `Withdraw(amount)` (refuse if not enough money).
3. Add a static counter to `Student` that counts how many were created.

<details><summary>Solutions</summary>

```csharp
class Student
{
    public static int Count { get; private set; }
    public string Name { get; }
    public double Grade { get; }
    public Student(string name, double grade) { Name = name; Grade = grade; Count++; }
    public bool IsPassing() => Grade >= 10;
}

class BankAccount
{
    public decimal Balance { get; private set; }
    public void Deposit(decimal amount) { if (amount > 0) Balance += amount; }
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance) return false;
        Balance -= amount;
        return true;
    }
}
```
</details>
