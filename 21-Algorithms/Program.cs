// LESSON 21 - Algorithms and data structures (the fundamentals every developer should know)
//
// BIG-O NOTATION describes how the running time GROWS as the input size n grows:
//   O(1)        constant      array[index], dictionary lookup
//   O(log n)    logarithmic   binary search (halves the problem each step)
//   O(n)        linear        loop over all items
//   O(n log n)  linearithmic  good sorting (merge sort, quick sort)
//   O(n^2)      quadratic     nested loops (bubble sort)
// For n = 1,000,000: log n ~ 20 steps, n log n ~ 20 million, n^2 ~ one trillion.

using System.Diagnostics;

int[] data = { 64, 34, 25, 12, 22, 11, 90, 5 };

Console.WriteLine("Original:  " + string.Join(", ", data));
Console.WriteLine("Bubble:    " + string.Join(", ", BubbleSort((int[])data.Clone())));
Console.WriteLine("Selection: " + string.Join(", ", SelectionSort((int[])data.Clone())));
Console.WriteLine("Insertion: " + string.Join(", ", InsertionSort((int[])data.Clone())));
Console.WriteLine("Merge:     " + string.Join(", ", MergeSort((int[])data.Clone())));

int[] quick = (int[])data.Clone();
QuickSort(quick, 0, quick.Length - 1);
Console.WriteLine("Quick:     " + string.Join(", ", quick));

// ---------- Searching ----------
int[] sorted = (int[])data.Clone();
Array.Sort(sorted);
Console.WriteLine($"Linear search for 22 -> index {LinearSearch(data, 22)}");
Console.WriteLine($"Binary search for 22 in sorted array -> index {BinarySearch(sorted, 22)}");
Console.WriteLine($"Binary search for 100 -> index {BinarySearch(sorted, 100)}");   // -1 = not found

// ---------- Speed comparison ----------
var rng = new Random(42);                                  // fixed seed: same numbers each run
int[] big = Enumerable.Range(0, 20_000).Select(_ => rng.Next(1_000_000)).ToArray();

var sw = Stopwatch.StartNew();
BubbleSort((int[])big.Clone());
Console.WriteLine($"Bubble sort 20,000 items:   {sw.ElapsedMilliseconds} ms");

sw.Restart();
MergeSort((int[])big.Clone());
Console.WriteLine($"Merge sort 20,000 items:    {sw.ElapsedMilliseconds} ms");

sw.Restart();
Array.Sort((int[])big.Clone());
Console.WriteLine($"Array.Sort 20,000 items:    {sw.ElapsedMilliseconds} ms (built-in, highly optimized)");

// ---------- Linked list ----------
var list = new MyLinkedList<int>();
list.AddLast(1); list.AddLast(2); list.AddLast(3); list.AddFirst(0);
Console.WriteLine("Linked list: " + list);
list.Reverse();
Console.WriteLine("Reversed:    " + list);

// ---------- Graph traversal (BFS: breadth-first search) ----------
var graph = new Dictionary<string, List<string>>
{
    ["A"] = new() { "B", "C" },
    ["B"] = new() { "D" },
    ["C"] = new() { "D", "E" },
    ["D"] = new() { "F" },
    ["E"] = new() { "F" },
    ["F"] = new()
};
Console.WriteLine("BFS from A: " + string.Join(" -> ", Bfs(graph, "A")));
Console.WriteLine("Shortest path A to F: " + string.Join(" -> ", ShortestPath(graph, "A", "F")));

// ---------- Classic interview problems ----------
Console.WriteLine($"IsPalindrome(\"A man, a plan, a canal: Panama\") = {IsPalindrome("A man, a plan, a canal: Panama")}");
Console.WriteLine($"Two-sum of [2,7,11,15] target 9 -> {string.Join(",", TwoSum(new[] { 2, 7, 11, 15 }, 9))}");
Console.WriteLine($"Fibonacci(50) with memoization = {Fib(50, new Dictionary<int, long>())}");

// ================= Algorithms =================

// O(n^2): repeatedly swap neighbours that are out of order. Simple but slow.
static int[] BubbleSort(int[] a)
{
    for (int i = 0; i < a.Length - 1; i++)
    {
        bool swapped = false;
        for (int j = 0; j < a.Length - 1 - i; j++)
        {
            if (a[j] > a[j + 1])
            {
                (a[j], a[j + 1]) = (a[j + 1], a[j]);
                swapped = true;
            }
        }
        if (!swapped) break;               // already sorted: stop early
    }
    return a;
}

// O(n^2): find the minimum of the remaining part and put it in place.
static int[] SelectionSort(int[] a)
{
    for (int i = 0; i < a.Length - 1; i++)
    {
        int min = i;
        for (int j = i + 1; j < a.Length; j++)
            if (a[j] < a[min]) min = j;
        (a[i], a[min]) = (a[min], a[i]);
    }
    return a;
}

// O(n^2), but fast on nearly-sorted data: insert each item into the sorted part on its left.
static int[] InsertionSort(int[] a)
{
    for (int i = 1; i < a.Length; i++)
    {
        int key = a[i];
        int j = i - 1;
        while (j >= 0 && a[j] > key)
        {
            a[j + 1] = a[j];
            j--;
        }
        a[j + 1] = key;
    }
    return a;
}

// O(n log n): split in half, sort each half recursively, merge the two sorted halves.
static int[] MergeSort(int[] a)
{
    if (a.Length <= 1) return a;
    int mid = a.Length / 2;
    int[] left = MergeSort(a[..mid]);
    int[] right = MergeSort(a[mid..]);

    int[] result = new int[a.Length];
    int l = 0, r = 0, k = 0;
    while (l < left.Length && r < right.Length)
        result[k++] = left[l] <= right[r] ? left[l++] : right[r++];
    while (l < left.Length) result[k++] = left[l++];
    while (r < right.Length) result[k++] = right[r++];
    return result;
}

// O(n log n) average: pick a pivot, put smaller items left and larger right, recurse on both sides.
static void QuickSort(int[] a, int low, int high)
{
    if (low >= high) return;
    int pivot = a[high];
    int i = low - 1;
    for (int j = low; j < high; j++)
    {
        if (a[j] < pivot)
        {
            i++;
            (a[i], a[j]) = (a[j], a[i]);
        }
    }
    (a[i + 1], a[high]) = (a[high], a[i + 1]);
    int p = i + 1;                          // pivot is now in its final position
    QuickSort(a, low, p - 1);
    QuickSort(a, p + 1, high);
}

// O(n): works on any array.
static int LinearSearch(int[] a, int target)
{
    for (int i = 0; i < a.Length; i++)
        if (a[i] == target) return i;
    return -1;
}

// O(log n): requires a SORTED array. Compare with the middle, discard half each step.
static int BinarySearch(int[] sorted, int target)
{
    int low = 0, high = sorted.Length - 1;
    while (low <= high)
    {
        int mid = low + (high - low) / 2;   // avoids overflow of (low + high) / 2
        if (sorted[mid] == target) return mid;
        if (sorted[mid] < target) low = mid + 1;
        else high = mid - 1;
    }
    return -1;
}

// Breadth-first search: visit nodes level by level using a QUEUE.
static List<string> Bfs(Dictionary<string, List<string>> g, string start)
{
    var visited = new HashSet<string> { start };
    var queue = new Queue<string>();
    queue.Enqueue(start);
    var order = new List<string>();

    while (queue.Count > 0)
    {
        string node = queue.Dequeue();
        order.Add(node);
        foreach (string next in g[node])
            if (visited.Add(next))          // Add returns false if already present
                queue.Enqueue(next);
    }
    return order;
}

// BFS also finds the path with the FEWEST edges. We remember who discovered each node.
static List<string> ShortestPath(Dictionary<string, List<string>> g, string start, string goal)
{
    var cameFrom = new Dictionary<string, string?> { [start] = null };
    var queue = new Queue<string>();
    queue.Enqueue(start);

    while (queue.Count > 0)
    {
        string node = queue.Dequeue();
        if (node == goal) break;
        foreach (string next in g[node])
        {
            if (cameFrom.ContainsKey(next)) continue;
            cameFrom[next] = node;
            queue.Enqueue(next);
        }
    }

    var path = new List<string>();
    if (!cameFrom.ContainsKey(goal)) return path;
    for (string? cur = goal; cur != null; cur = cameFrom[cur])
        path.Add(cur);
    path.Reverse();
    return path;
}

static bool IsPalindrome(string s)
{
    var letters = s.Where(char.IsLetterOrDigit).Select(char.ToLower).ToArray();
    for (int i = 0, j = letters.Length - 1; i < j; i++, j--)
        if (letters[i] != letters[j]) return false;
    return true;
}

// O(n) using a dictionary instead of the O(n^2) double loop.
static int[] TwoSum(int[] nums, int target)
{
    var seen = new Dictionary<int, int>();   // value -> index
    for (int i = 0; i < nums.Length; i++)
    {
        int need = target - nums[i];
        if (seen.TryGetValue(need, out int j)) return new[] { j, i };
        seen[nums[i]] = i;
    }
    return Array.Empty<int>();
}

// Memoization: remember results so each value is computed only once -> O(n) instead of O(2^n).
static long Fib(int n, Dictionary<int, long> memo)
{
    if (n <= 1) return n;
    if (memo.TryGetValue(n, out long cached)) return cached;
    return memo[n] = Fib(n - 1, memo) + Fib(n - 2, memo);
}

// ================= Data structure: singly linked list =================
class Node<T>
{
    public T Value { get; }
    public Node<T>? Next { get; set; }
    public Node(T value) => Value = value;
}

class MyLinkedList<T>
{
    private Node<T>? _head;

    public void AddFirst(T value) => _head = new Node<T>(value) { Next = _head };

    public void AddLast(T value)
    {
        var node = new Node<T>(value);
        if (_head is null) { _head = node; return; }
        var cur = _head;
        while (cur.Next is not null) cur = cur.Next;   // walk to the end: O(n)
        cur.Next = node;
    }

    public void Reverse()
    {
        Node<T>? prev = null, cur = _head;
        while (cur is not null)
        {
            var next = cur.Next;      // remember the rest
            cur.Next = prev;          // flip the arrow
            prev = cur;
            cur = next;
        }
        _head = prev;
    }

    public override string ToString()
    {
        var parts = new List<string>();
        for (var cur = _head; cur is not null; cur = cur.Next)
            parts.Add(cur.Value?.ToString() ?? "null");
        return string.Join(" -> ", parts);
    }
}
