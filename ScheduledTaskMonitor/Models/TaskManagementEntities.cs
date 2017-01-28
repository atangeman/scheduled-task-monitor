namespace ScheduledTaskMonitor.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    public partial class TaskManagementEntities : DbContext
    {
        public string[] MachineInfoNames
        {
            get
            {
                return MachineInfoLst.Select(x => x.MachineHostName).ToArray();
            }
        }
        public List<MachineInfo> MachineInfoLst
        {
            get
            {
                return MachineInfos.ToList();
            }
        }
        public string[] TaskInfoNames
        {
            get
            {
                return TaskInfoLst.Select(x => x.TaskName).ToArray();
            }
        }
        public List<TaskInfo> TaskInfoLst
        {
            get
            {
                return TaskInfos.ToList();
            }
        }
        public TaskManagementEntities()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<MachineInfo> MachineInfos { get; set; }

        public virtual DbSet<TaskInfo> TaskInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MachineInfo>()
                .Property(e => e.MachineHostName)
                .IsUnicode(false);

            modelBuilder.Entity<MachineInfo>()
                .Property(e => e.MachineIPv4Address)
                .IsUnicode(false);

            modelBuilder.Entity<MachineInfo>()
                .Property(e => e.Created_By)
                .IsUnicode(false);

            modelBuilder.Entity<MachineInfo>()
                .Property(e => e.Created_Date)
                .IsUnicode(false);

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
