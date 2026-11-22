// LESSON 18 - Files, directories, and JSON (fully offline)
//
// Namespaces used (all included in .NET, no packages needed):
//   System.IO            -> File, Directory, Path
//   System.Text.Json     -> JsonSerializer

using System.Text.Json;

// All demo files go into a temp folder so we never touch your real data.
string folder = Path.Combine(Path.GetTempPath(), "csharp-learning-demo");
Directory.CreateDirectory(folder);                          // does nothing if it already exists
Console.WriteLine($"Working folder: {folder}");

// ALWAYS build paths with Path.Combine (handles / vs \ for Windows, Linux, macOS).
string textFile = Path.Combine(folder, "notes.txt");

// ---------- Write text ----------
File.WriteAllText(textFile, "First line\nSecond line\n");          // creates or OVERWRITES
File.AppendAllText(textFile, "Third line\n");                      // adds to the end
File.WriteAllLines(Path.Combine(folder, "list.txt"), new[] { "a", "b", "c" });

// ---------- Read text ----------
string all = File.ReadAllText(textFile);
Console.WriteLine(all);
string[] lines = File.ReadAllLines(textFile);
Console.WriteLine($"Line count: {lines.Length}");

// For HUGE files stream line by line instead of loading everything into memory:
foreach (string line in File.ReadLines(textFile))
    Console.WriteLine($"> {line}");

// ---------- Existence checks ----------
Console.WriteLine(File.Exists(textFile));
Console.WriteLine(Directory.Exists(folder));

// ---------- StreamWriter / StreamReader with 'using' ----------
using (var writer = new StreamWriter(Path.Combine(folder, "log.txt")))
{
    writer.WriteLine("Started");
    writer.WriteLine($"Time: {DateTime.Now:HH:mm:ss}");
}   // closing the writer flushes data to disk

using (var reader = new StreamReader(Path.Combine(folder, "log.txt")))
{
    string? line;
    while ((line = reader.ReadLine()) != null)
        Console.WriteLine($"log: {line}");
}

// ---------- Path helpers ----------
Console.WriteLine(Path.GetFileName(textFile));                 // notes.txt
Console.WriteLine(Path.GetFileNameWithoutExtension(textFile)); // notes
Console.WriteLine(Path.GetExtension(textFile));                // .txt

// ---------- Directory listing ----------
foreach (string file in Directory.GetFiles(folder, "*.txt"))
    Console.WriteLine($"found {Path.GetFileName(file)}");

// ---------- JSON: serialize (object -> text) ----------
var people = new List<Person>
{
    new() { Name = "Ali", Age = 25, Skills = new() { "C#", "SQL" } },
    new() { Name = "Sara", Age = 30, Skills = new() { "React" } }
};

var options = new JsonSerializerOptions
{
    WriteIndented = true,                                     // pretty print
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase         // Name -> "name"
};

string json = JsonSerializer.Serialize(people, options);
Console.WriteLine(json);

string jsonFile = Path.Combine(folder, "people.json");
File.WriteAllText(jsonFile, json);

// ---------- JSON: deserialize (text -> object) ----------
string loaded = File.ReadAllText(jsonFile);
List<Person>? back = JsonSerializer.Deserialize<List<Person>>(loaded, options);
Console.WriteLine($"Loaded {back?.Count} people. First: {back?[0].Name}, skills: {string.Join("/", back![0].Skills)}");

// ---------- Handling bad JSON ----------
try
{
    JsonSerializer.Deserialize<Person>("{ this is not json }");
}
catch (JsonException ex)
{
    Console.WriteLine($"Invalid JSON: {ex.Message}");
}

// ---------- Reading JSON without a class: JsonDocument ----------
using JsonDocument doc = JsonDocument.Parse("""{"city":"Rasht","temp":18}""");
string city = doc.RootElement.GetProperty("city").GetString()!;
int temp = doc.RootElement.GetProperty("temp").GetInt32();
Console.WriteLine($"{city}: {temp} degrees");

// ---------- Cleanup ----------
Directory.Delete(folder, recursive: true);
Console.WriteLine("Demo folder deleted.");

// ================= Types =================
class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public List<string> Skills { get; set; } = new();
}
