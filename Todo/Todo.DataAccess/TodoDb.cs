using Microsoft.EntityFrameworkCore;
using Todo.Entities;

namespace Todo.DataAccess;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<TodoItem> Todos { get; set; }
}


