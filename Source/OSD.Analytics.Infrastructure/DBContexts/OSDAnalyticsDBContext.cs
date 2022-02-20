using Microsoft.EntityFrameworkCore;
using OSD.Analytics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace OSD.Analytics.Infrastructure.DBContexts
{
        public class OSDAnalyticsDBContext : DbContext
        {





            public OSDAnalyticsDBContext(DbContextOptions<OSDAnalyticsDBContext> options) : base(options)
            {


            }




            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                


            }

            

            public DbSet<MonitoringEntry> MonitoringEntries { get; set; }
            

        }
    }


