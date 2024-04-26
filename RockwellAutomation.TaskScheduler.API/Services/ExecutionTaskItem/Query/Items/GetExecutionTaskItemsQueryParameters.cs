using MediatR;
using RockwellAutomation.TaskScheduler.Model.ExecutionTaskItem.Query.Items;

namespace RockwellAutomation.TaskScheduler.API.Services.ExecutionTaskItem.Query.Items
{
    public class GetExecutionTaskItemsQueryParameters : IRequest<List<ExecutionTaskItemModel>>
    {

    }
}
