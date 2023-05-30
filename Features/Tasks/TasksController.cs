using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Features.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private IUserService _userService;
    public TasksController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAllTasks()
    {
        var tasks = _userService.GetAll();

        return Ok(tasks);
    }

    [HttpPost]
    public IActionResult CreateTask(CreateRequest model)
    {
        _userService.Create(model);

        return Ok(new { message = "Task created!"});
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, UpdateRequest model)
    {
        _userService.Update(id, model);

        return Ok(new { message = "Task updated!" });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        _userService.Delete(id);

        return Ok(new { message = "Task deleted!" });
    }
}