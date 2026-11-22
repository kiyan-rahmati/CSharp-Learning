# C# Cheat Sheet

## Types
```csharp
int, long, double, decimal, bool, char, string, object, var
int? maybe = null;          // nullable value type
string? s = null;           // nullable reference type
const int Max = 10;
```

## Control flow
```csharp
if (a) { } else if (b) { } else { }
x = cond ? yes : no;
switch (v) { case 1: ...; break; default: ...; break; }
var r = v switch { 1 => "a", > 1 => "b", _ => "c" };
for (int i = 0; i < n; i++) { }
foreach (var item in items) { }
while (cond) { }  do { } while (cond);
break; continue; return;
```

## Methods
```csharp
int Add(int a, int b) => a + b;
void Log(string msg, int level = 1) { }
bool TryX(string s, out int n) { ... }
int Sum(params int[] xs) { ... }
```

## Classes
```csharp
public class Person : Base, IThing
{
    private readonly int _id;
    public string Name { get; set; } = "";
    public int Age { get; private set; }
    public Person(string name) { Name = name; }
    public virtual void Speak() { }
    public override string ToString() => Name;
    public static int Count;
}
public abstract class Shape { public abstract double Area(); }
public interface IThing { void Do(); }
public record Point(int X, int Y);
public enum Color { Red, Green }
public struct Pixel { public int R; }
```

## Collections
```csharp
int[] a = { 1, 2, 3 };           a.Length   a[^1]   a[0..2]
var list = new List<int>();      list.Add(1) list.Count list.Remove(1)
var dict = new Dictionary<string,int>(); dict["a"] = 1; dict.TryGetValue("a", out var v);
var set = new HashSet<int>();    var q = new Queue<int>();  var st = new Stack<int>();
```

## LINQ
```csharp
xs.Where(x => x > 1).Select(x => x * 2).OrderBy(x => x).ToList();
xs.Any(...) xs.All(...) xs.Count(...) xs.Sum() xs.Average() xs.Max() xs.First() xs.FirstOrDefault()
xs.GroupBy(x => x.Key)   xs.Distinct()   xs.Skip(10).Take(10)
```

## Strings
```csharp
$"Hello {name}"   s.Length  s.Trim()  s.Split(',')  string.Join(",", arr)
s.Contains("a")   s.Replace("a","b")  s.Substring(1,3)  string.IsNullOrWhiteSpace(s)
```

## Errors
```csharp
try { } catch (SpecificException ex) { } finally { }
throw new ArgumentException("msg");
using var file = File.OpenRead(path);
```

## Async
```csharp
async Task<string> GetAsync() { await Task.Delay(100); return "x"; }
var result = await GetAsync();
await Task.WhenAll(t1, t2);
```

## Null handling
```csharp
a?.B        // null-safe access
a ?? "x"    // fallback
a ??= "x"   // assign if null
a!          // I promise it's not null
```

## Naming conventions
- `PascalCase`: types, methods, properties, public members, constants
- `camelCase`: local variables, parameters
- `_camelCase`: private fields
- `IPascalCase`: interfaces
- `MethodAsync`: async methods
