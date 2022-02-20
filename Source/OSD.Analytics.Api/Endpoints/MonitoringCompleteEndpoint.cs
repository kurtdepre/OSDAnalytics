
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
    public class MonitoringCompleteEndpoint : EndpointBaseAsync.WithRequest<String>.WithActionResult<Boolean>
    {
        private readonly IOSDAnalyticsReadWriteRepository _repository;

        public MonitoringCompleteEndpoint(IOSDAnalyticsReadWriteRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("api/v1/OSDMonitoring/Complete")]
        [SwaggerOperation(
                            Summary = "Completes a OSD monitoring Session",
                            Description = "Completes a OSD monitoring Session",
                            OperationId = "OSDMonitoring.Completes",
                            Tags = new[] { "OSDMonitoring" }
                          )]
        public async override Task<ActionResult<bool>> HandleAsync([FromQuery] string request, CancellationToken cancellationToken = default)
        {
            try
            {
                MonitoringEntry mon = await _repository.GetMonitoringEntryAsync(request);
                    

                mon.isCompleted = true;
                mon.CompleteTime = DateTime.Now;
                mon.isFailed = false;
                mon.FailurePoint = null;


               await _repository.UpdateMonitoringEntryAsync(mon);

               
                return Ok(true);
            }
            catch
            {
                return false;
            }
        }
    }
}
