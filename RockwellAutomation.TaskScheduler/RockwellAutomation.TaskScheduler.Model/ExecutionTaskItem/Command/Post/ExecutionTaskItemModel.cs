using RockwellAutomation.TaskScheduler.Model.Interface;

namespace RockwellAutomation.TaskScheduler.Model.ExecutionTaskItem.Command.Post
{
    public class ExecutionTaskItemModel: IModel
    {
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public string Headers { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
