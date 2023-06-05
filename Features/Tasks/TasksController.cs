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
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _userService.GetAllTasks();

        return Ok(tasks);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateTask(UserTaskDto model)
    {
        await _userService.CreateTask(model);

        return Created("", new { message = "Task created!"});
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> UpdateTask(int id, UpdateUserTaskDto model)
    {
        await _userService.UpdateTask(id, model);

        return Ok(new { message = "Task updated!" });
    }

    [HttpDelete("Delete{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await _userService.DeleteTask(id);

        return NoContent();
    }
}