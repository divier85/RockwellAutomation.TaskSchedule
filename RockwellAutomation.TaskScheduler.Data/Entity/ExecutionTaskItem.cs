using RockwellAutomation.TaskScheduler.Data.Interface;

namespace RockwellAutomation.TaskScheduler.Data.Entity
{
    public class ExecutionTaskItem : IEntity
    {
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public string Headers { get; set; }
        public DateTime DateAdded { get; set; }

        public TaskItem TaskItem { get; set; }
    }
}
