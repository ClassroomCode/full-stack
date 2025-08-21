using System.Text.Json.Serialization;

namespace Todo.Entities;

public class TodoItem
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonPropertyName("isFinished")]
    public bool IsComplete { get; set; }
}
