namespace Todo.Entities;

public interface ITodoDb
{
    Task<IEnumerable<TodoItem>> GetAllTodos();
    Task<TodoItem?> GetTodo(int id);
    Task AddTodo(TodoItem todo);
    Task<bool> UpdateTodo(TodoItem todo);
    Task<bool> DeleteTodo(TodoItem todo);
}
