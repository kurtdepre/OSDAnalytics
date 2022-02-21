using OSD.Analytics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSD.Analytics.Core.Repositories
{
    public interface IOSDAnalyticsReadOnlyRepository
    {
        Task<MonitoringEntry> GetMonitoringEntryAsync(String guid);
        Task<List<MonitoringEntry>> GetAllMonitoringEntriesAsync();
    }
}
