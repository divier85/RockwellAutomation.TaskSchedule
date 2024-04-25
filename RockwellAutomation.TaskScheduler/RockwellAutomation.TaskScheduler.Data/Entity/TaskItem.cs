using RockwellAutomation.TaskScheduler.Data.Interface;

namespace RockwellAutomation.TaskScheduler.Data.Entity
{
    public class TaskItem : IEntity
    {
        public int Id { get; set; }
        public required string CronExpression { get; set; }
        public required string WebUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsActive { get; set; }
    }
}
