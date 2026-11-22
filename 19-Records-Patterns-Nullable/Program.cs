// LESSON 19 - Modern C#: records, pattern matching, nullable reference types, and more

// ---------- record: an immutable data class with value-based equality ----------
var p1 = new Point(3, 4);
var p2 = new Point(3, 4);
Console.WriteLine(p1 == p2);             // True  (records compare by VALUES; classes compare by reference)
Console.WriteLine(p1);                   // Point { X = 3, Y = 4 }  (free ToString)

// 'with' makes a modified COPY (the original is never changed)
var p3 = p1 with { X = 10 };
Console.WriteLine($"{p1} -> {p3}");

// Deconstruction
var (x, y) = p1;
Console.WriteLine($"x={x}, y={y}");

// Records can have extra members and inheritance
var user = new User("kiyan", "kiyan@example.com");
Console.WriteLine(user.DisplayName);

// ---------- struct: a VALUE type for small data ----------
var c = new Coordinate { Lat = 37.5, Lng = 49.6 };
var c2 = c;                              // copied
c2.Lat = 0;
Console.WriteLine($"{c.Lat} vs {c2.Lat}");   // 37.5 vs 0

// ---------- enum: named constants ----------
OrderStatus status = OrderStatus.Shipped;
Console.WriteLine($"{status} = {(int)status}");
Console.WriteLine(Enum.Parse<OrderStatus>("Delivered"));
foreach (var s in Enum.GetValues<OrderStatus>()) Console.Write(s + " ");
Console.WriteLine();

// ---------- Pattern matching, advanced ----------
object[] things = { 42, "hello", 3.14, new Point(0, 0), new Point(5, 0), null!, new int[] { 1, 2, 3 } };
foreach (var thing in things)
    Console.WriteLine(Describe(thing));

// Property patterns
var order = new Order("A1", 150m, OrderStatus.Shipped);
if (order is { Total: > 100m, Status: OrderStatus.Shipped })
    Console.WriteLine("Big order already shipped");

// ---------- Nullable reference types (enabled in the .csproj) ----------
// string  = never null (compiler warns if you try)
// string? = may be null (compiler warns if you use it without checking)
string? maybe = GetNameOrNull(false);
// Console.WriteLine(maybe.Length);      // WARNING CS8602: possible null dereference
Console.WriteLine(maybe?.Length ?? 0);   // safe: ?. returns null if maybe is null, ?? gives 0
if (maybe is not null)
    Console.WriteLine(maybe.Length);     // compiler knows it's safe inside this block

string definitelyThere = maybe ?? "fallback";
Console.WriteLine(definitelyThere);
// The '!' operator ("trust me, it's not null") silences the warning; use it rarely.

// ---------- Nullable value types ----------
int? count = null;
Console.WriteLine(count.HasValue);
Console.WriteLine(count ?? -1);
count = 5;
Console.WriteLine(count.Value);

// ---------- Tuples ----------
(string Name, int Age) person = ("Ali", 25);
Console.WriteLine($"{person.Name} {person.Age}");

// ---------- Local helpers ----------
static string Describe(object? o) => o switch
{
    null => "null",
    int n when n > 40 => $"big int {n}",
    int n => $"int {n}",
    string s => $"string of length {s.Length}",
    double d => $"double {d:F1}",
    Point(0, 0) => "origin point",                    // positional pattern
    Point { Y: 0 } pt => $"point on X axis at {pt.X}",// property pattern
    int[] { Length: > 0 } arr => $"non-empty int array, first = {arr[0]}",
    _ => "something else"
};

static string? GetNameOrNull(bool found) => found ? "Kiyan" : null;

// ================= Types =================
record Point(int X, int Y);

record User(string Username, string Email)
{
    public string DisplayName => $"@{Username}";
}

struct Coordinate
{
    public double Lat { get; set; }
    public double Lng { get; set; }
}

enum OrderStatus { Pending = 1, Shipped = 2, Delivered = 3 }

record Order(string Id, decimal Total, OrderStatus Status);
