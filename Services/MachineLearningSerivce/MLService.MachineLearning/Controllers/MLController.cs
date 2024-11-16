using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MLService.Infrastructure;
using MLService.Infrastructure.Models;
using MLService.Infrastructure.Response;
using MLService.MassTransit.MLService.Requests;

namespace MLService.MachineLearning.Controllers
{
    [Route("api/")]
    public class MLController : ServiceController
    {
        public MLController(IBusControl busControl)
            : base(busControl)
        {   
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateMachine([FromBody] CreateMachineRequest request)
        {
            var response = await GetResponseRabbitTask<CreateMachineRequest, IdWithName>(request);
            return Ok(ApiResult<IdWithName>.Success200(response));
        }
    }
}
