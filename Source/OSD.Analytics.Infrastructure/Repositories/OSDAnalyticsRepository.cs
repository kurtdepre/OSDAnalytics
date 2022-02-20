using OSD.Analytics.Core.Entities;
using OSD.Analytics.Core.Repositories;
using OSD.Analytics.Infrastructure.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSD.Analytics.Infrastructure.Repositories
{
    public class OSDAnalyticsRepository : IOSDAnalyticsReadWriteRepository
    {
        private OSDAnalyticsDBContext _context;
        public OSDAnalyticsRepository(OSDAnalyticsDBContext context)
        {
            _context = context;
        }
        public async Task<MonitoringEntry> CreateMonitoringEntryAsync(MonitoringEntry newEntry)
        {
            _context.MonitoringEntries.Add(newEntry);
            await _context.SaveChangesAsync();
            return await (GetMonitoringEntryAsync(newEntry.EntryID));


        }

        public async Task<MonitoringEntry> GetMonitoringEntryAsync(string guid)
        {
            try
            {
                MonitoringEntry mon = await _context.MonitoringEntries.FindAsync(guid);
                return mon;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MonitoringEntry> UpdateMonitoringEntryAsync(MonitoringEntry Entry)
        {
            _context.MonitoringEntries.Update(Entry);
            await _context.SaveChangesAsync();
            return await(GetMonitoringEntryAsync(Entry.EntryID));

        }
    }
}
