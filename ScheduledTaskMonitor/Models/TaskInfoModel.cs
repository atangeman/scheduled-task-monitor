namespace ScheduledTaskMonitor.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TaskInfoModel : DbContext
    {
        public TaskInfoModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<TaskInfo> TaskInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskInfo>()
                .Property(e => e.TaskName)
                .IsUnicode(false);

            modelBuilder.Entity<TaskInfo>()
                .Property(e => e.TaskDescription)
                .IsUnicode(false);

            modelBuilder.Entity<TaskInfo>()
                .Property(e => e.TaskGUID)
                .IsUnicode(false);
        }
    }
}
