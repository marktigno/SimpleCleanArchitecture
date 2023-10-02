using SimpleCleanArchitecture.Domain.Entities;

namespace SimpleCleanArchitecture.Application.Persistence;

public interface ITodoItemRepository
{
    void CreateTodo(TodoItem todoItem);
    TodoItem? GetTodoItem(Guid Id);
    void UpdateTodo(TodoItem todoItem);
    void DeleteTodo(TodoItem todoItem);
    Task<IReadOnlyList<TodoItem>> GetTodoItems();
}