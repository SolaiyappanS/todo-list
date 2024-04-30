using Microsoft.AspNetCore.Mvc;
using todo_list.Interfaces;
using todo_list.Models;

namespace todo_list.Controllers;

[ApiController]
[Route("api")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet("todo-items")]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAllTasks()
    {
        try
        {
            var tasks = await _todoService.GetAllTasks();
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("todo-items/{id}")]
    public async Task<ActionResult<Todo>> GetTaskById(string id)
    {
        try
        {
            var task = await _todoService.GetTaskById(id);
            return Ok(task);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("todo-item")]
    public async Task<ActionResult<IEnumerable<Todo>>> AddNewTask (TodoAddRequest newTodo)
    {
        try
        {
            var result = await _todoService.AddNewTask(newTodo);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("todo-item/{id}")]
    public async Task<ActionResult<Todo>> UpdateExistingTask(TodoUpdateRequest updatedTodo,string id)
    {
        try
        {
            var result = await _todoService.UpdateExistingTask(updatedTodo, id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("todo-item/{id}")]
    public async Task<ActionResult<IEnumerable<Todo>>> DeleteTaskById(string id)
    {
        try
        {
            var result = await _todoService.DeleteTaskById(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

