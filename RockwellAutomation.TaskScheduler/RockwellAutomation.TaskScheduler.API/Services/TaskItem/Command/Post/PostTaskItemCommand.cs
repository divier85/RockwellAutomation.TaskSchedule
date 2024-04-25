using MediatR;
using RockwellAutomation.TaskScheduler.Model.TaskItem.Command.Post;

namespace RockwellAutomation.TaskScheduler.API.Services.TaskItem.Command.Post
{
    public class PostTaskItemCommand : IRequest<TaskItemModel>
    {
        public string WebUrl { get; set; }
        public string CronExpression { get; set; }
        
    }
}
