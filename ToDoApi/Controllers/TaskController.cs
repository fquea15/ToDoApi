using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

namespace ToDoApi.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
    private static readonly List<TaskDto> Tasks = [];

    // GET /tasks → Devuelve todas las tareas.
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Tasks);
    }

    // GET /tasks/{id} → Devuelve una tarea específica por su ID. (TU PARTE)
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] string id)
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
            Title = value.Title,
            Description = value.Description,
        };

        Tasks.Add(newTask);
        return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
    }

    // PUT /tasks/{id} → Modifica una tarea existente. (TU PARTE)
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] string id, [FromBody] UpdateTaskDto updatedTask)
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
    public IActionResult Delete([FromRoute] string id)
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