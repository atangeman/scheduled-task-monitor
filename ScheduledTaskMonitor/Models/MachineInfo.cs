namespace ScheduledTaskMonitor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MachineInfo")]
    public partial class MachineInfo
    {
        public int MachineInfoId { get; set; }

        [Required]
        [StringLength(50)]
        public string MachineHostName { get; set; }

        [StringLength(36)]
        public string MachineIPv4Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Created_By { get; set; }

        [Required]
        [StringLength(20)]
        public string Created_Date { get; set; }
    }
}
