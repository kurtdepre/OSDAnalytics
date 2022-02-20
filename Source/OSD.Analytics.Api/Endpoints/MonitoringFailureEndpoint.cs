
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using OSD.Analytics.Core.DTOs;
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
    public class MonitoringFailureEndpoint : EndpointBaseAsync.WithRequest<OSDMonitoringFailureNotification>.WithActionResult<Boolean>
    {

        private readonly IOSDAnalyticsReadWriteRepository _repository;

        public MonitoringFailureEndpoint(IOSDAnalyticsReadWriteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("api/v1/OSDMonitoring/Fail")]
        [SwaggerOperation(
 Summary = "OSD a staging monitoring Session",
 Description = "OSD a staging monitoring Session",
 OperationId = "OSDMonitoring.Fail",
 Tags = new[] { "OSDMonitoring" })]
        public async override Task<ActionResult<bool>> HandleAsync(OSDMonitoringFailureNotification request, CancellationToken cancellationToken = default)
        {
            try
            {
                MonitoringEntry mon = await _repository.GetMonitoringEntryAsync(request.EntryId);

                mon.isCompleted = true;
                mon.isFailed = true;
                mon.FailurePoint = request.Message;
                mon.CompleteTime = DateTime.Now;
               

               await _repository.UpdateMonitoringEntryAsync(mon);
                return Ok(true);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

