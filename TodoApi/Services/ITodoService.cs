using TodoApi.Models;

public interface ITodoService
{
    Task<TodoItemDto> CreateAsync(TodoItemDto dto);
    Task<List<TodoItemDto>> GetAllAsync();
    Task<TodoItemDto> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, TodoItemDto dto);
    Task<bool> DeleteAsync(int id);

}