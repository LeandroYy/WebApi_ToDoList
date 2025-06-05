using TodoApi.Models;

public interface IToDoRepository
{
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem> AddAsync(TodoItem item);
    Task<TodoItem> GetByIdAsync(int id);
    Task UpdateAsync(TodoItem item);
    Task DeleteAsync(TodoItem item);
    Task<bool> ExistsAsync(int id);
}