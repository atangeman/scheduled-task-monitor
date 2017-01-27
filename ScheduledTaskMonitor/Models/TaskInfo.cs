namespace ScheduledTaskMonitor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskInfo")]
    public partial class TaskInfo
    {
        public int TaskInfoId { get; set; }

        [Required]
        [StringLength(30)]
        public string TaskName { get; set; }

        [StringLength(50)]
        public string TaskDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string TaskGUID { get; set; }

        public int UserID { get; set; }

        public DateTime Date_Created { get; set; }
    }
}
