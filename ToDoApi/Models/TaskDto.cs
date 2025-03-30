namespace ToDoApi.Models;

public abstract class BaseTaskDto
{
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Status { get; set; } = "Pendiente";
}

public class TaskDto : BaseTaskDto
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
}

public class CreateTaskDto : BaseTaskDto
{
}
