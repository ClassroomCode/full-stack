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

    public async Task<IEnumerable<TodoItem>> GetAllTodos()
    {
        return await Todos.ToListAsync();
    }

    public async Task<TodoItem?> GetTodo(int id)
    {
        return await Todos.FindAsync(id);
    }

    public Task<bool> UpdateTodo(TodoItem todo)
    {
        throw new NotImplementedException();
    }
}


