using MediatR;
using RockwellAutomation.TaskScheduler.Model.TaskItem.Command.Post;

namespace RockwellAutomation.TaskScheduler.Service.TaskItem.Command.Post
{
    public class PostTaskItemCommand : IRequest<TaskItemModel>
    {
        public string WebUrl { get; set; }
        public string CronExpression { get; set; }
        
    }
}
