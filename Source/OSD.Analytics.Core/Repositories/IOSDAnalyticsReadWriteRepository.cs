using OSD.Analytics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSD.Analytics.Core.Repositories
{
    public  interface IOSDAnalyticsReadWriteRepository : IOSDAnalyticsReadOnlyRepository
    {
        Task<MonitoringEntry> CreateMonitoringEntryAsync(MonitoringEntry newEntry);
        Task<MonitoringEntry> UpdateMonitoringEntryAsync(MonitoringEntry Entry);
    }
}
