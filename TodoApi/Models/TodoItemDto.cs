namespace TodoApi.Models;

public class TodoItemDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}