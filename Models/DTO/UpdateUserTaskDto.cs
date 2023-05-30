namespace TaskManagerAPI.Models.DTO;

public class UpdateUserTaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}
