namespace MLService.Infrastructure.Interfaces.Settings
{
    /// <summary>
    /// Интерфейс настроек микросервиса с подключением к БД
    /// </summary>
    public interface IDbServiceSettings
    {
        /// <summary>
        /// Тип бд
        /// </summary>
        public abstract string DbType { get; set; }

        /// <summary>
        /// Строка подключения
        /// </summary>
        public abstract string ConnectionString { get; set; }
    }
}
