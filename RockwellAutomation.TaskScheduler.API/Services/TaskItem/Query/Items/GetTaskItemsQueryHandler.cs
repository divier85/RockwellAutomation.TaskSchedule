using MediatR;
using RockwellAutomation.TaskScheduler.Data;
using RockwellAutomation.TaskScheduler.Model.TaskItem.Query.Items;

namespace RockwellAutomation.TaskScheduler.API.Services.TaskItem.Query.Items
{
    public class GetTaskItemsQueryHandler : IRequestHandler<GetTaskItemsQueryParameters, List<TaskItemModel>>
    {
        private readonly RockwellTaskSchedulerDbContext _context;
        private readonly ILogger<GetTaskItemsQueryHandler> _logger;

        public GetTaskItemsQueryHandler(RockwellTaskSchedulerDbContext context,
            ILogger<GetTaskItemsQueryHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<TaskItemModel>> Handle(GetTaskItemsQueryParameters parameters, CancellationToken cancellationToken)
        {
            return _context.TaskItems.Where(n => n.IsActive).Select(s => new TaskItemModel
            {
                CronExpression = s.CronExpression,
                DateAdded = s.DateAdded,
                Id = s.Id,
                WebUrl = s.WebUrl
            }).ToList();
        }
    }
}
