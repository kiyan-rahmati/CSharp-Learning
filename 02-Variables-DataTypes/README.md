# Lesson 02 - Variables and Data Types

## What you will learn
- Declaring variables, the built-in types, and when to use each
- `var`, `const`, default values
- Value types vs reference types
- Overflow

## Cheat sheet of built-in types

| Type | Size | Example | Use for |
|---|---|---|---|
| `byte` | 8 bit | `255` | raw data, small numbers |
| `short` | 16 bit | `-300` | rarely used |
| `int` | 32 bit | `42` | **default whole number** |
| `long` | 64 bit | `5L` | big numbers, IDs, timestamps |
| `float` | 32 bit | `3.14f` | graphics, games |
| `double` | 64 bit | `3.14` | **default decimal**, science |
| `decimal` | 128 bit | `9.99m` | **money** |
| `char` | 16 bit | `'A'` | a single character |
| `string` | varies | `"Hi"` | text (immutable) |
| `bool` | 1 bit logically | `true` | conditions |

## Declaring
```csharp
int age = 21;          // type name = value;
int x, y, z;           // several at once
int a = 1, b = 2;
var city = "Rasht";    // compiler infers string
```

## Value vs reference types
- **Value types** (numbers, bool, char, structs, enums): variable holds the data. Assigning copies it.
- **Reference types** (string, arrays, classes): variable holds an address. Assigning copies the address, so two variables can point to the same object.

`string` is a reference type but **immutable** and behaves like a value in practice: changing it creates a new string.

## Nullable
Reference types can be `null` (no object). Value types cannot, unless you add `?`:
```csharp
int? maybe = null;      // Nullable<int>
if (maybe.HasValue) Console.WriteLine(maybe.Value);
int safe = maybe ?? 0;  // 0 if null
```

## Run it
```bash
dotnet run --project 02-Variables-DataTypes
```

## Exercises
1. Declare variables for a product: name, price (money), quantity, in stock. Print them.
2. What is printed? `int a = 7; int b = a; a = 20; Console.WriteLine(b);`
3. Why should you not use `double` for money? Show with code.

<details><summary>Solutions</summary>

```csharp
// 1
string name = "Keyboard"; decimal price = 49.90m; int quantity = 3; bool inStock = true;
Console.WriteLine($"{name} - {price} - {quantity} - {inStock}");

// 2  -> 7 (b is an independent copy)

// 3
Console.WriteLine(0.1 + 0.2 == 0.3);    // False
Console.WriteLine(0.1m + 0.2m == 0.3m); // True
```
</details>
