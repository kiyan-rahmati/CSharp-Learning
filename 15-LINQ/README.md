# Lesson 15 - LINQ

## Mental model
A LINQ query is a **pipeline**: source -> filter -> transform -> sort -> consume.

```csharp
students.Where(s => s.Grade >= 15)      // keep
        .OrderByDescending(s => s.Grade)// sort
        .Select(s => s.Name)            // shape
        .ToList();                      // run it
```

## Cheat sheet
| Goal | Method |
|---|---|
| Filter | `Where` |
| Transform | `Select`, `SelectMany` (flatten) |
| Sort | `OrderBy`, `ThenBy`, `OrderByDescending` |
| Group | `GroupBy` |
| Aggregate | `Count`, `Sum`, `Average`, `Min`, `Max`, `Aggregate` |
| One element | `First`, `FirstOrDefault`, `Single`, `Last`, `ElementAt` |
| Test | `Any`, `All`, `Contains` |
| Sets | `Distinct`, `Union`, `Intersect`, `Except` |
| Paging | `Skip`, `Take` |
| Combine | `Join`, `Zip`, `Concat` |
| Convert | `ToList`, `ToArray`, `ToDictionary`, `ToHashSet` |

## `First` vs `FirstOrDefault` vs `Single`
- `First` throws if empty. `FirstOrDefault` returns `default` (null/0).
- `Single` expects **exactly one** match, else throws.

## Lambdas
`x => x * 2` means "given x, return x * 2". `(a, b) => a + b` for two parameters. You will see them everywhere in modern C#.

## Deferred execution
Queries run when enumerated. Call `ToList()` when you need a snapshot or want to avoid running the query several times (important with databases).

## Performance tip
`list.Count()` on a `List` is optimized, but `Where(...).Count()` loops. Use `Any()` instead of `Count() > 0`.

## `record`
Used here for short data classes (see Lesson 19).

## Run it
```bash
dotnet run --project 15-LINQ
```

## Exercises
Use `var nums = Enumerable.Range(1, 20);`
1. Sum of the squares of the even numbers.
2. The three largest numbers, descending.
3. Given words `{"apple","banana","avocado","cherry","blueberry"}`, group them by first letter and print `letter: count`.
4. Using the `students` list from the demo: name of the student with the highest grade in each course.

<details><summary>Solutions</summary>

```csharp
// 1
nums.Where(n => n % 2 == 0).Select(n => n * n).Sum();
// 2
nums.OrderByDescending(n => n).Take(3);
// 3
foreach (var g in words.GroupBy(w => w[0])) Console.WriteLine($"{g.Key}: {g.Count()}");
// 4
students.GroupBy(s => s.Course)
        .Select(g => g.OrderByDescending(s => s.Grade).First().Name);
```
</details>
