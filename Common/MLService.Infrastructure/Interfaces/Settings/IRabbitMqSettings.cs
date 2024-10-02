using MLService.Infrastructure.Interfaces.Settings.EndpointsSettings;

namespace MLService.Infrastructure.Interfaces.Settings
{
    public interface IRabbitMqSettings<T>
        where T : IBaseEndpointSettings
    {
        /// <summary>
        /// Название очереди
        /// </summary>
        public abstract string Queue { get; set; }

        /// <summary>
        /// Хост RabbitMq
        /// </summary>
        public abstract string Host { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public abstract T Endpoints { get; set; }
    }
}
