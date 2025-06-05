using TodoApi.Models;

public interface ITodoService
{
    Task<TodoItemDto> CreateAsync(TodoItemDto dto);
}