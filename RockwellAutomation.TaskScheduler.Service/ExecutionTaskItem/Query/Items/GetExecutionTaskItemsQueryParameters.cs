using MediatR;
using RockwellAutomation.TaskScheduler.Model.ExecutionTaskItem.Query.Items;

namespace RockwellAutomation.TaskScheduler.Service.ExecutionTaskItem.Query.Items
{
    public class GetExecutionTaskItemsQueryParameters : IRequest<List<ExecutionTaskItemModel>>
    {

    }
}
