namespace TodoApp;

/// <summary>Business logic: the rules of the app. Knows nothing about the console or files.</summary>
public class TodoService
{
    private readonly ITodoRepository _repository;
    private readonly List<TodoItem> _items;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
        _items = _repository.Load();
    }

    public IReadOnlyList<TodoItem> GetAll() => _items;

    public TodoItem Add(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        int nextId = _items.Count == 0 ? 1 : _items.Max(t => t.Id) + 1;
        var item = new TodoItem { Id = nextId, Title = title.Trim() };
        _items.Add(item);
        _repository.Save(_items);
        return item;
    }

    public bool Complete(int id)
    {
        var item = _items.FirstOrDefault(t => t.Id == id);
        if (item is null) return false;
        item.IsDone = true;
        _repository.Save(_items);
        return true;
    }

    public bool Remove(int id)
    {
        var item = _items.FirstOrDefault(t => t.Id == id);
        if (item is null) return false;
        _items.Remove(item);
        _repository.Save(_items);
        return true;
    }
}
