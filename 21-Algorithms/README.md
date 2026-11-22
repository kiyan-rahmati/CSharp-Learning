# Lesson 21 - Algorithms and Data Structures

## Big-O in plain words
How much *more work* does the program do when the input gets bigger?

| Notation | Name | Example | 1,000 items | 1,000,000 items |
|---|---|---|---|---|
| O(1) | constant | array index, dictionary lookup | 1 | 1 |
| O(log n) | logarithmic | binary search | 10 | 20 |
| O(n) | linear | single loop | 1,000 | 1,000,000 |
| O(n log n) | | merge/quick sort | 10,000 | 20,000,000 |
| O(n^2) | quadratic | nested loops, bubble sort | 1,000,000 | 10^12 |

## Sorting algorithms in this lesson
| Algorithm | Time (typical) | Idea |
|---|---|---|
| Bubble | O(n^2) | swap neighbours until sorted |
| Selection | O(n^2) | repeatedly pick the minimum |
| Insertion | O(n^2), O(n) if almost sorted | insert into the sorted left part |
| Merge | O(n log n) | divide, sort, merge |
| Quick | O(n log n) avg | partition around a pivot |

In real projects use `Array.Sort`, `List.Sort`, or LINQ `OrderBy`: they are heavily optimized. Learning the algorithms builds the *thinking skill* that interviews test.

## Searching
- **Linear**: works everywhere, O(n).
- **Binary**: needs sorted data, O(log n).
- Dictionary/HashSet lookups are O(1) on average, often the best fix for slow code.

## Data structures here
- **Linked list**: nodes pointing to the next node. Fast insert at the front (O(1)), slow random access (O(n)).
- **Graph + BFS**: a graph is nodes and edges. BFS uses a **queue** and finds the shortest path in an unweighted graph. (DFS uses a **stack**/recursion.)

## Techniques
- **Memoization / dynamic programming**: store sub-results (`Fib`).
- **Two pointers** (`IsPalindrome`) and **hash map trick** (`TwoSum`).
- **Recursion** with a base case.

## Run it
```bash
dotnet run --project 21-Algorithms
```
(The bubble sort timing takes a second or two on purpose, so you can feel O(n^2).)

## Exercises
1. Implement `int Max(int[] a)` and `int SecondLargest(int[] a)` in one pass.
2. Write a recursive binary search.
3. Detect duplicates in an array in O(n) using a `HashSet<int>`.
4. Implement a DFS on the graph using a `Stack<string>`.
5. Count how many times each word appears in a sentence and print the top 3.

<details><summary>Solutions</summary>

```csharp
// 1
int SecondLargest(int[] a)
{
    int first = int.MinValue, second = int.MinValue;
    foreach (int x in a)
    {
        if (x > first) { second = first; first = x; }
        else if (x > second && x < first) second = x;
    }
    return second;
}

// 2
int BinRec(int[] s, int t, int lo, int hi)
{
    if (lo > hi) return -1;
    int mid = lo + (hi - lo) / 2;
    if (s[mid] == t) return mid;
    return s[mid] < t ? BinRec(s, t, mid + 1, hi) : BinRec(s, t, lo, mid - 1);
}

// 3
bool HasDuplicates(int[] a)
{
    var seen = new HashSet<int>();
    foreach (int x in a) if (!seen.Add(x)) return true;
    return false;
}

// 4
List<string> Dfs(Dictionary<string, List<string>> g, string start)
{
    var visited = new HashSet<string>(); var order = new List<string>();
    var st = new Stack<string>(); st.Push(start);
    while (st.Count > 0)
    {
        var n = st.Pop();
        if (!visited.Add(n)) continue;
        order.Add(n);
        foreach (var next in Enumerable.Reverse(g[n])) st.Push(next);
    }
    return order;
}

// 5
"a b a c b a".Split(' ').GroupBy(w => w).OrderByDescending(g => g.Count()).Take(3)
    .ToList().ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()}"));
```
</details>
