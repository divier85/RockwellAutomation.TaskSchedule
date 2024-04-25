using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockwellAutomation.TaskScheduler.Data.Entity;

namespace RockwellAutomation.TaskScheduler.Data.Mapping
{
    public class TaskItemMap : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable(nameof(TaskItem));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.CronExpression).IsRequired(true);
            builder.Property(c => c.WebUrl).IsRequired(true);
            builder.Property(c => c.DateAdded).IsRequired(true);
            builder.Property(c => c.IsActive).HasDefaultValue<bool>(true);
        }
    }
}
