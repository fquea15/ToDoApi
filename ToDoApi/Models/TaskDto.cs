using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models;

public abstract class BaseTaskDto
{
  [Required(ErrorMessage = "El título es obligatorio")]
  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;
}

public class TaskDto : BaseTaskDto
{
  public string Id { get; set; } = Guid.NewGuid().ToString();
  
  [Required(ErrorMessage = "El estado es obligatorio")]
  [RegularExpression("^(Completada|Pendiente)$", ErrorMessage = "Estado inválido")]
  public string Status { get; set; } = "Pendiente";
}

public class CreateTaskDto : BaseTaskDto
{
}
