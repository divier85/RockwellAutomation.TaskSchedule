using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RockwellAutomation.TaskScheduler.Data;
using RockwellAutomation.TaskScheduler.Model.TaskItem.Query.Items;
using System;

namespace RockwellAutomation.TaskScheduler.Service.TaskItem.Query.Items
{
    public class GetTaskItemsQueryHandler : IRequestHandler<GetTaskItemsQueryParameters, List<TaskItemModel>>, IEventHandlerAssembly
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
