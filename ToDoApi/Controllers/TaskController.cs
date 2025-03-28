﻿using Microsoft.AspNetCore.Mvc;
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

  // GET /tasks/{id} → Devuelve una tarea específica por su ID.
  [HttpGet("{id}")]
  public IActionResult GetById([FromRoute] string id)
  {
    return Ok(new { Message = "Read By Id" });
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

  // PUT /tasks/{id} → Modifica una tarea existente.
  [HttpPut("{id}")]
  public IActionResult Update([FromRoute] string id, [FromBody] string value)
  {
    return Ok(new { message = "updated" });
  }

  // DELETE /tasks/{id} → Elimina una tarea.
  [HttpDelete("{id}")]
  public IActionResult Delete([FromRoute] string id)
  {
    return Ok(new { message = "Deleted" });
  }
}