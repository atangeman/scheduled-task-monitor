using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduledTaskMonitor.Models
{
    public partial class SidebarModel
    {
        public String[] TaskItems;
        public String[] MachineItems;
        public SidebarModel(String[] taskItems, String[] machineItems)
        {
            this.TaskItems = taskItems;
            this.MachineItems = machineItems;
        }
    }
}
