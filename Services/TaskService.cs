using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.DTO;
using TaskManagerAPI.Models.Entities;

namespace TaskManagerAPI.Services;

public interface ITaskService
{
    Task<IEnumerable<UserTask>> GetAllTasks();
    Task CreateTask(UserTaskDto model);
    Task UpdateTask(int id, UpdateUserTaskDto model);
    Task DeleteTask(int id);
}

public class TaskService : ITaskService
{
    private TaskManagerContext _context;

    public TaskService(TaskManagerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserTask>> GetAllTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task CreateTask(UserTaskDto model)
    {
        var task = new UserTask
        {
            Title = model.Title,
            Description = model.Description,
            DueDate = model.DueDate,
            CreatedDate = DateTime.Now,
            IsCompleted = false,
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTask(int id, UpdateUserTaskDto model)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id) ?? throw new KeyNotFoundException("That task doesnt exist.");

        task.Title = model.Title;
        task.Description = model.Description;
        task.DueDate = model.DueDate;
        task.IsCompleted = model.IsCompleted;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteTask(int id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException("That task doesnt exist.");

        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }
}
