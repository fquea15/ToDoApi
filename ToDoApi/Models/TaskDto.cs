using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models;
public abstract class BaseTaskDto
{
    [Required(ErrorMessage = "El título es obligatorio")]
    [MinLength(3, ErrorMessage = "El título debe tener al menos 3 caracteres")]
    [MaxLength(100, ErrorMessage = "El título no puede superar los 100 caracteres")]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
    public string Description { get; set; } = string.Empty;
}

public class TaskDto : BaseTaskDto
{
r único de la tarea.

    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "El estado es obligatorio")]
    public TaskStatus Status { get; set; } = TaskStatus.Pendiente;
}

public class CreateTaskDto : BaseTaskDto
{
}

public enum TaskStatus
{
    Pendiente,
    Completada
}
