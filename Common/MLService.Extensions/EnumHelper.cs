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
            switch(language.ToUpper())
            {
                case "RU":
                    if(Attribute.GetCustomAttribute(field, typeof(DescriptionRUAttribute)) is DescriptionRUAttribute ruAttribute)
                        return ruAttribute.Description;
                    break;
                case "EN":
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionENAttribute)) is DescriptionENAttribute enAttribute)
                        return enAttribute.Description;
                    break;
            }
            throw new ArgumentException("Item not found.", nameof(enumValue));
        }

        /// <summary>
        /// Получить список значений перечисления
        /// </summary>
        public static IEnumerable<EnumItem<TEnum>> GetEnumValues<TEnum>(string language)
            where TEnum : Enum
        {
            var type = typeof(TEnum);
            foreach (var item in Enum.GetValues(typeof(TEnum)))
            {
                yield return new(type, (TEnum)item, (int)item, GetEnumDescription((TEnum)item, language));
            }
        }
    }
}
