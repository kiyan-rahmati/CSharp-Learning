# Lesson 03 - Operators and Type Conversion

## Operators at a glance
| Group | Operators |
|---|---|
| Arithmetic | `+ - * / %` |
| Increment | `++ --` |
| Assignment | `= += -= *= /= %= ??=` |
| Comparison | `== != < > <= >=` |
| Logical | `&& \|\| !` |
| Ternary | `cond ? a : b` |
| Null | `?? ??= ?.` |
| Bitwise | `& \| ^ ~ << >>` |

## Integer division trap
`7 / 2` is `3`, not `3.5`, because both operands are `int`. Make at least one operand `double` (`7 / 2.0` or `(double)7 / 2`).

## Precedence (high to low, simplified)
`()` -> `++ --` -> `* / %` -> `+ -` -> `< > <= >=` -> `== !=` -> `&&` -> `||` -> `?:` -> `=`.
When unsure, add parentheses.

## Conversions
- **Implicit**: safe, automatic (`int` -> `long` -> `double`).
- **Explicit (cast)**: may lose data, you must write it: `(int)3.9` gives `3`.
- **Parse / TryParse**: text -> number. Prefer `TryParse` for user input.
- **Convert.ToXxx** and `.ToString()`.

## Run it
```bash
dotnet run --project 03-Operators-Conversion
```

## Exercises
1. Convert 100 degrees Celsius to Fahrenheit (`F = C * 9 / 5 + 32`). Beware integer division!
2. Given `int total = 47;` print how many full dozens and how many leftover items there are.
3. Ask the user for a number with `TryParse` and print whether it is even or odd (use `%` and `?:`).

<details><summary>Solutions</summary>

```csharp
// 1
double c = 100;
double f = c * 9 / 5 + 32;   // 212

// 2
int total = 47;
Console.WriteLine($"{total / 12} dozens, {total % 12} left");  // 3 dozens, 11 left

// 3
Console.Write("Number: ");
if (int.TryParse(Console.ReadLine(), out int n))
    Console.WriteLine(n % 2 == 0 ? "Even" : "Odd");
else
    Console.WriteLine("Invalid input");
```
</details>
