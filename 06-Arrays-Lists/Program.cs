// LESSON 06 - Arrays and Lists

// ---------- Arrays: FIXED size, same type, 0-based index ----------
int[] numbers = new int[5];              // five ints, all start as 0
numbers[0] = 10;
numbers[1] = 20;
Console.WriteLine(numbers[0]);           // 10
Console.WriteLine(numbers.Length);       // 5

int[] primes = { 2, 3, 5, 7, 11 };       // initializer shorthand
string[] names = new[] { "Ali", "Sara", "Reza" };

// Iterating
for (int i = 0; i < primes.Length; i++)
    Console.WriteLine($"primes[{i}] = {primes[i]}");

foreach (var n in names)
    Console.WriteLine(n);

// Accessing outside the range throws IndexOutOfRangeException:
// Console.WriteLine(primes[5]);         // valid indexes are 0..4

// Index-from-end and ranges (C# 8+)
Console.WriteLine(primes[^1]);           // last element: 11
int[] firstThree = primes[0..3];         // elements at index 0,1,2 -> { 2, 3, 5 }
Console.WriteLine(string.Join(", ", firstThree));

// Useful static helpers
int[] data = { 5, 2, 9, 1 };
Array.Sort(data);                        // sorts in place -> 1, 2, 5, 9
Array.Reverse(data);                     // 9, 5, 2, 1
Console.WriteLine(string.Join(", ", data));
Console.WriteLine(Array.IndexOf(data, 5));   // 1 (or -1 if not found)

// 2D (rectangular) array
int[,] grid = new int[2, 3]
{
    { 1, 2, 3 },
    { 4, 5, 6 }
};
Console.WriteLine(grid[1, 2]);           // 6
Console.WriteLine(grid.GetLength(0));    // 2 rows

// Jagged array: an array of arrays with different lengths
int[][] jagged = new int[2][];
jagged[0] = new[] { 1 };
jagged[1] = new[] { 2, 3, 4 };
Console.WriteLine(jagged[1][2]);         // 4

// ---------- List<T>: a RESIZABLE collection ----------
List<string> fruits = new List<string>();
fruits.Add("Apple");
fruits.Add("Banana");
fruits.AddRange(new[] { "Cherry", "Mango" });
fruits.Insert(1, "Orange");              // insert at index 1
Console.WriteLine(fruits.Count);         // number of items (Count, not Length)
Console.WriteLine(fruits[0]);

fruits.Remove("Banana");                 // remove first match
fruits.RemoveAt(0);                      // remove by index
Console.WriteLine(fruits.Contains("Mango"));     // true
Console.WriteLine(fruits.IndexOf("Mango"));

fruits.Sort();                           // alphabetical
Console.WriteLine(string.Join(" | ", fruits));

var scores = new List<int> { 70, 95, 82 };   // collection initializer
scores.Add(60);
Console.WriteLine($"Max={scores.Max()}, Min={scores.Min()}, Avg={scores.Average()}"); // LINQ (Lesson 15)

// Never add/remove inside foreach over the same list (InvalidOperationException).
// Use a for loop going backwards, or RemoveAll:
scores.RemoveAll(s => s < 65);           // lambda: remove every score below 65
Console.WriteLine(string.Join(", ", scores));

// Array vs List:
// Array  -> fixed size, slightly faster, good for known-size data
// List<T>-> dynamic size, the everyday choice
