using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduledTaskMonitor.Models
{
    public partial class SidebarModel
    {
        public String[] items;
        public SidebarModel(String[] items)
        {
            this.items = items;
        }
    }
}
