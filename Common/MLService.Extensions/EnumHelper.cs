using System.ComponentModel;
using MLService.Attributes;
using MLService.Enums;

namespace MLService.Extensions
{
    public static class EnumHelper
    {
        /// <summary>
        /// Получить значение атрибута Description 
        /// </summary>
        public static string GetEnumDescription(this Enum enumValue, string language)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            switch(language)
            {
                case "RU":
                    if(Attribute.GetCustomAttribute(field, typeof(DescriptionRUAttribute)) is DescriptionRUAttribute attribute)
                        return attribute.Description;
                    break;
                case "EN":
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionRUAttribute)) is DescriptionRUAttribute attribute)
                        return attribute.Description;
            }
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            throw new ArgumentException("Item not found.", nameof(enumValue));
        }

        /// <summary>
        /// Получить список значений перечисления
        /// </summary>
        public static IEnumerable<EnumItem<TEnum>> GetEnumValues<TEnum>()
            where TEnum : Enum
        {
            var type = typeof(TEnum);
            foreach (var item in Enum.GetValues(typeof(TEnum)))
            {
                yield return new(type, (TEnum)item, (int)item, GetEnumDescription((TEnum)item));
            }
        }
    }
}
