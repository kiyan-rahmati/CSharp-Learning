using System.Text.Json;

namespace TodoApp;

/// <summary>Contract for storage. The rest of the app depends on THIS, not on JSON files.</summary>
public interface ITodoRepository
{
    List<TodoItem> Load();
    void Save(List<TodoItem> items);
}

/// <summary>Stores the list in a JSON file next to where you run the program.</summary>
public class JsonTodoRepository : ITodoRepository
{
    private readonly string _path;
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public JsonTodoRepository(string path) => _path = path;

    public List<TodoItem> Load()
    {
        if (!File.Exists(_path)) return new List<TodoItem>();
        try
        {
            string json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
        }
        catch (JsonException)
        {
            // A corrupted file should not crash the app.
            Console.WriteLine("Warning: todos file is corrupted, starting with an empty list.");
            return new List<TodoItem>();
        }
    }

    public void Save(List<TodoItem> items)
    {
        File.WriteAllText(_path, JsonSerializer.Serialize(items, Options));
    }
}
