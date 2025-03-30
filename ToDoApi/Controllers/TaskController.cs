using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        private static readonly List<TaskDto> Tasks = [];
        private static int nextId = 1;

        // GET /tasks → Devuelve todas las tareas.
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Tasks);
        }

        // GET /tasks/{id} → Devuelve una tarea específica por su ID. (TU PARTE)
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            return task != null ? Ok(task) : NotFound();
        }

        // POST /tasks → Agrega una nueva tarea (TU COMPAÑERO)
        [HttpPost]
        public IActionResult Create([FromBody] CreateTaskDto value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTask = new TaskDto
            {
                Id = nextId++,
                Title = value.Title,
                Description = value.Description,
                Status = value.Status
            };

            Tasks.Add(newTask);
            return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
        }

        // PUT /tasks/{id} → Modifica una tarea existente. (TU PARTE)
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateTaskDto updatedTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTask = Tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.Status = updatedTask.Status;

            return Ok(existingTask);
        }

        // DELETE /tasks/{id} → Elimina una tarea. (OTRO COMPAÑERO)
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            Tasks.Remove(task);
            return NoContent();
        }
    }

    // Modelos DTO (deben estar en archivos separados, pero los muestro aquí como referencia)
    public class TaskDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        
        [RegularExpression("^(Pendiente|Completada)$", ErrorMessage = "Estado inválido")]
        public required string Status { get; set; }
    }

    public class CreateTaskDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public required string Title { get; set; }
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "El estado es obligatorio")]
        [RegularExpression("^(Pendiente|Completada)$", ErrorMessage = "Estado inválido")]
        public required string Status { get; set; }
    }

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