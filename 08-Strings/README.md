# Lesson 08 - Strings

## Key facts
- `string` = `System.String`, a reference type that is **immutable**.
- Compare with `==` (value comparison for strings) or `Equals(..., StringComparison.OrdinalIgnoreCase)` to ignore case.
- Use `StringBuilder` for building text in loops.

## Method cheat sheet
| Task | Method |
|---|---|
| Length | `s.Length` |
| Case | `ToUpper()`, `ToLower()` |
| Trim | `Trim()`, `TrimStart()`, `TrimEnd()` |
| Search | `Contains`, `StartsWith`, `EndsWith`, `IndexOf`, `LastIndexOf` |
| Slice | `Substring(start, len)`, `s[a..b]` |
| Replace | `Replace(old, new)` |
| Split/Join | `Split(',')`, `string.Join(", ", arr)` |
| Check | `IsNullOrEmpty`, `IsNullOrWhiteSpace` |
| Pad | `PadLeft`, `PadRight` |

## Format specifiers
`F2` fixed 2 decimals, `N0` thousands separators, `P1` percent, `C` currency, `D5` pad integer with zeros, `X` hex, date formats like `yyyy-MM-dd HH:mm`.

## Unicode note
`char` is one UTF-16 unit. Some characters (emoji, some Persian forms with combining marks) can span multiple chars, so `Length` may surprise you. Use `System.Globalization.StringInfo` when counting visible characters matters.

## Run it
```bash
dotnet run --project 08-Strings
```

## Exercises
1. Count the vowels in a sentence.
2. Convert `"hello world from csharp"` to Title Case (each word capitalized).
3. Check whether two words are anagrams.
4. Parse `"name=Kiyan;age=21"` into pieces using `Split`.

<details><summary>Solutions</summary>

```csharp
// 1
int vowels = 0;
foreach (char ch in "Programming in CSharp".ToLower())
    if ("aeiou".Contains(ch)) vowels++;

// 2
var words = "hello world from csharp".Split(' ');
for (int i = 0; i < words.Length; i++)
    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
Console.WriteLine(string.Join(" ", words));

// 3
bool Anagram(string x, string y) =>
    string.Concat(x.ToLower().OrderBy(c => c)) == string.Concat(y.ToLower().OrderBy(c => c));

// 4
foreach (var pair in "name=Kiyan;age=21".Split(';'))
{
    var kv = pair.Split('=');
    Console.WriteLine($"{kv[0]} -> {kv[1]}");
}
```
</details>
