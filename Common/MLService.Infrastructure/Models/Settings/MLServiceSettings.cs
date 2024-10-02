using MLService.Infrastructure.Interfaces.Settings;
using MLService.Infrastructure.Models.Settings.EndpointsSettings;

namespace MLService.Infrastructure.Models.Settings
{
    /// <summary>
    /// Настройки сервиса MLService
    /// </summary>
    public class MLServiceSettings : IDbServiceSettings, IRabbitMqSettings<MLServiceEndpointsSettings>
    {
        #region IRabbitMqSettings
        public string Queue { get; set; }
        public MLServiceEndpointsSettings Endpoints { get; set; } = new();
        public string Host { get; set; }
        #endregion

        #region IDbServiceSettings
        public string DbType { get; set; }
        public string ConnectionString { get; set; }
        #endregion
    }
}
