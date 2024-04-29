using MediatR;
using RockwellAutomation.TaskScheduler.Model.TaskItem.Query.Items;

namespace RockwellAutomation.TaskScheduler.Service.TaskItem.Query.Items
{
    public class GetTaskItemsQueryParameters : IRequest<List<TaskItemModel>>
    {
       
    }
}
