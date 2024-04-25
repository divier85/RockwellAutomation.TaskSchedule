using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RockwellAutomation.TaskScheduler.Data.Entity;
using RockwellAutomation.TaskScheduler.Data.Interface;
using System.Reflection;

namespace RockwellAutomation.TaskScheduler.Data
{
    public class RockwellTaskSchedulerDbContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public RockwellTaskSchedulerDbContext(DbContextOptions<RockwellTaskSchedulerDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<ExecutionTaskItem> ExecutionTaskItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(w => w.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(RockwellTaskSchedulerDbContext)));
        }
    }
}
