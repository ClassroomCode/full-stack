using Todo.Entities;

namespace Todo.DataAccess;

public static class TodoDbFactory
{
    public static ITodoDb Create() {
        return new TodoDb(); 
    }
}
