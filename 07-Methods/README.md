# Lesson 07 - Methods

## Anatomy
```csharp
static int Add(int a, int b)   // returnType Name(parameters)
{
    return a + b;
}
```
- `void` = returns nothing.
- Parameters are inputs; arguments are the actual values you pass.
- Method names use **PascalCase**, parameters **camelCase**.

## Features
| Feature | Example |
|---|---|
| Optional parameter | `int Power(int b, int e = 2)` |
| Named argument | `Power(e: 3, b: 2)` |
| Overloading | `Describe(int)`, `Describe(string)` |
| `out` | `int.TryParse(s, out int n)` |
| `ref` | pass the variable itself, not a copy |
| `params` | `Sum(1, 2, 3)` |
| Tuples | `(int Min, int Max) MinMax(...)` |
| Expression-bodied | `int Square(int n) => n * n;` |

## Pass by value vs by reference
Value types are copied into the method. Use `ref`/`out` to let the method change the caller's variable. Reference types (arrays, classes) pass the *address* by value: the method can change the object's content, but not make the caller's variable point to another object (unless `ref`).

## Recursion
A method calling itself. Always define a **base case**; otherwise you get a `StackOverflowException`. Fibonacci above is simple but slow (exponential); loops or memoization are faster.

## Run it
```bash
dotnet run --project 07-Methods
```

## Exercises
1. Write `bool IsPrime(int n)`.
2. Write `double Average(params double[] values)`.
3. Write `string Reverse(string s)`.
4. Write a recursive `int Gcd(int a, int b)` (Euclid: `gcd(a, b) = gcd(b, a % b)`, `gcd(a, 0) = a`).

<details><summary>Solutions</summary>

```csharp
bool IsPrime(int n)
{
    if (n < 2) return false;
    for (int i = 2; i * i <= n; i++) if (n % i == 0) return false;
    return true;
}

double Average(params double[] v) => v.Length == 0 ? 0 : v.Sum() / v.Length;

string Reverse(string s)
{
    char[] chars = s.ToCharArray();
    Array.Reverse(chars);
    return new string(chars);
}

int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
```
</details>
