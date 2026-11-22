# Lesson 22 - Web API with ASP.NET Core

## Run it
```bash
dotnet run --project 22-WebApi-Minimal
```
Then open `http://localhost:5000/api/todos` in your browser (GET requests), or use curl:

```bash
curl http://localhost:5000/api/todos
curl http://localhost:5000/api/todos/1
curl -X POST http://localhost:5000/api/todos -H "Content-Type: application/json" -d '{"title":"New task"}'
curl -X PUT  http://localhost:5000/api/todos/2 -H "Content-Type: application/json" -d '{"title":"Build a Web API","isDone":true}'
curl -X DELETE http://localhost:5000/api/todos/1
```
Stop the server with `Ctrl + C`. If port 5000 is busy, change it in `app.Run(...)`.

## Concepts
**HTTP methods**: GET (read), POST (create), PUT (replace), PATCH (partial update), DELETE (remove).

**Status codes**: 200 OK, 201 Created, 204 No Content, 400 Bad Request (client error), 401 Unauthorized (not logged in), 403 Forbidden (not allowed), 404 Not Found, 409 Conflict, 500 Server Error.

**Minimal API vs Controllers**: two styles in ASP.NET Core. Minimal APIs (this lesson) are compact. Controllers (`[ApiController]` classes) are common in larger/older projects. Both use the same pipeline.

**Middleware**: components in a pipeline that run before/after endpoints: logging, authentication, CORS, error handling, static files.

**Dependency Injection**: you declare what you need in a constructor/parameter; the framework supplies it. Makes code testable (Lesson 12's `INotifier` idea, automated).

**DTOs**: separate API shapes from internal/database entities, so you can change one without breaking the other.

**JSON**: serialization is automatic; property names become camelCase.

## What to learn next (needs internet/NuGet, so do it when online)
1. **Entity Framework Core** + SQLite/PostgreSQL for a real database (`dotnet add package Microsoft.EntityFrameworkCore.Sqlite`).
2. **Authentication**: JWT bearer tokens, ASP.NET Core Identity.
3. **Validation**: FluentValidation or data annotations.
4. **OpenAPI/Swagger** documentation (`Swashbuckle.AspNetCore` or `Microsoft.AspNetCore.OpenApi`).
5. **Testing**: xUnit + `WebApplicationFactory`.
6. **Deployment**: Docker, a Linux VPS, or a cloud host.
7. Connect a **React** frontend: enable CORS with `builder.Services.AddCors(...)` and call the API with `fetch`.

## Exercises
1. Add a `GET /api/todos?done=true` filter (use a `bool? done` parameter and LINQ).
2. Add `PATCH /api/todos/{id}/complete` that only marks the task done.
3. Add a second resource, `/api/notes`, with its own store registered in DI.
4. Persist the todos to a JSON file (reuse Lesson 18) instead of memory.
5. Return `409 Conflict` when creating a todo whose title already exists.

<details><summary>Hints</summary>

```csharp
// 1
todos.MapGet("/", (bool? done, ITodoStore store) =>
    Results.Ok(done is null ? store.GetAll() : store.GetAll().Where(t => t.IsDone == done)));

// 2
todos.MapPatch("/{id:int}/complete", (int id, ITodoStore store) =>
{
    var t = store.Get(id);
    return t is null ? Results.NotFound() : Results.Ok(store.Update(id, t.Title, true));
});
```
</details>
