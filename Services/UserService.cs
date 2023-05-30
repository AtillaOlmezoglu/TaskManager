﻿using TaskManagerAPI.Data;
using TaskManagerAPI.Models.DTO;
using TaskManagerAPI.Models.Entities;

namespace TaskManagerAPI.Services;

public interface IUserService
{
    IEnumerable<UserTask> GetAllTasks();
    void CreateTask(UserTaskDto model);
    void UpdateTask(int id, UpdateUserTaskDto model);
    void DeleteTask(int id);
}

public class UserService : IUserService
{
    private TaskManagerContext _context;

    public UserService(TaskManagerContext context)
    {
        _context = context;
    }

    public IEnumerable<UserTask> GetAllTasks()
    {
        return _context.Tasks;
    }

    public void CreateTask(UserTaskDto model)
    {
        throw new NotImplementedException();
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
