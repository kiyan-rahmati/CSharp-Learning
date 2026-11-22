// LESSON 22 - Your first Web API with ASP.NET Core (Minimal API)
//
// Everything here ships inside the .NET SDK, so it works fully OFFLINE.
//
// HOW THE WEB WORKS (quick recap):
//   Client (browser, mobile app, React app) --HTTP request--> Server (this program) --HTTP response--> Client
//   A request has: METHOD (GET/POST/PUT/DELETE), URL, headers, optional BODY (JSON).
//   A response has: STATUS CODE (200 OK, 201 Created, 400 Bad Request, 404 Not Found, 500 Server Error), headers, body.
//
// REST conventions used below:
//   GET    /api/todos        -> list all
//   GET    /api/todos/5      -> get one
//   POST   /api/todos        -> create
//   PUT    /api/todos/5      -> replace/update
//   DELETE /api/todos/5      -> delete

var builder = WebApplication.CreateBuilder(args);

// ---------- Dependency Injection (DI) container ----------
// Register services here. ASP.NET Core creates them and passes them to whoever asks.
// AddSingleton = one instance for the whole app lifetime (fine for our in-memory store).
// AddScoped    = one instance per HTTP request (typical for database contexts).
// AddTransient = a new instance every time it is requested.
builder.Services.AddSingleton<ITodoStore, InMemoryTodoStore>();

var app = builder.Build();

// ---------- Middleware: a pipeline that every request passes through ----------
// Order matters. This one logs each request, then calls the next step.
app.Use(async (context, next) =>
{
    var started = DateTime.Now;
    await next();                                          // run the rest of the pipeline (endpoint)
    var ms = (DateTime.Now - started).TotalMilliseconds;
    Console.WriteLine($"{context.Request.Method} {context.Request.Path} -> {context.Response.StatusCode} ({ms:F0} ms)");
});

// ---------- Endpoints ----------
app.MapGet("/", () => "Todo API is running. Try GET /api/todos");

// MapGroup shares the URL prefix between endpoints.
var todos = app.MapGroup("/api/todos");

// Parameters are filled automatically: 'store' from DI, 'id' from the URL, 'dto' from the JSON body.
todos.MapGet("/", (ITodoStore store) => Results.Ok(store.GetAll()));

todos.MapGet("/{id:int}", (int id, ITodoStore store) =>
    store.Get(id) is { } todo ? Results.Ok(todo) : Results.NotFound(new { error = $"Todo {id} not found" }));

todos.MapPost("/", (CreateTodoRequest dto, ITodoStore store) =>
{
    if (string.IsNullOrWhiteSpace(dto.Title))
        return Results.BadRequest(new { error = "Title is required" });

    var created = store.Add(dto.Title.Trim());
    return Results.Created($"/api/todos/{created.Id}", created);   // 201 + Location header
});

todos.MapPut("/{id:int}", (int id, UpdateTodoRequest dto, ITodoStore store) =>
{
    if (string.IsNullOrWhiteSpace(dto.Title))
        return Results.BadRequest(new { error = "Title is required" });

    var updated = store.Update(id, dto.Title.Trim(), dto.IsDone);
    return updated is null ? Results.NotFound() : Results.Ok(updated);
});

todos.MapDelete("/{id:int}", (int id, ITodoStore store) =>
    store.Delete(id) ? Results.NoContent() : Results.NotFound());      // 204 on success

// ---------- Simple global error handling ----------
// (In real projects use app.UseExceptionHandler and ProblemDetails.)

app.Run("http://localhost:5000");

// ================= Models (DTOs) =================
// DTO = Data Transfer Object: the shape of data going in/out of the API.
record Todo(int Id, string Title, bool IsDone);
record CreateTodoRequest(string Title);
record UpdateTodoRequest(string Title, bool IsDone);

// ================= Service =================
interface ITodoStore
{
    IReadOnlyList<Todo> GetAll();
    Todo? Get(int id);
    Todo Add(string title);
    Todo? Update(int id, string title, bool isDone);
    bool Delete(int id);
}

class InMemoryTodoStore : ITodoStore
{
    private readonly List<Todo> _items = new()
    {
        new Todo(1, "Learn C#", true),
        new Todo(2, "Build a Web API", false)
    };
    private int _nextId = 3;
    private readonly object _lock = new();       // web servers handle requests on many threads at once

    public IReadOnlyList<Todo> GetAll()
    {
        lock (_lock) return _items.ToList();
    }

    public Todo? Get(int id)
    {
        lock (_lock) return _items.FirstOrDefault(t => t.Id == id);
    }

    public Todo Add(string title)
    {
        lock (_lock)
        {
            var todo = new Todo(_nextId++, title, false);
            _items.Add(todo);
            return todo;
        }
    }

    public Todo? Update(int id, string title, bool isDone)
    {
        lock (_lock)
        {
            int index = _items.FindIndex(t => t.Id == id);
            if (index < 0) return null;
            _items[index] = _items[index] with { Title = title, IsDone = isDone };
            return _items[index];
        }
    }

    public bool Delete(int id)
    {
        lock (_lock) return _items.RemoveAll(t => t.Id == id) > 0;
    }
}
