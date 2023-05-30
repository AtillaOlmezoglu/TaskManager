﻿using TaskManagerAPI.Data;
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
        throw new NotImplementedException();
    }

    public void DeleteTask(int id)
    {
        throw new NotImplementedException();
    }
}
