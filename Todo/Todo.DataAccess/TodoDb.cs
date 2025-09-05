using Microsoft.EntityFrameworkCore;
using Todo.Entities;

namespace Todo.DataAccess;

internal class TodoDb : DbContext, ITodoDb
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("TodoList");
    }

    public DbSet<TodoItem> Todos { get; set; }

    public Task AddTodo(TodoItem todo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTodo(TodoItem todo)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetAllTodos()
    {
        throw new NotImplementedException();
    }

    public Task<TodoItem?> GetTodo(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateTodo(TodoItem todo)
    {
        throw new NotImplementedException();
    }
}


