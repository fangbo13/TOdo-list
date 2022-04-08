using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAPP.View
{
    public class ScheduleListPageFlyoutMenuItem
    {
        public ScheduleListPageFlyoutMenuItem()
        {
            TargetType = typeof(ScheduleListPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}