using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace MLService.Infrastructure
{
    public class ServiceController : ControllerBase
    {
        protected readonly IBusControl BusControl;

        public ServiceController()
        {
        }

        public ServiceController(IBusControl busControl)
        {
            BusControl = busControl;
        }

        protected async Task<TOut> GetResponseRabbitTask<TIn, TOut>(TIn request)
            where TIn : class
            where TOut : class
        {
            var client = BusControl.CreateRequestClient<TIn>();
            var response = await client.GetResponse<TOut>(request);
            return response.Message;
        }
    }
}
