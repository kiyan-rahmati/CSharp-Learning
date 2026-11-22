# Lesson 06 - Arrays and Lists

## Arrays
- Fixed length decided at creation, all elements of one type, indexes start at **0**.
- `array.Length` gives the size. Valid index: `0 .. Length - 1`.
- Multi-dimensional `int[,]` (rectangular) and jagged `int[][]`.

## `List<T>`
- Resizable. Methods: `Add`, `AddRange`, `Insert`, `Remove`, `RemoveAt`, `RemoveAll`, `Contains`, `IndexOf`, `Sort`, `Reverse`, `Clear`.
- Property `Count` instead of `Length`.
- `T` is a *generic type parameter* (explained in Lesson 14).

## Which to use?
| Need | Choose |
|---|---|
| Size known and constant | array |
| Size changes | `List<T>` |
| Key lookup | `Dictionary` (Lesson 14) |

## Run it
```bash
dotnet run --project 06-Arrays-Lists
```

## Exercises
1. Create an array of 5 numbers, print their sum and average.
2. Find the largest number in an array *without* using `Max()`.
3. Use a `List<string>` as a to-do list: add 3 tasks, remove the second, print the rest numbered.
4. Reverse an array manually (swap first with last, etc.).

<details><summary>Solutions</summary>

```csharp
// 1
int[] a = { 4, 8, 15, 16, 23 };
int sum = 0; foreach (int x in a) sum += x;
Console.WriteLine($"{sum}, {(double)sum / a.Length}");

// 2
int max = a[0];
for (int i = 1; i < a.Length; i++) if (a[i] > max) max = a[i];

// 3
var todo = new List<string> { "Study", "Code", "Sleep" };
todo.RemoveAt(1);
for (int i = 0; i < todo.Count; i++) Console.WriteLine($"{i + 1}. {todo[i]}");

// 4
for (int i = 0; i < a.Length / 2; i++)
{
    (a[i], a[a.Length - 1 - i]) = (a[a.Length - 1 - i], a[i]);   // tuple swap
}
```
</details>
