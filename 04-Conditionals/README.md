# Lesson 04 - Conditionals

## `if` / `else if` / `else`
Evaluates conditions top to bottom and runs the **first** block whose condition is `true`. The condition must be a `bool` (C# does not treat `0` or `null` as false like C/JS do).

## `switch` statement
Use when comparing one value to many constants. Each `case` must end with `break` (or `return`/`throw`). `default` handles the rest.

## `switch` expression
Shorter, returns a value, and the compiler warns if you forget a case. Supports relational patterns (`< 15`), `and`, `or`, `not`.

## Pattern matching cheat sheet
```csharp
obj is string s          // type pattern + capture
obj is null / is not null
x is > 5 and < 10        // relational + logical patterns
```

## Tips
- Always use `{ }` even for one-liners to avoid bugs when adding lines later.
- Put the most common/cheap condition first; `&&` stops early.
- Use `string.IsNullOrWhiteSpace(s)` for user text.

## Run it
```bash
dotnet run --project 04-Conditionals
```

## Exercises
1. Read a number and print "Positive", "Negative", or "Zero".
2. Write a leap-year check: divisible by 4 and (not by 100 or divisible by 400).
3. Use a switch expression to convert a month number (1-12) to its season name.

<details><summary>Solutions</summary>

```csharp
// 1
int n = int.Parse(Console.ReadLine()!);
Console.WriteLine(n > 0 ? "Positive" : n < 0 ? "Negative" : "Zero");

// 2
int year = 2024;
bool leap = year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);

// 3
int m = 7;
string season = m switch
{
    12 or 1 or 2 => "Winter",
    >= 3 and <= 5 => "Spring",
    >= 6 and <= 8 => "Summer",
    >= 9 and <= 11 => "Autumn",
    _ => "Invalid"
};
```
</details>
