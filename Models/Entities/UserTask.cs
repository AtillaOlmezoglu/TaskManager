namespace TaskManagerAPI.Models.Entities;

public record UserTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set;}
    public bool IsCompleted { get; set;}
}
