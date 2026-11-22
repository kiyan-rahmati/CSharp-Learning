// LESSON 20 - Mini project: a console To-Do app
//
// It combines everything so far: classes, interfaces, collections, LINQ, exceptions, files + JSON.
//
// Architecture (a tiny version of "layered architecture"):
//   Program.cs         -> UI layer       (talks to the user)
//   TodoService.cs     -> logic layer    (rules)
//   TodoRepository.cs  -> data layer     (storage)
//   TodoItem.cs        -> model
// Each layer only knows the one below it. Swapping JSON for a database later means writing a new
// ITodoRepository, without touching the rest.

using TodoApp;

ITodoRepository repository = new JsonTodoRepository("todos.json");
var service = new TodoService(repository);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== TO-DO APP ===");
    Console.WriteLine("1) List   2) Add   3) Complete   4) Remove   0) Exit");
    Console.Write("Choose: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ShowList();
            break;

        case "2":
            Console.Write("Title: ");
            try
            {
                var created = service.Add(Console.ReadLine() ?? "");
                Console.WriteLine($"Added #{created.Id}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;

        case "3":
            if (TryReadId(out int doneId))
                Console.WriteLine(service.Complete(doneId) ? "Marked as done." : "No task with that id.");
            break;

        case "4":
            if (TryReadId(out int removeId))
                Console.WriteLine(service.Remove(removeId) ? "Removed." : "No task with that id.");
            break;

        case "0":
            Console.WriteLine("Bye!");
            return;                                // leaves the program

        default:
            Console.WriteLine("Unknown option.");
            break;
    }
}

void ShowList()
{
    var items = service.GetAll();
    if (items.Count == 0)
    {
        Console.WriteLine("(no tasks yet)");
        return;
    }

    foreach (var t in items.OrderBy(t => t.IsDone).ThenBy(t => t.Id))
    {
        string mark = t.IsDone ? "[x]" : "[ ]";
        Console.WriteLine($"{t.Id,3} {mark} {t.Title}  ({t.CreatedAt:yyyy-MM-dd})");
    }

    int done = items.Count(t => t.IsDone);
    Console.WriteLine($"{done}/{items.Count} completed");
}

bool TryReadId(out int id)
{
    Console.Write("Task id: ");
    if (int.TryParse(Console.ReadLine(), out id)) return true;
    Console.WriteLine("Please enter a number.");
    return false;
}
