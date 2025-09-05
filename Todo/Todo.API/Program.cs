global using Todo.Entities;
using Microsoft.EntityFrameworkCore;
using Todo.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITodoDb>(_ => TodoDbFactory.Create());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "TodoAPI";
    config.Title = "TodoAPI v1";
    config.Version = "v1";
});

var app = builder.Build();

app.UseOpenApi();

app.MapGet("/todoitems", async (ITodoDb db) => await db.GetAllTodos());

app.MapGet("/todoitems/{id}", async (int id, ITodoDb db) =>
    await db.GetTodo(id) is TodoItem todo
        ? Results.Ok(todo)
        : Results.NotFound());

/*
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var db = services.GetRequiredService<TodoDb>();
    db.Todos.Add(new TodoItem { Id = 1, Name = "One", IsComplete = false });
    db.Todos.Add(new TodoItem { Id = 2, Name = "Two", IsComplete = true });
    await db.SaveChangesAsync();
}
*/

app.Run();