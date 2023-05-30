using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models.Entities;

namespace TaskManagerAPI.Data;

public class TaskManagerContext : DbContext
{
    public DbSet<UserTask> Tasks { get; set; }

    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    { }
}
