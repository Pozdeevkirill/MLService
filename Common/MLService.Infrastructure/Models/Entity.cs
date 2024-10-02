namespace MLService.Infrastructure.Models
{
    /// <summary>
    /// Базовая сущность любой модели БД
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// ИД сущности
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Версия сущности
        /// </summary>
        public DateTime Version { get; set; }

        /// <summary>
        /// Дата создания сущности
        /// </summary>
        public DateTime DateCreate { get; set; }
    }
}
