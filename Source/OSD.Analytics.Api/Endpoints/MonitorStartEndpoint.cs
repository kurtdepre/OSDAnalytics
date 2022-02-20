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
    public class MonitorStartEndpoint : EndpointBaseAsync.WithRequest<String>.WithActionResult<String>
    {
        private readonly IOSDAnalyticsReadWriteRepository _repository;

        public MonitorStartEndpoint(IOSDAnalyticsReadWriteRepository repository)
        {
            _repository = repository;
        }



        [HttpGet("api/v1/OSDMonitoring/Start")]
        [SwaggerOperation(
 Summary = "Starts a TS monitoring Session",
 Description = "Starts a TS monitoring Session",
 OperationId = "OSDMonitoring.Start",
 Tags = new[] { "OSDMonitoring" })]
        public async override Task<ActionResult<string>> HandleAsync([FromQuery] string request, CancellationToken cancellationToken = default)
        {
            try
            {
                MonitoringEntry mon = new MonitoringEntry();
                mon.EntryID = generateID();
                mon.Data = request;
                mon.StartTime = DateTime.Now;
                mon.CompleteTime = null;

                await _repository.CreateMonitoringEntryAsync(mon);
               

                return mon.EntryID;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private String generateID()
        {
            Guid id = Guid.NewGuid();
            return id.ToString();
        }
    }
}
