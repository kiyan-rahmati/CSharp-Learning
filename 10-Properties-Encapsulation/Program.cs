// LESSON 10 - Properties, constructors, and encapsulation
//
// ENCAPSULATION = hide internal data and expose only a safe, controlled interface.
// Why? So an object can never be put into an invalid state from outside.

var acc = new Account("Kiyan", 100m);
Console.WriteLine(acc);

acc.Deposit(50m);
Console.WriteLine($"Balance: {acc.Balance}");

bool ok = acc.Withdraw(500m);                // not enough money
Console.WriteLine($"Withdraw 500 succeeded? {ok}");

// acc.Balance = 1_000_000m;                 // ERROR: setter is private. Balance can only change through methods.

// Validation inside a property setter
var p = new Person { Name = "Sara", Age = 25 };
try
{
    p.Age = -5;                              // setter will throw
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Rejected: {ex.Message}");
}
Console.WriteLine(p.Summary);                // computed (read-only) property

// init-only properties: set once at creation, then immutable
var point = new Point { X = 3, Y = 4 };
// point.X = 10;                             // ERROR: init-only
Console.WriteLine($"Distance from origin: {point.DistanceFromOrigin:F2}");

// Constructor chaining and overloads
var d1 = new Rectangle();                    // 1 x 1
var d2 = new Rectangle(5);                   // square 5 x 5
var d3 = new Rectangle(4, 6);
Console.WriteLine($"{d1.Area}, {d2.Area}, {d3.Area}");

// ================= Types =================

class Account
{
    // Auto-property with PRIVATE setter: readable from outside, modifiable only inside.
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public Account(string owner, decimal initialBalance)
    {
        if (string.IsNullOrWhiteSpace(owner))
            throw new ArgumentException("Owner is required", nameof(owner));
        if (initialBalance < 0)
            throw new ArgumentOutOfRangeException(nameof(initialBalance));
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Must be positive");
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance) return false;
        Balance -= amount;
        return true;
    }

    public override string ToString() => $"{Owner}: {Balance:N2}";
}

class Person
{
    // FULL property: a private backing field + get/set logic
    private int _age;

    public string Name { get; set; } = "";

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentOutOfRangeException(nameof(value), "Age must be 0..150");
            _age = value;                    // 'value' is the implicit parameter holding the assigned value
        }
    }

    // Computed read-only property (no storage, calculated on demand)
    public string Summary => $"{Name}, {Age} years old";
}

class Point
{
    public double X { get; init; }
    public double Y { get; init; }
    public double DistanceFromOrigin => Math.Sqrt(X * X + Y * Y);
}

class Rectangle
{
    public double Width { get; }
    public double Height { get; }
    public double Area => Width * Height;

    // Constructors can call each other with ": this(...)" to avoid repeating code
    public Rectangle() : this(1, 1) { }
    public Rectangle(double side) : this(side, side) { }
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
}
