using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Entities;
using ToDo.WebApi.Interfaces;


namespace ToDo.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(ToDoEntity entity)
        {
            return Ok(await _toDoRepository.Create(entity));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _toDoRepository.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(string id)
        {
            return Ok(await _toDoRepository.GetById(id));
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(ToDoEntity entity)
        {
            return Ok(await _toDoRepository.Update(entity));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(string id)
        {
            return Ok(await _toDoRepository.Delete(id));
        }
    }
}
