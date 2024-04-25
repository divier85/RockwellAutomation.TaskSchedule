using RockwellAutomation.TaskScheduler.Model.Interface;

namespace RockwellAutomation.TaskScheduler.Model.TaskItem.Query.Items
{
    public class TaskItemModel: IModel
    {
        public int Id { get; set; }
        public string CronExpression { get; set; }
        public string WebUrl { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
