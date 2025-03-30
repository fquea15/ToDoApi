using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models;

public class UpdateTaskDto
{
    [Required(ErrorMessage = "El título es obligatorio")]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "El estado es obligatorio")]
    [RegularExpression("^(Pendiente|Completada)$", ErrorMessage = "Estado inválido")]
    public string Status { get; set; } = "Pendiente";
}