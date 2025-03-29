using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models;

// Enum para el estado de la tarea
[JsonConverter(typeof(JsonStringEnumConverter))] // Para mostrar el nombre en Swagger
public enum TaskStatus
{
    Pendiente,
    Completada
}

// Modelo de la tarea
public class TodoTask
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio.")]
    public TaskStatus Status { get; set; }
}