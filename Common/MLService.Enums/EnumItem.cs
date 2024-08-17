namespace MLService.Enums
{
    /// <summary>
    /// Представление енама в виде модели
    /// </summary>
    /// <typeparam name="T">Тип енама</typeparam>
    public class EnumItem<T>
        where T: Enum
    {

        #region Ctors
        /// <summary>
        /// Конструктор базовый
        /// </summary>
        public EnumItem() { }

        public EnumItem(int value, string name)
        {
            Value = value;
            Name = name;
        }

        /// <summary>
        /// Конструктор полный
        /// </summary>
        public EnumItem(Type enumType, T enumValue, int value, string name)
        {
            EnumType = enumType;
            EnumValue = enumValue;
            Value = value;
            Name = name;
        }
        #endregion

        /// <summary>
        /// Тип енама
        /// </summary>
        public Type EnumType { get; set; }

        /// <summary>
        /// Значение енама
        /// </summary>
        public T EnumValue { get; set; }

        /// <summary>
        /// Значение енама
        /// </summary>
        public int Value { get; set; }
        
        /// <summary>
        /// Имя енама из Description
        /// </summary>
        public string Name { get; set; }
    }
}
