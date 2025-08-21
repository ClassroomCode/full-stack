global using Todo.Entities;
using Microsoft.EntityFrameworkCore;
using Todo.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDb>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "TodoAPI";
    config.Title = "TodoAPI v1";
    config.Version = "v1";
});

var app = builder.Build();

app.UseOpenApi();

app.MapGet("/todoitems", async (TodoDb db) => await db.Todos.ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id) is TodoItem todo
        ? Results.Ok(todo)
        : Results.NotFound());

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var db = services.GetRequiredService<TodoDb>();
    db.Todos.Add(new TodoItem { Id = 1, Name = "One", IsComplete = false });
    db.Todos.Add(new TodoItem { Id = 2, Name = "Two", IsComplete = true });
    await db.SaveChangesAsync();
}

app.Run();