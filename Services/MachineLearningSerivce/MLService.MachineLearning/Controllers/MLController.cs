using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MLService.Infrastructure;
using MLService.Infrastructure.Models;
using MLService.Infrastructure.Models.Settings;
using MLService.Infrastructure.Response;
using MLService.MachineLearning.BAL.Services;
using MLService.MassTransit.MLService.Requests;

namespace MLService.MachineLearning.Controllers
{
    [Route("api/")]
    public class MLController : ServiceController
    {
        private readonly ILearnService _learnService;
        private readonly IPublishEndpoint _publishEndpoint;
        protected override string RabbitMqUrl => AppSettings.MassTransit.Host + AppSettings.MLService.Endpoints.Test;


        public MLController(
            IPublishEndpoint publishEndpoint,
            ILearnService learnService) : base()
        {
            _publishEndpoint = publishEndpoint;
            _learnService = learnService;           
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
