using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SimpleCleanArchitecture.Application.Services;

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
        var result = _todoItemService.GetTodoItem(id);
        return result.Match<IActionResult>(response => Ok(response),
            ex => new BadRequestResult());

    }

    [HttpGet("getall")]
    public IActionResult GetAllTodos()
    {
        var result = _todoItemService.GetTodoItems();

        if (result.Result.IsError)
        {
            return new NotFoundResult();
        }

        return Ok(result.Result.Value);
    }
}