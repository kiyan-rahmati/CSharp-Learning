// LESSON 12 - Interfaces and abstract classes
//
// INTERFACE: a pure CONTRACT. It says WHAT a type can do, not HOW. A class can implement many interfaces.
// ABSTRACT CLASS: a partially-built base class. It can contain real code AND abstract (unimplemented) members.
// You can never create an object directly from an interface or abstract class.

// ---------- Using interfaces ----------
// Code depends on the interface, not on a concrete class: easy to swap and to test.
INotifier email = new EmailNotifier();
INotifier sms = new SmsNotifier();

var service = new OrderService(email);
service.PlaceOrder("Laptop");

service = new OrderService(sms);         // same service, different behavior
service.PlaceOrder("Phone");

// ---------- Multiple interfaces ----------
var duck = new Duck();
duck.Fly();
duck.Swim();
IFlyable f = duck;                       // the same object seen through one interface
f.Fly();

// ---------- Abstract class ----------
BankAccount[] accounts = { new SavingsAccount(1000m), new CheckingAccount(500m) };
foreach (var acc in accounts)
{
    acc.Withdraw(600m);                  // each type enforces its own rule
    Console.WriteLine(acc.Summary());
}

// ---------- Common built-in interfaces ----------
var people = new List<Person> { new("Zara", 30), new("Ali", 25), new("Mina", 28) };
people.Sort();                           // works because Person implements IComparable<Person>
foreach (var p in people) Console.WriteLine(p);

// IDisposable + 'using' guarantees cleanup even when exceptions happen
using (var res = new Resource("DB connection"))
{
    Console.WriteLine("Working with the resource...");
}   // Dispose() is called automatically here

// ================= Types =================

interface INotifier
{
    void Send(string message);           // no body, no access modifier (public by default)
}

class EmailNotifier : INotifier
{
    public void Send(string message) => Console.WriteLine($"[Email] {message}");
}

class SmsNotifier : INotifier
{
    public void Send(string message) => Console.WriteLine($"[SMS] {message}");
}

class OrderService
{
    private readonly INotifier _notifier;    // depends on the abstraction (Dependency Injection idea)

    public OrderService(INotifier notifier) => _notifier = notifier;

    public void PlaceOrder(string item) => _notifier.Send($"Order placed: {item}");
}

interface IFlyable { void Fly(); }
interface ISwimmable { void Swim(); }

class Duck : IFlyable, ISwimmable            // implements two interfaces
{
    public void Fly() => Console.WriteLine("Duck flies.");
    public void Swim() => Console.WriteLine("Duck swims.");
}

abstract class BankAccount
{
    public decimal Balance { get; protected set; }   // protected: children can change it

    protected BankAccount(decimal balance) => Balance = balance;

    // Abstract: NO body here; every child MUST implement it.
    public abstract bool Withdraw(decimal amount);

    // Concrete: shared code reused by all children
    public string Summary() => $"{GetType().Name}: balance {Balance}";
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(decimal balance) : base(balance) { }

    public override bool Withdraw(decimal amount)
    {
        if (amount > Balance) return false;           // cannot go negative
        Balance -= amount;
        return true;
    }
}

class CheckingAccount : BankAccount
{
    private const decimal OverdraftLimit = 200m;

    public CheckingAccount(decimal balance) : base(balance) { }

    public override bool Withdraw(decimal amount)
    {
        if (amount > Balance + OverdraftLimit) return false;   // may go slightly negative
        Balance -= amount;
        return true;
    }
}

class Person : IComparable<Person>
{
    public string Name { get; }
    public int Age { get; }
    public Person(string name, int age) { Name = name; Age = age; }

    // Negative: this < other, 0: equal, positive: this > other
    public int CompareTo(Person? other) => other is null ? 1 : Age.CompareTo(other.Age);

    public override string ToString() => $"{Name} ({Age})";
}

class Resource : IDisposable
{
    private readonly string _name;
    public Resource(string name) { _name = name; Console.WriteLine($"Opened {_name}"); }
    public void Dispose() => Console.WriteLine($"Closed {_name}");
}
