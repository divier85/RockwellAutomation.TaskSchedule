using MediatR;
using RockwellAutomation.TaskScheduler.Model.TaskItem.Query.Items;

namespace RockwellAutomation.TaskScheduler.API.Services.TaskItem.Query.Items
{
    public class GetTaskItemsQueryParameters : IRequest<List<TaskItemModel>>
    {
       
    }
}
