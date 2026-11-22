# Lesson 18 - Files and JSON

## `System.IO` essentials
| Task | API |
|---|---|
| Read all text | `File.ReadAllText(path)` |
| Write/overwrite | `File.WriteAllText(path, text)` |
| Append | `File.AppendAllText(path, text)` |
| Lines | `File.ReadAllLines`, `File.ReadLines` (lazy), `File.WriteAllLines` |
| Exists | `File.Exists`, `Directory.Exists` |
| Create folder | `Directory.CreateDirectory` |
| List | `Directory.GetFiles(path, "*.txt")` |
| Copy/move/delete | `File.Copy`, `File.Move`, `File.Delete` |
| Paths | `Path.Combine`, `GetFileName`, `GetExtension` |

Async versions: `File.ReadAllTextAsync`, `WriteAllTextAsync` (Lesson 17).

## Streams
`StreamReader` / `StreamWriter` read and write progressively. Always wrap in `using` so the file handle is released.

## Common file exceptions
`FileNotFoundException`, `DirectoryNotFoundException`, `UnauthorizedAccessException`, `IOException` (file in use).

## JSON
JSON = text format for structured data: objects `{}`, arrays `[]`, strings, numbers, booleans, null.

`System.Text.Json` is built-in and fast:
```csharp
string json = JsonSerializer.Serialize(obj);
T? obj = JsonSerializer.Deserialize<T>(json);
```
- Properties must be public with getters/setters.
- Customize with `JsonSerializerOptions` or attributes: `[JsonPropertyName("full_name")]`, `[JsonIgnore]`.
- Use `JsonDocument` for quick, class-less reading.

## Security note
Never trust paths from users: `Path.Combine(root, userInput)` with `../` can escape the folder (path traversal). Validate with `Path.GetFullPath` and check it starts with your root.

## Run it
```bash
dotnet run --project 18-Files-JSON
```

## Exercises
1. Build a notes app: append a line with a timestamp to `notes.txt` each run and print all notes.
2. Save a `List<Product>` to `products.json` and load it back; if the file does not exist return an empty list.
3. Count how many words are in a text file.
4. Copy every `.txt` file of a folder into a backup folder.

<details><summary>Solutions</summary>

```csharp
// 1
File.AppendAllText("notes.txt", $"{DateTime.Now:s} - hello{Environment.NewLine}");
Console.WriteLine(File.ReadAllText("notes.txt"));

// 2
List<Product> Load(string path) =>
    File.Exists(path)
        ? JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(path)) ?? new()
        : new();

// 3
int words = File.ReadAllText("notes.txt")
                .Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).Length;

// 4
Directory.CreateDirectory("backup");
foreach (var f in Directory.GetFiles(".", "*.txt"))
    File.Copy(f, Path.Combine("backup", Path.GetFileName(f)), overwrite: true);
```
</details>
