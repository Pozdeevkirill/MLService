namespace MLService.Infrastructure.Models
{
    /// <summary>
    /// Ид и имя сущности
    /// </summary>
    public class IdWithName
    {
        public IdWithName()
        {
        }

        public IdWithName(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// ИД сущности
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название сущности
        /// </summary>
        public string Name { get; set; }    
    }
}
