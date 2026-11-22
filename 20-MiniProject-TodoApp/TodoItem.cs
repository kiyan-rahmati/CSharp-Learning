namespace TodoApp;

/// <summary>One task in the list. This is the "model": plain data, no logic about storage or UI.</summary>
public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
