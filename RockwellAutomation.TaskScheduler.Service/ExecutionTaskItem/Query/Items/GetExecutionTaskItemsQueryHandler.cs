using MediatR;
using Microsoft.Extensions.Logging;
using RockwellAutomation.TaskScheduler.Data;
using RockwellAutomation.TaskScheduler.Model.ExecutionTaskItem.Query.Items;

namespace RockwellAutomation.TaskScheduler.Service.ExecutionTaskItem.Query.Items
{
    public class GetExecutionTaskItemsQueryHandler : IRequestHandler<GetExecutionTaskItemsQueryParameters, List<ExecutionTaskItemModel>>
    {
        private readonly RockwellTaskSchedulerDbContext _context;
        private readonly ILogger<GetExecutionTaskItemsQueryHandler> _logger;

        public GetExecutionTaskItemsQueryHandler(RockwellTaskSchedulerDbContext context,
            ILogger<GetExecutionTaskItemsQueryHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<ExecutionTaskItemModel>> Handle(GetExecutionTaskItemsQueryParameters parameters, CancellationToken cancellationToken)
        {
            return _context.ExecutionTaskItems.Select(s => new ExecutionTaskItemModel
            {
                CronExpression = s.TaskItem.CronExpression,
                TaskItemId = s.TaskItemId,
                Id = s.Id,
                WebUrl = s.TaskItem.WebUrl,
                Headers = s.Headers,
                DateAdded = s.DateAdded
            }).ToList();
        }
    }
}
