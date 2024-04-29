using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NCrontab;
using RockwellAutomation.TaskScheduler.Data;
using RockwellAutomation.TaskScheduler.Model.TaskItem.Command.Post;
using Entities = RockwellAutomation.TaskScheduler.Data.Entity;

namespace RockwellAutomation.TaskScheduler.Service.TaskItem.Command.Post
{
    public class PostTaskItemCommandHandler : IRequestHandler<PostTaskItemCommand, TaskItemModel>
    {
        private readonly RockwellTaskSchedulerDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public PostTaskItemCommandHandler(RockwellTaskSchedulerDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<TaskItemModel> Handle(PostTaskItemCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Validate(command);

                var task = new Entities.TaskItem()
                {
                    CronExpression = command.CronExpression,
                    WebUrl = command.WebUrl,
                    DateAdded = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.TaskItems.AddAsync(task);
                await _dbContext.SaveChangesAsync();

                int taskId = task.Id;

                Thread executionTaskThread = new Thread(async () =>
                {
                    var optionsBuilder = new DbContextOptionsBuilder<RockwellTaskSchedulerDbContext>();
                    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

                    using (var dbContext = new RockwellTaskSchedulerDbContext(optionsBuilder.Options))
                    {
                        var schedule = CrontabSchedule.Parse(task.CronExpression);
                        var nextRun = schedule.GetNextOccurrence(DateTime.Now);

                        await Task.Delay(nextRun - DateTime.Now);

                        var httpClient = new HttpClient();
                        var response = await httpClient.GetAsync(command.WebUrl);

                        var executionTask = new Entities.ExecutionTaskItem()
                        {
                            TaskItemId = taskId,
                            DateAdded = DateTime.Now,
                            Headers = response.Headers.ToString().Length <= 1000
                            ? response.Headers.ToString()
                            : response.Headers.ToString().Substring(0, 1000)
                        };

                        dbContext.ExecutionTaskItems.Add(executionTask);
                        dbContext.SaveChanges();
                    }
                });
                executionTaskThread.Start();

                return new TaskItemModel()
                {
                    Id = task.Id,
                    WebUrl = task.WebUrl,
                    CronExpression = task.CronExpression,
                    DateAdded = task.DateAdded

                };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void Validate(PostTaskItemCommand command)
        {
            if (string.IsNullOrEmpty(command.WebUrl))
            {
                throw new ArgumentException("WebUrl is required");
            }

            if (string.IsNullOrEmpty(command.CronExpression))
            {
                throw new ArgumentException("CronExpression is required");
            }
        }
    }
}