using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class UpdateTaskDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public required string Title { get; set; }
        
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "El estado es obligatorio")]
        [RegularExpression("^(Pendiente|Completada)$", ErrorMessage = "Estado inválido")]
        public required string Status { get; set; }
    }
}