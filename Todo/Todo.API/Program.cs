using Microsoft.EntityFrameworkCore;
using Todo.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDb>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

app.MapGet("/todoitems", (TodoDb db) => db.Todos);

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var db = services.GetRequiredService<TodoDb>();
    db.Todos.Add(new TodoItem { Id = 1, Name = "One", IsComplete = false });
    db.Todos.Add(new TodoItem { Id = 2, Name = "Two", IsComplete = true });
    await db.SaveChangesAsync();
}

app.Run();