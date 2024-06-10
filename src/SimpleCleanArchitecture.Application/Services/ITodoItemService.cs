using ErrorOr;
using SimpleCleanArchitecture.Domain.Entities;

namespace SimpleCleanArchitecture.Application.Services;

public interface ITodoItemService
{
    public void CreateTodoItem(string todoEntry);
    public void UpdateTodoItem(Guid id, string todoEntry);
    public void DeleteTotoIem(Guid id);
    public Either<TodoItemResponse, NullReferenceException> GetTodoItem(Guid id);

    public Task<ErrorOr<List<TodoItemResponse>?>> GetTodoItems();
}