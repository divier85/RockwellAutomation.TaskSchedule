using MediatR;
using Microsoft.AspNetCore.Mvc;
using RockwellAutomation.TaskScheduler.Service.TaskItem.Command.Post;
using Swashbuckle.AspNetCore.Annotations;
using TaskItems = RockwellAutomation.TaskScheduler.Service.TaskItem.Query.Items;
using ExecutionTaskItems = RockwellAutomation.TaskScheduler.Service.ExecutionTaskItem.Query.Items;

namespace RockwellAutomation.TaskScheduler.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly ILogger<TaskItemController> _logger;
        private readonly IMediator _mediator;
        public TaskItemController(IMediator mediator,
            ILogger<TaskItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region GET
        [HttpGet]
        [Route("get-task-items")]
        [SwaggerOperation(Tags = new string[] { "Task Items" })]
        public IActionResult GetTaskItems()
        {
            var response = _mediator.Send(new TaskItems.GetTaskItemsQueryParameters() { });
            return Ok(response);
        }

        [HttpGet]
        [Route("get-execution-task-items")]
        [SwaggerOperation(Tags = new string[] { "Task Items" })]
        public IActionResult GetExecutionTaskItems()
        {
            var response = _mediator.Send(new ExecutionTaskItems.GetExecutionTaskItemsQueryParameters() { });
            return Ok(response);
        }
        #endregion


        #region POST
        [HttpPost]
        [Route("post-task-item")]
        [SwaggerOperation(Tags = new string[] { "Task Items" })]
        public async Task<ActionResult> Post([FromBody] PostTaskItemCommand postTaskItem)
        {
            return Ok(await _mediator.Send(postTaskItem));
        }
        #endregion
    }
}
