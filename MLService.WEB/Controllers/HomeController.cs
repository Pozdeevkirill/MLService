using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MLService.Enums;
using MLService.Infrastructure.Models.Settings;
using MLService.MassTransit.MLService.Requests;
using MLService.WEB.Models;
using System.Diagnostics;

namespace MLService.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;


        public HomeController(ILogger<HomeController> logger,  IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation(AppSettings.MLService.ConnectionString);
            var message = new CreateMachineRequest()
            {
                MachineType = MachineType.TextClassification,
                MachineDescription = "Description",
                MachineName = "Name",
            };

            _publishEndpoint.Publish<CreateMachineRequest>(new
            {
                MachineType = message.MachineType,
                MachineDescription = message.MachineDescription,
                MachineName = message.MachineName,
            });

            return Accepted();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*private async Task<TOut> GetResponseRabbitTask<TIn, TOut>(TIn request)
        where TIn : class
        where TOut : class
        {
            var client = _busControl.CreateRequestClient<TIn>(new Uri("rabbitmq://localhost/identityQueue"));
            var response = await client.GetResponse<TOut>(request);
            return response.Message;
        }*/
    }
}
