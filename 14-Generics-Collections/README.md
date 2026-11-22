# Lesson 14 - Generics and Collections

## Generics
Without generics you either duplicate code per type or use `object` (unsafe, slow because of boxing). Generics give **type safety + reuse**.

```csharp
class Box<T> { public T Value; }
T Max<T>(T a, T b) where T : IComparable<T> { ... }
```
Common constraints: `where T : class`, `struct`, `new()`, `BaseClass`, `IInterface`.

## Choosing a collection
| Collection | Ordered? | Duplicates | Lookup | Typical use |
|---|---|---|---|---|
| `T[]` | by index | yes | index O(1) | fixed data |
| `List<T>` | by index | yes | index O(1), search O(n) | default list |
| `Dictionary<K,V>` | no guarantee | unique keys | key O(1) | find by key |
| `HashSet<T>` | no | **unique** | contains O(1) | remove duplicates, membership |
| `Queue<T>` | FIFO | yes | - | task queues, BFS |
| `Stack<T>` | LIFO | yes | - | undo, DFS, parsing |
| `LinkedList<T>` | sequence | yes | O(n) | frequent middle inserts |
| `SortedDictionary<K,V>` | sorted by key | unique keys | O(log n) | ordered keys |

O(1) = constant time, O(n) = grows with size. A dictionary finds a key without scanning everything because it uses hashing.

## Tips
- Keys of `Dictionary` / items of `HashSet` need proper `Equals` and `GetHashCode` (built-in types and `record`s already do).
- Prefer `TryGetValue` over `ContainsKey` + indexer (one lookup instead of two).
- Return `IEnumerable<T>` or `IReadOnlyList<T>` from methods to avoid exposing your internal list.
- Never modify a collection while enumerating it.

## Run it
```bash
dotnet run --project 14-Generics-Collections
```

## Exercises
1. Count how many times each character appears in a string using a `Dictionary<char,int>`.
2. Remove duplicates from `[1,2,2,3,3,3]` using `HashSet<int>`.
3. Check if brackets are balanced, e.g. `"{[()]}"` is valid and `"{[(])}"` is not (use a `Stack<char>`).
4. Write a generic `Pair<TFirst, TSecond>` class with a `Swap()` method returning `Pair<TSecond, TFirst>`.

<details><summary>Solutions</summary>

```csharp
// 1
var counts = new Dictionary<char, int>();
foreach (char c in "hello") counts[c] = counts.GetValueOrDefault(c) + 1;

// 2
var unique = new HashSet<int>(new[] { 1, 2, 2, 3, 3, 3 });

// 3
bool Balanced(string s)
{
    var st = new Stack<char>();
    foreach (char c in s)
    {
        if ("([{".Contains(c)) st.Push(c);
        else if (")]}".Contains(c))
        {
            if (st.Count == 0) return false;
            char open = st.Pop();
            if ("([{".IndexOf(open) != ")]}".IndexOf(c)) return false;
        }
    }
    return st.Count == 0;
}

// 4
class Pair<TFirst, TSecond>
{
    public TFirst First { get; }
    public TSecond Second { get; }
    public Pair(TFirst f, TSecond s) { First = f; Second = s; }
    public Pair<TSecond, TFirst> Swap() => new(Second, First);
}
```
</details>
