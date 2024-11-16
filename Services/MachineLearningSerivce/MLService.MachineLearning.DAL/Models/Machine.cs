using MLService.Enums;
using MLService.Infrastructure.Models;

namespace MLService.MachineLearning.DAL.Models
{
    /// <summary>
    /// Объект машины
    /// </summary>
    public class Machine : DeletableEntity
    {
        public Machine() { }

        public Machine(string name, string description, MachineType type)
        {
            Name = name;
            Description = description;
            MachineType = type;
        }
        /// <summary>
        /// Название машины
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание машины
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип машины
        /// </summary>
        public MachineType MachineType { get; set; }
    }
}
