
using System.Security.Cryptography.X509Certificates;
using ErrorOr;
using SimpleCleanArchitecture.Application.Persistence;
using SimpleCleanArchitecture.Domain.Entities;

namespace SimpleCleanArchitecture.Application.Services;

public class TodoItemService : ITodoItemService
{
    private readonly ITodoItemRepository _todoItemRepository;
    public TodoItemService(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public void CreateTodoItem(string todoEntry)
    {
        TodoItem todoItem = new TodoItem{
            Id = Guid.NewGuid(),
            TodoEntry = todoEntry,
            DateTimeCreated = DateTime.UtcNow
        };

        _todoItemRepository.CreateTodo(todoItem);
    }

    public void DeleteTotoIem(Guid id)
    {
        TodoItem? todoItem;
        todoItem = _todoItemRepository.GetTodoItem(id);

        if (todoItem is not null)
        {
            _todoItemRepository.DeleteTodo(todoItem);
        }
    }

    public Either<TodoItemResponse, NullReferenceException> GetTodoItem(Guid id)
    {
        TodoItem? todoItem = _todoItemRepository.GetTodoItem(id);
        
        if (todoItem is null)
        {
            return new Either<TodoItemResponse, NullReferenceException>(new NullReferenceException("To do item returned null or empty."));
        }

        TodoItemResponse todoItemResponse = new TodoItemResponse{
            Id = todoItem.Id,
            TodoEntry = todoItem.TodoEntry,
            DateTimeCreated = todoItem.DateTimeCreated,
            DateTimeModified = todoItem.DateTimeModified
        };

        return new Either<TodoItemResponse, NullReferenceException>(todoItemResponse);
    }

    public async Task<ErrorOr<List<TodoItemResponse>?>> GetTodoItems()
    {
        List<TodoItemResponse> todoItemResponses = new List<TodoItemResponse>();

        IReadOnlyList<TodoItem> todoItems = await _todoItemRepository.GetTodoItems();

        if (todoItems.Count == 0)
        {
            return Error.NotFound(description: "To do items are empty.");
        }

        foreach (TodoItem todoItem in todoItems)
        {
            todoItemResponses.Add(new TodoItemResponse {
                Id = todoItem.Id,
                TodoEntry = todoItem.TodoEntry,
                DateTimeCreated = todoItem.DateTimeCreated,
                DateTimeModified = todoItem.DateTimeModified
            });
        }

        return todoItemResponses;
    }

    public void UpdateTodoItem(Guid id, string todoEntry)
    {
        TodoItem? todoItem;
        todoItem = _todoItemRepository.GetTodoItem(id);

        if (todoItem is not null)
        {
            todoItem.TodoEntry = todoEntry;
            todoItem.DateTimeModified = DateTime.UtcNow;
            _todoItemRepository.UpdateTodo(todoItem);
        }
    }
}