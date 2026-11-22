# Lesson 20 - Mini Project: To-Do App

A complete console application that saves tasks to `todos.json`.

## Run it
```bash
cd 20-MiniProject-TodoApp
dotnet run
```
(Running from inside the folder makes `todos.json` appear there. Add it to `.gitignore` if you do not want it committed.)

## Features
- List, add, complete, and remove tasks
- Data persists between runs (JSON file)
- Validation and error handling

## What it demonstrates
| Concept | Where |
|---|---|
| Classes and properties | `TodoItem` |
| Interfaces and dependency injection (manual) | `ITodoRepository` -> `TodoService` |
| Collections + LINQ | `TodoService`, `ShowList` |
| Exceptions | empty title, corrupted JSON |
| File I/O + JSON | `JsonTodoRepository` |
| Separation of concerns | UI / logic / data in separate files |

## Challenges (extend it yourself!)
1. Add a **due date** and show overdue tasks in a different way.
2. Add **priorities** (`enum Priority { Low, Medium, High }`) and sort by priority.
3. Add **search** by keyword.
4. Add an **Edit title** option.
5. Write `InMemoryTodoRepository` (no file) and use it to prove the service works with any repository.
6. Write unit tests with xUnit (needs NuGet, so do this when online): test that `Add("")` throws and ids increase.

<details><summary>Hint for challenge 5</summary>

```csharp
public class InMemoryTodoRepository : ITodoRepository
{
    private List<TodoItem> _data = new();
    public List<TodoItem> Load() => _data.ToList();
    public void Save(List<TodoItem> items) => _data = items.ToList();
}
```
</details>
