using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok(new { Message = "Read All Tasks." });
  }

  public IActionResult GetById(int id)
  {
    return Ok(new { Message = "Read By Id" });
  }

  [HttpPost]
  public IActionResult Post([FromBody] string value)
  {
    return Ok(new { message = "created" });
  }

  [HttpPut("{id}")]
  public IActionResult Put([FromRoute] string id, [FromBody] string value)
  {
    return Ok(new { message = "updated" });
  }

  [HttpDelete("{id}")]
  public IActionResult Delete([FromRoute] string id)
  {
    return Ok(new { message = "Deleted" });
  }
}