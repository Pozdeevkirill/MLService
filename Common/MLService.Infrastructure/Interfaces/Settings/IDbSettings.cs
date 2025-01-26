using MLService.Enums.Enums;

namespace MLService.Infrastructure.Interfaces.Settings
{
    /// <summary>
    /// Интерфейс настроек микросервиса с подключением к БД
    /// </summary>
    public interface IDbSettings
    {
        /// <summary>
        /// Тип бд
        /// </summary>
        public abstract DatabaseType DbType { get; }

        /// <summary>
        /// Строка подключения
        /// </summary>
        public abstract string ConnectionString { get; set; }
    }
}
