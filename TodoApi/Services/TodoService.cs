using TodoApi.Models;

public class TodoService : ITodoService
{
    private readonly IToDoRepository _repository;

    public TodoService(IToDoRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoItemDto> CreateAsync(TodoItemDto dto)
    {
        var entity = new TodoItem
        {
            Name = dto.Name,
            IsComplete = dto.IsComplete
        };

        var saved = await _repository.AddAsync(entity);

        return ItemToDTO(saved);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        await _repository.DeleteAsync(existing);
        return true;
    }

    public async Task<List<TodoItemDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(ItemToDTO).ToList();
    }

    public async Task<TodoItemDto> GetByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        return item is null ? null : ItemToDTO(item);
    }

    public async Task<bool> UpdateAsync(int id, TodoItemDto dto)
    {
        if (id != dto.Id) return false;

        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return false;

        existing.Name = dto.Name;
        existing.IsComplete = dto.IsComplete;

        await _repository.UpdateAsync(existing);
        return true;
    }

    private static TodoItemDto ItemToDTO(TodoItem todoItem) =>
            new TodoItemDto
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
}