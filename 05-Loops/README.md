# Lesson 05 - Loops

| Loop | When to use |
|---|---|
| `for` | known number of iterations / need the index |
| `while` | repeat until something happens (condition checked first) |
| `do-while` | must run at least once (e.g. a menu) |
| `foreach` | visit every element of a collection |

## Control keywords
- `break` exits the whole loop
- `continue` skips to the next iteration
- `return` leaves the method

## Common bugs
- **Infinite loop**: the condition never becomes false (forgot `i++`).
- **Off-by-one**: `<` vs `<=`, starting at 0 vs 1. Arrays are 0-based: valid indexes are `0 .. Length-1`.
- Modifying a collection inside `foreach` throws `InvalidOperationException`.

## Run it
```bash
dotnet run --project 05-Loops
```

## Exercises
1. Print the multiplication table of a number read from the user.
2. Compute the factorial of n with a loop.
3. FizzBuzz: for 1..30 print Fizz (multiple of 3), Buzz (of 5), FizzBuzz (both), otherwise the number.
4. Menu loop: show a menu with `do-while` until the user types `q`.

<details><summary>Solutions</summary>

```csharp
// 1
int n = 7;
for (int i = 1; i <= 10; i++) Console.WriteLine($"{n} x {i} = {n * i}");

// 2
long fact = 1;
for (int i = 2; i <= 10; i++) fact *= i;   // 3628800

// 3
for (int i = 1; i <= 30; i++)
{
    if (i % 15 == 0) Console.WriteLine("FizzBuzz");
    else if (i % 3 == 0) Console.WriteLine("Fizz");
    else if (i % 5 == 0) Console.WriteLine("Buzz");
    else Console.WriteLine(i);
}

// 4
string? choice;
do
{
    Console.Write("Command (q to quit): ");
    choice = Console.ReadLine();
} while (choice != "q");
```
</details>
