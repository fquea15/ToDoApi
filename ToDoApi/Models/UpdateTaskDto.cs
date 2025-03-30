using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models;

public class UpdateTaskDto : BaseTaskDto
{
    [Required(ErrorMessage = "El estado es obligatorio")]
    [RegularExpression("^(Pendiente|Completada)$", ErrorMessage = "Estado inválido")]
    public string Status { get; set; } = "Completada";
}