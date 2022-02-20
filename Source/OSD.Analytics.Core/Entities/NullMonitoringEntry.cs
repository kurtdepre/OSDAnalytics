using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSD.Analytics.Core.Entities
{
    public  class NullMonitoringEntry : MonitoringEntry
    {
        public NullMonitoringEntry()
        {
            EntryID = "0";
        }
    }
}
