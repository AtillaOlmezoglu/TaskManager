using TaskManagerAPI.Data;
using TaskManagerAPI.Models.DTO;
using TaskManagerAPI.Models.Entities;

namespace TaskManagerAPI.Services;

public interface ITaskService
{
    IEnumerable<UserTask> GetAllTasks();
    void CreateTask(UserTaskDto model);
    void UpdateTask(int id, UpdateUserTaskDto model);
    void DeleteTask(int id);
}

public class TaskService : ITaskService
{
    private TaskManagerContext _context;

    public TaskService(TaskManagerContext context)
    {
        _context = context;
    }

    public IEnumerable<UserTask> GetAllTasks()
    {
        return _context.Tasks;
    }

    public void CreateTask(UserTaskDto model)
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
        _context.SaveChanges();
    }

    public void UpdateTask(int id, UpdateUserTaskDto model)
    {
        var task = _context.Tasks.Find(id) ?? throw new KeyNotFoundException("That task doesnt exist.");

        task.Title = model.Title;
        task.Description = model.Description;
        task.DueDate = model.DueDate;
        task.IsCompleted = model.IsCompleted;

        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void DeleteTask(int id)
    {
        var task = _context.Tasks.Find(id) ?? throw new KeyNotFoundException("That task doesnt exist.");

        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }
}
