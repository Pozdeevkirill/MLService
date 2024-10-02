using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace MLService.Infrastructure
{
    public class ServiceController : ControllerBase
    {
        protected readonly IBusControl BusControl;
        protected virtual string RabbitMqUrl { get; set; }
        private readonly Uri _rabbitMqUrl;

        public ServiceController()
        {
            if (RabbitMqUrl == null || RabbitMqUrl == string.Empty)
                throw new Exception("Не установленна ссылка сервиса");

            _rabbitMqUrl = new Uri(RabbitMqUrl);
        }

        public ServiceController(IBusControl busControl, string rabbitMqUrl)
        {
            BusControl = busControl;
            RabbitMqUrl = rabbitMqUrl;
        }

        protected async Task<TOut> GetResponseRabbitTask<TIn, TOut>(TIn request)
            where TIn : class
            where TOut : class
        {
            var client = BusControl.CreateRequestClient<TIn>(_rabbitMqUrl);
            var response = await client.GetResponse<TOut>(request);
            return response.Message;
        }
    }
}
