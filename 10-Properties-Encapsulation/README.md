# Lesson 10 - Properties and Encapsulation

## Why not public fields?
```csharp
public class Bad { public decimal Balance; }   // anyone can set Balance = -999999
```
Encapsulation keeps data private and lets the class **enforce rules**.

## Property forms
```csharp
public string Name { get; set; }               // auto-property (read + write)
public string Id { get; }                      // read-only (set in constructor)
public decimal Balance { get; private set; }   // public read, private write
public int X { get; init; }                    // set only at creation / initializer
public string Full => $"{First} {Last}";       // computed
public int Age { get => _age; set { /* validate */ _age = value; } }   // full property
```

## Constructors
- Initialize required state, validate arguments, throw on invalid input.
- Overloads can chain: `public Rectangle(double s) : this(s, s) { }`.
- Use `required` (C# 11) to force callers to set a property in an object initializer: `public required string Name { get; init; }`.

## Guard clauses and exceptions
Validate early and throw `ArgumentException`/`ArgumentOutOfRangeException`/`ArgumentNullException`. Use `nameof(param)` instead of hard-coded strings.

## Design rule of thumb
Make things as **private as possible**, as **immutable as possible**, and expose **methods that make sense for the domain** (`Deposit`) rather than raw setters.

## Run it
```bash
dotnet run --project 10-Properties-Encapsulation
```

## Exercises
1. `Temperature` class storing Celsius with a computed `Fahrenheit` property; reject values below -273.15.
2. `Product` with `Name`, `Price` (must be > 0), `Stock` (private set) and `Sell(int qty)` returning false if stock is too low.
3. Make `Point` from the demo immutable using a constructor instead of `init`.

<details><summary>Solutions</summary>

```csharp
class Temperature
{
    private double _c;
    public double Celsius
    {
        get => _c;
        set { if (value < -273.15) throw new ArgumentOutOfRangeException(nameof(value)); _c = value; }
    }
    public double Fahrenheit => Celsius * 9 / 5 + 32;
}

class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public int Stock { get; private set; }
    public Product(string name, decimal price, int stock)
    {
        if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));
        Name = name; Price = price; Stock = stock;
    }
    public bool Sell(int qty)
    {
        if (qty <= 0 || qty > Stock) return false;
        Stock -= qty; return true;
    }
}

class ImmutablePoint
{
    public double X { get; }
    public double Y { get; }
    public ImmutablePoint(double x, double y) { X = x; Y = y; }
}
```
</details>
