using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using OSD.Analytics.Core.Entities;
using OSD.Analytics.Core.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace OSD.Analytics.Api.Endpoints
{
    public class MonitoringTimeoutEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult
    {
        private readonly IOSDAnalyticsReadWriteRepository _repository;

        public MonitoringTimeoutEndpoint(IOSDAnalyticsReadWriteRepository repository)
        {
            _repository = repository;
        }



        [HttpGet("api/v1/OSDMonitoring/Timeout")]
        [SwaggerOperation(
 Summary = "Marks Old OSD sessions as failed",
 Description = "Loops trough all unfinished OSD sessions and marks those running for more then 48 hours as failed",
 OperationId = "OSDMonitoring.Timeout",
 Tags = new[] { "OSDMonitoring" })]
        public async override Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                List<MonitoringEntry> AllEntries = await _repository.GetAllMonitoringEntriesAsync();
                foreach (MonitoringEntry entry in AllEntries)
                {
                    if (entry.StartTime < (DateTime.Now.AddHours(48)))
                    {
                        entry.isCompleted = true;
                        entry.isFailed = true;
                        entry.FailurePoint = "Timeout/Unknown";
                        entry.CompleteTime = DateTime.Now;
                        await _repository.UpdateMonitoringEntryAsync(entry);
                    }
                }

                
                return Ok(true);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}


