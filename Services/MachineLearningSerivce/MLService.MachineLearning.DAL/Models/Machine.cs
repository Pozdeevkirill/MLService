﻿using MLService.Enums;

namespace MLService.MachineLearning.DAL.Models
{
    /// <summary>
    /// Объект машины
    /// </summary>
    public class Machine
    {
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
