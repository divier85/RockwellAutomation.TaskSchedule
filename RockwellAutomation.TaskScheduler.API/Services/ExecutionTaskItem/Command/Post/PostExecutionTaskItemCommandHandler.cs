using MediatR;
using RockwellAutomation.TaskScheduler.Data;
using RockwellAutomation.TaskScheduler.Model.ExecutionTaskItem.Command.Post;
using Entities = RockwellAutomation.TaskScheduler.Data.Entity;

namespace RockwellAutomation.TaskScheduler.API.Services.ExecutionTaskItem.Command.Post
{
    public class PostExecutionTaskItemCommandHandler : IRequestHandler<PostExecutionTaskItemCommand, ExecutionTaskItemModel>
    {
        private readonly RockwellTaskSchedulerDbContext _dbContext;
        public PostExecutionTaskItemCommandHandler(RockwellTaskSchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ExecutionTaskItemModel> Handle(PostExecutionTaskItemCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Validate(command);

                var item = new Entities.ExecutionTaskItem()
                {
                    DateAdded = DateTime.Now,
                    TaskItemId = command.TaskItemId,
                    Headers = string.Empty
                };

                await _dbContext.ExecutionTaskItems.AddAsync(item);
                await _dbContext.SaveChangesAsync();

                return new ExecutionTaskItemModel()
                {
                    Id = item.Id,
                    TaskItemId = item.TaskItemId,
                    DateAdded = item.DateAdded,
                    Headers = item.Headers

                };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void Validate(PostExecutionTaskItemCommand command)
        {
            if (command.TaskItemId <= 0)
            {
                throw new ArgumentException("TaskItemId is required");
            }

        }
    }
}
