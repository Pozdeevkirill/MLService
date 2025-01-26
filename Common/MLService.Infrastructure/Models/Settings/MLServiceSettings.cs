using MLService.Enums.Enums;
using MLService.Infrastructure.Interfaces.Settings;
using MLService.Infrastructure.Models.Settings.EndpointsSettings;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLService.Infrastructure.Models.Settings
{
    /// <summary>
    /// Настройки сервиса MLService
    /// </summary>
    public class MLServiceSettings : DbSettings, IRabbitMqSettings<MLServiceEndpointsSettings>
    {
        #region IRabbitMqSettings
        public string Queue { get; set; }
        public MLServiceEndpointsSettings Endpoints { get; set; } = new();
        public string Host { get; set; }
        #endregion

    }
}
