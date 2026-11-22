# Lesson 11 - Inheritance and Polymorphism

## Inheritance
```csharp
class Dog : Animal { }     // Dog inherits everything non-private from Animal
```
- A class has **one** base class (single inheritance). Everything ultimately inherits from `System.Object`, which is why every object has `ToString()`, `Equals()`, `GetHashCode()`, `GetType()`.
- `protected` members are visible to children.
- Use `base(...)` to call the parent's constructor and `base.Method()` for the parent's method.

## Polymorphism keywords
| Keyword | Where | Meaning |
|---|---|---|
| `virtual` | parent method | children may override |
| `override` | child method | replaces the parent's virtual/abstract method |
| `abstract` | parent method/class | no body, children **must** override (Lesson 12) |
| `sealed` | class or override | cannot be inherited/overridden further |
| `new` | child member | hides the parent's member (avoid; it is NOT polymorphism) |

## Casting
- Upcast (child -> parent) is implicit and always safe.
- Downcast (parent -> child) needs a check: `is`, `as`, or an explicit cast `(Dog)pet` which throws `InvalidCastException` on failure.

## Is-a vs has-a: prefer composition
Inheritance creates tight coupling. If the relationship is "has-a" (a Car **has** an Engine), use a field/property (composition), not inheritance. Rule of thumb: *favor composition over inheritance*.

## Run it
```bash
dotnet run --project 11-Inheritance-Polymorphism
```

## Exercises
1. Create `Shape` (virtual `Area()` returning 0) with children `Circle`, `Rectangle`. Put them in a `List<Shape>` and print each area and the total.
2. Add `Employee` and `Manager : Employee` with a `GetSalary()` that adds a bonus for managers.
3. What prints for `Animal a = new Cat("x"); a.Describe();`? Why?

<details><summary>Solutions</summary>

```csharp
class Shape { public virtual double Area() => 0; }
class Circle : Shape
{
    public double R { get; }
    public Circle(double r) { R = r; }
    public override double Area() => Math.PI * R * R;
}
class Rectangle : Shape
{
    public double W { get; }
    public double H { get; }
    public Rectangle(double w, double h) { W = w; H = h; }
    public override double Area() => W * H;
}
// total: shapes.Sum(s => s.Area());

class Employee
{
    public decimal BaseSalary { get; init; }
    public virtual decimal GetSalary() => BaseSalary;
}
class Manager : Employee
{
    public decimal Bonus { get; init; }
    public override decimal GetSalary() => base.GetSalary() + Bonus;
}

// 3) "Animal named x": Describe is not virtual, so the call is bound to the declared type Animal.
```
</details>
