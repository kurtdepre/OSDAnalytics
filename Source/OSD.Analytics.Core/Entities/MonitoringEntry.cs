using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSD.Analytics.Core.Entities
{


    
        public class MonitoringEntry
        {
            [Key]
            public String? EntryID { get; set; }
            public String? Data { get; set; }
            [Required]
            public DateTime? StartTime { get; set; }

           // [Required]
            public DateTime? CompleteTime { get; set; }
            [Required]
            public Boolean isCompleted { get; set; }

            [Required]
            public Boolean isFailed { get; set; }
            public String? FailurePoint { get; set; }

       //     public String LastActionID { get; set; }
       //     public String LastActionName { get; set; }

      //      public int NumberOfApps { get; set; }

      //      public String Version { get; set; }
        }
    }


