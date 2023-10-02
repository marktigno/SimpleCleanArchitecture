using Microsoft.AspNetCore.Mvc;
using SimpleCleanArchitecture.Application.Services;
using SimpleCleanArchitecture.Domain.Entities;

namespace SimpleCleanArchitecture.Api;

[ApiController]
[Route ("api/[controller]")]
public class TodoItemController : ControllerBase
{
    private readonly ITodoItemService _todoItemService;

    public TodoItemController(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }

    [HttpPost("create")]
    public IActionResult CreateTodo(string todoEntry)
    {
        _todoItemService.CreateTodoItem(todoEntry);
        return Ok();
    }

    [HttpPut("update")]
    public IActionResult UpdateTodo(Guid id, string todoEntry)
    {
        _todoItemService.UpdateTodoItem(id, todoEntry);
        return Ok();
    }

    [HttpDelete("delete")]
    public IActionResult DeleteTodo(Guid id)
    {
        _todoItemService.DeleteTotoIem(id);
        return Ok();
    }

    [HttpGet("get")]
    public IActionResult GetTodo(Guid id)
    {
        return Ok(_todoItemService.GetTodoItem(id));
    }

    [HttpGet("getall")]
    public IActionResult GetAllTodos()
    {
        return Ok(_todoItemService.GetTodoItems());
    }
}