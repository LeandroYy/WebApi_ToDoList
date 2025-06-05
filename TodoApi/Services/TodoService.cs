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

        return new TodoItemDto
        {
            Id = saved.Id,
            Name = saved.Name,
            IsComplete = saved.IsComplete
        };
    }
}