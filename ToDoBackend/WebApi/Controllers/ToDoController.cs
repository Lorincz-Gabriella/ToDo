using Microsoft.AspNetCore.Mvc;
using ToDo.Application.DTOs;
using ToDo.Application.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoService _service;

        public ToDoController(ILogger<ToDoController> logger, IToDoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("todos")]
        public IActionResult GetAllToDoItems()
        {
            _logger.LogInformation("GetAllToDoItems endpoint called");
            var items = _service.GetAllToDos();
            return Ok(items);
        }

        [HttpGet("todos/{id}")]
        public IActionResult GetToDoById(Guid id)
        {
            _logger.LogInformation("GetToDoById endpoint called");
            var item = _service.GetToDoById(id);
            if (item == null)
                return NotFound($"Item with id {id} not found.");
            return Ok(item);
        }

        [HttpPost("todos")]
        public IActionResult AddToDoToDB([FromBody] CreateToDoItemDTO createDTO)
        {
            try
            {
                _logger.LogInformation("AddToDoToD endpoint called");
                if (createDTO == null)
                    return BadRequest("Request body is null");
                var item = _service.AddToDoToDB(createDTO);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: adding a ToDo item");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPatch("todos/{id}")]
        public IActionResult UpdateToDoById(Guid id, [FromBody] UpdateToDoItemDTO updateDto)
        {
            _logger.LogInformation("UpdateToDoById endpoint called");
            if (updateDto == null)
                return BadRequest("Update data is null");
            var item = _service.UpdateToDo(id,updateDto);
            return Ok(item);
        }

        [HttpDelete("todos/{id}")]
        public IActionResult DeleteToDoById(Guid id)
        {
            _logger.LogInformation("UpdateToDoById endpoint called");
            var item = _service.DeleteToDo(id);
            return Ok(item);
        }
    }
}
