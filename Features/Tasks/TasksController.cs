using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models.DTO;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Features.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private ITaskService _userService;
    public TasksController(ITaskService userService)
    {
        _userService = userService;
    }

    [HttpGet("Get-all-tasks")]
    public IActionResult GetAllTasks()
    {
        var tasks = _userService.GetAllTasks();

        return Ok(tasks);
    }

    [HttpPost("Create")]
    public IActionResult CreateTask(UserTaskDto model)
    {
        _userService.CreateTask(model);

        return Created("", new { message = "Task created!"});
    }

    [HttpPut("Update/{id}")]
    public IActionResult UpdateTask(int id, UpdateUserTaskDto model)
    {
        _userService.UpdateTask(id, model);

        return Ok(new { message = "Task updated!" });
    }

    [HttpDelete("Delete{id}")]
    public IActionResult DeleteTask(int id)
    {
        _userService.DeleteTask(id);

        return NoContent();
    }
}