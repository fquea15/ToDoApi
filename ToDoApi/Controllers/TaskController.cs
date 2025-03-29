using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

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