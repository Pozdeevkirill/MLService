namespace MLService.Infrastructure.Models.Settings
{
    public static class AppSettings
    {
        public static RabbitMqSettings RabbitMq { get; set; } = new();
        public static MassTransitSettings MassTransit { get; set; } = new();
        public static MLServiceSettings MLService { get; set; } = new();
    }
}
