using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.TodoActivity.Commands;
using Service.TodoActivity.Queries;
using System;
using System.Threading.Tasks;

namespace Service.TodoActivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var query = new GetTaskQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
        [HttpGet("")]
        public async Task<IActionResult> GetTasks(int page=1, int size=10)
        {
            var filter = new GetTasksQuery(page, size);
            var result = await _mediator.Send(filter);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var query = new DeleteTaskCommand(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
        [HttpPost("search")]
        public async Task<IActionResult> SearchTask([FromBody] SearchTasksQuery searchQuery)
        {
            var query = new SearchTasksQuery();
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}