# Lesson 19 - Records, Patterns, Nullable

## `class` vs `record` vs `struct`
| | class | record (class) | struct |
|---|---|---|---|
| Kind | reference | reference | **value** |
| Equality | by reference | **by value** | by value (fields) |
| Immutability | optional | easy (`init`) | optional (`readonly struct`) |
| Copy with changes | manual | `with` | manual |
| Use for | behavior-rich objects | DTOs, messages, API models | small data (point, color) |

`record struct` also exists. A record is still a class under the hood; the compiler writes `Equals`, `GetHashCode`, `ToString`, `Deconstruct` for you.

## `enum`
Named integer constants. Use instead of "magic numbers". `[Flags]` enums combine values with `|`.

## Pattern matching summary
```csharp
o is int n                       // type pattern
o is { Total: > 100 }            // property pattern
o is Point(0, 0)                 // positional pattern
o is > 5 and < 10                // relational/logical
o switch { ... }                 // switch expression
list is [1, 2, ..]               // list pattern (C# 11)
```

## Nullable reference types (NRT)
Since C# 8 the compiler tracks null-ness when `<Nullable>enable</Nullable>`:
- `string` -> should never be null
- `string?` -> might be null; you must check
- Tools: `?.` (safe access), `??` (fallback), `??=` (assign if null), `is not null`, `!` (suppress).
- Turns `NullReferenceException` (the most common .NET bug) into compile-time warnings. Treat warnings seriously.

## Run it
```bash
dotnet run --project 19-Records-Patterns-Nullable
```

## Exercises
1. Define `record Money(decimal Amount, string Currency)` and show two equal values compare as equal.
2. Create an `enum Day` and a method `IsWeekend(Day d)` using a switch expression.
3. Write `string Classify(object o)` that returns "empty" for null or `""`, "number" for int/double, "text" for other strings.
4. Which line triggers a warning? `string a = null;` / `string? b = null;`

<details><summary>Solutions</summary>

```csharp
record Money(decimal Amount, string Currency);
// new Money(5, "USD") == new Money(5, "USD")  -> true

enum Day { Mon, Tue, Wed, Thu, Fri, Sat, Sun }
bool IsWeekend(Day d) => d is Day.Sat or Day.Sun;

string Classify(object? o) => o switch
{
    null or "" => "empty",
    int or double => "number",
    string => "text",
    _ => "other"
};

// 4) Only the first: a non-nullable string cannot hold null.
```
</details>
