namespace MLService.Infrastructure.Models.Settings
{
    /// <summary>
    /// Настройки RabbitMq
    /// </summary>
    public class RabbitMqSettings
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }    
    }
}
