using Microsoft.EntityFrameworkCore;
using SimpleCleanArchitecture.Application.Persistence;
using SimpleCleanArchitecture.Domain.Entities;

namespace SimpleCleanArchitecture.Infrastructure.Persistence;

public class TodoItemRepository : ITodoItemRepository
{
    private PersistenceDbContext _persistenceDbContext;
    public TodoItemRepository(PersistenceDbContext persistenceDbContext)
    {
        _persistenceDbContext = persistenceDbContext;
    }
    public void CreateTodo(TodoItem todoItem)
    {
        _persistenceDbContext.TodoItems.Add(todoItem);
        _persistenceDbContext.SaveChanges();
    }

    public void DeleteTodo(TodoItem todoItem)
    {
        _persistenceDbContext.TodoItems.Remove(todoItem);
        _persistenceDbContext.SaveChanges();
    }

    public TodoItem? GetTodoItem(Guid Id)
    {
        TodoItem? todoItem = _persistenceDbContext.TodoItems.Find(Id);
        return todoItem;
    }

    public async Task<IReadOnlyList<TodoItem>> GetTodoItems()
    {
        return await _persistenceDbContext.TodoItems.ToListAsync();
    }

    public void UpdateTodo(TodoItem todoItem)
    {
        _persistenceDbContext.TodoItems.Update(todoItem);
        _persistenceDbContext.SaveChanges();
    }
}