// LESSON 14 - Generics and collections
//
// GENERICS let you write code once that works with ANY type while staying type-safe.
// <T> is a placeholder ("type parameter") replaced by a real type when you use it.

// ---------- Generic method ----------
Console.WriteLine(Max(3, 9));                // T inferred as int
Console.WriteLine(Max("apple", "pear"));     // T inferred as string
Console.WriteLine(Max(2.5, 1.5));

int p = 1, q = 2;
Swap(ref p, ref q);
Console.WriteLine($"{p},{q}");               // 2,1

// ---------- Generic class ----------
var box = new Box<int>(42);
var textBox = new Box<string>("hello");
Console.WriteLine($"{box.Value}, {textBox.Value}");

var stack = new SimpleStack<string>();
stack.Push("a"); stack.Push("b"); stack.Push("c");
Console.WriteLine(stack.Pop());              // c  (last in, first out)
Console.WriteLine(stack.Count);              // 2

// ---------- Dictionary<TKey, TValue>: fast lookup by key ----------
var capitals = new Dictionary<string, string>
{
    ["Iran"] = "Tehran",
    ["France"] = "Paris",
    ["Japan"] = "Tokyo"
};
capitals["Italy"] = "Rome";                  // add or overwrite
capitals.Add("Spain", "Madrid");             // throws if the key already exists

Console.WriteLine(capitals["Iran"]);
if (capitals.TryGetValue("Brazil", out string? city))   // safe lookup
    Console.WriteLine(city);
else
    Console.WriteLine("Brazil not found");

Console.WriteLine(capitals.ContainsKey("Japan"));
capitals.Remove("Japan");

foreach (KeyValuePair<string, string> kv in capitals)
    Console.WriteLine($"{kv.Key} -> {kv.Value}");

// Word-frequency counter: a classic dictionary use
var freq = new Dictionary<string, int>();
foreach (var w in "the cat and the dog and the bird".Split(' '))
{
    freq[w] = freq.GetValueOrDefault(w) + 1;
}
Console.WriteLine(string.Join(", ", freq.Select(x => $"{x.Key}:{x.Value}")));

// ---------- HashSet<T>: unique items, very fast Contains ----------
var tags = new HashSet<string> { "csharp", "dotnet", "csharp" };   // duplicate ignored
Console.WriteLine(tags.Count);               // 2
Console.WriteLine(tags.Add("web"));          // true  (added)
Console.WriteLine(tags.Add("web"));          // false (already there)

var setA = new HashSet<int> { 1, 2, 3, 4 };
var setB = new HashSet<int> { 3, 4, 5 };
setA.IntersectWith(setB);                    // set A becomes { 3, 4 }
Console.WriteLine(string.Join(",", setA));

// ---------- Queue<T>: FIFO (first in, first out) ----------
var queue = new Queue<string>();
queue.Enqueue("first"); queue.Enqueue("second");
Console.WriteLine(queue.Peek());             // look without removing
Console.WriteLine(queue.Dequeue());          // remove and return: "first"

// ---------- Stack<T>: LIFO (last in, first out) ----------
var history = new Stack<string>();
history.Push("page1"); history.Push("page2");
Console.WriteLine(history.Pop());            // page2 (like a browser's back button)

// ---------- Tuples & KeyValuePair as lightweight pairs ----------
var points = new List<(string Name, int Score)> { ("Ali", 90), ("Sara", 95) };
foreach (var (name, score) in points) Console.WriteLine($"{name}: {score}");

// ---------- Constraints: restrict what T can be ----------
Console.WriteLine(Largest(new List<int> { 4, 8, 2 }));   // works because int is IComparable<int>

// ================= Definitions =================

T Max<T>(T a, T b) where T : IComparable<T>      // constraint: T must be comparable
    => a.CompareTo(b) >= 0 ? a : b;

void Swap<T>(ref T x, ref T y)
{
    (x, y) = (y, x);
}

T Largest<T>(IEnumerable<T> items) where T : IComparable<T>
{
    T best = items.First();
    foreach (var item in items)
        if (item.CompareTo(best) > 0) best = item;
    return best;
}

class Box<T>
{
    public T Value { get; }
    public Box(T value) => Value = value;
}

class SimpleStack<T>
{
    private readonly List<T> _items = new();
    public int Count => _items.Count;

    public void Push(T item) => _items.Add(item);

    public T Pop()
    {
        if (_items.Count == 0) throw new InvalidOperationException("Stack is empty");
        T last = _items[^1];
        _items.RemoveAt(_items.Count - 1);
        return last;
    }
}
