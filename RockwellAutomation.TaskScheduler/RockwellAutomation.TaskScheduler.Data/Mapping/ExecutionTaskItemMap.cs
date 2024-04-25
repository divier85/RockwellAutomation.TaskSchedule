using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockwellAutomation.TaskScheduler.Data.Entity;

namespace RockwellAutomation.TaskScheduler.Data.Mapping
{
    public class ExecutionTaskItemMap : IEntityTypeConfiguration<ExecutionTaskItem>
    {
        public void Configure(EntityTypeBuilder<ExecutionTaskItem> builder)
        {
            builder.ToTable(nameof(ExecutionTaskItem));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TaskItemId).IsRequired(true);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Headers).IsRequired(true);
            builder.Property(c => c.DateAdded).IsRequired(true);

            builder.HasOne(r => r.TaskItem).WithMany().HasForeignKey(r => r.TaskItemId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
