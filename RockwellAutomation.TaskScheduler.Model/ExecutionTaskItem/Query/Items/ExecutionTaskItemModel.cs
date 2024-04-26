using RockwellAutomation.TaskScheduler.Model.Interface;

namespace RockwellAutomation.TaskScheduler.Model.ExecutionTaskItem.Query.Items
{
    public class ExecutionTaskItemModel: IModel
    {
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public string WebUrl { get; set; }
        public string CronExpression { get; set; }
        public string Headers { get; set; }
        public DateTime DateAdded { get; set; }
    }
}