using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

namespace ToDoApi.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
  private static readonly List<TaskDto> Tasks = new List<TaskDto>();
  
  

  // GET /tasks → Devuelve todas las tareas. Edson Arias
  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok(Tasks);
  }

  // GET /tasks/{id} → Devuelve una tarea específica por su ID.Edson Arias
  [HttpGet("{id}")]
  public IActionResult GetById([FromRoute] string id)
  {
    var task = Tasks.FirstOrDefault(t => t.Id == id);
    if (task == null)
    {
      return NotFound(new { message = "Tarea no encontrada." });
    }
    return Ok(task);
  }

  // POST /tasks → Agrega una nueva tarea (con título, descripcion y estado: “Pendiente” o “Completada”).
  [HttpPost]
  public IActionResult Create([FromBody] CreateTaskDto value)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    if (string.IsNullOrWhiteSpace(value.Title))
    {
      return BadRequest(new { message = "El título es obligatorio." });
    }

    if (string.IsNullOrWhiteSpace(value.Status) || (value.Status != "Pendiente" && value.Status != "Completada"))
    {
      return BadRequest(new { message = "El estado debe ser 'Pendiente' o 'Completada'." });
    }

    var newTask = new TaskDto
    {
      Title = value.Title,
      Description = value.Description,
      Status = value.Status,
    };

    Tasks.Add(newTask);
    return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
  }

  // PUT /tasks/{id} → Modifica una tarea existente.Edson Arias
  [HttpPut("{id}")]
  public IActionResult Update([FromRoute] string id, [FromBody] UpdateTaskDto value)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var task = Tasks.FirstOrDefault(t => t.Id == id);
    if (task == null)
    {
      return NotFound(new { message = "Tarea no encontrada." });
    }

    if (!string.IsNullOrWhiteSpace(value.Title))
    {
      task.Title = value.Title;
    }

    if (!string.IsNullOrWhiteSpace(value.Description))
    {
      task.Description = value.Description;
    }

    if (!string.IsNullOrWhiteSpace(value.Status) && (value.Status == "Pendiente" || value.Status == "Completada"))
    {
      task.Status = value.Status;
    }
    else if (!string.IsNullOrWhiteSpace(value.Status))
    {
      return BadRequest(new { message = "El estado debe ser 'Pendiente' o 'Completada'." });
    }

    return Ok(task);
  }

  // DELETE /tasks/{id} → Elimina una tarea.Edson Arias
  [HttpDelete("{id}")]
  public IActionResult Delete([FromRoute] string id)
  {
    var task = Tasks.FirstOrDefault(t => t.Id == id);
    if (task == null)
    {
      return NotFound(new { message = "Tarea no encontrada." });
    }

    Tasks.Remove(task);
    return NoContent();
  }
}