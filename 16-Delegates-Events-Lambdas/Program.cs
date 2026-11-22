// LESSON 16 - Delegates, lambdas, and events
//
// DELEGATE: a type that represents a reference to a method (a "typed function pointer").
// It lets you pass behavior around as a value: store it, pass it to methods, call it later.

// ---------- Custom delegate type ----------
// "Any method that takes (int, int) and returns int"
Calculator op = Add;                         // point the delegate at the method Add
Console.WriteLine(op(3, 4));                 // 7
op = Multiply;                               // re-point it
Console.WriteLine(op(3, 4));                 // 12

// ---------- Built-in generic delegates (use these 99% of the time) ----------
// Func<T1, ..., TResult>  -> returns a value (LAST type parameter is the return type)
// Action<T1, ...>         -> returns nothing (void)
// Predicate<T>            -> returns bool (same as Func<T,bool>)
Func<int, int, int> subtract = (a, b) => a - b;      // lambda assigned to a Func
Action<string> greet = name => Console.WriteLine($"Hi {name}");
Func<int, bool> isEven = n => n % 2 == 0;

Console.WriteLine(subtract(10, 3));
greet("Kiyan");
Console.WriteLine(isEven(8));

// ---------- Passing behavior into methods ----------
var nums = new[] { 1, 2, 3, 4, 5, 6 };
Console.WriteLine(string.Join(", ", Filter(nums, n => n > 3)));          // 4, 5, 6
Console.WriteLine(string.Join(", ", Filter(nums, n => n % 2 == 0)));     // 2, 4, 6
// This is exactly how LINQ's Where works.

// ---------- Multicast delegates: one call, several methods ----------
Action log = null!;                          // null! tells the compiler "I'll assign it right away"
log += () => Console.WriteLine("Log to console");
log += () => Console.WriteLine("Log to file");
log();                                       // runs both, in order

// ---------- Closures: lambdas capture variables from the surrounding code ----------
int counter = 0;
Action increment = () => counter++;          // captures 'counter' (by reference, not by copy)
increment(); increment(); increment();
Console.WriteLine($"counter = {counter}");   // 3

// ---------- Events: the publisher/subscriber pattern ----------
// A publisher RAISES an event; any number of subscribers REACT. They don't know each other.
var button = new Button();
button.Clicked += (sender, e) => Console.WriteLine($"Handler 1: button clicked at {e.Time:T}");
button.Clicked += OnButtonClicked;           // can also subscribe a named method
button.Click();

button.Clicked -= OnButtonClicked;           // unsubscribe (prevents memory leaks in long-lived objects)
button.Click();

// ---------- A realistic example: progress reporting ----------
var downloader = new Downloader();
downloader.ProgressChanged += percent => Console.WriteLine($"Downloaded {percent}%");
downloader.Download();

// ================= Definitions =================

int Add(int a, int b) => a + b;
int Multiply(int a, int b) => a * b;

IEnumerable<int> Filter(IEnumerable<int> source, Func<int, bool> predicate)
{
    foreach (var item in source)
        if (predicate(item))
            yield return item;               // yield: produce items one at a time (lazy)
}

void OnButtonClicked(object? sender, ClickEventArgs e)
    => Console.WriteLine("Handler 2: named method");

delegate int Calculator(int a, int b);       // a custom delegate type

class ClickEventArgs : EventArgs
{
    public DateTime Time { get; } = DateTime.Now;
}

class Button
{
    // EventHandler<T> is the standard event signature: (object? sender, T args)
    public event EventHandler<ClickEventArgs>? Clicked;

    public void Click()
    {
        // ?.Invoke is the safe way to raise: does nothing if nobody subscribed
        Clicked?.Invoke(this, new ClickEventArgs());
    }
}

class Downloader
{
    public event Action<int>? ProgressChanged;

    public void Download()
    {
        for (int p = 25; p <= 100; p += 25)
            ProgressChanged?.Invoke(p);
    }
}
