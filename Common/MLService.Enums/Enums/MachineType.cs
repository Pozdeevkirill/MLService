using MLService.Attributes;

namespace MLService.Enums
{
    /// <summary>
    /// Тип машины
    /// </summary>
    public enum MachineType
    {
        /// <summary>
        /// Не определено
        /// </summary>
        [DescriptionRU("Не определено")]
        [DescriptionEN("Undefined")]
        Undefined,

        /// <summary>
        /// Классификатор изображений
        /// </summary>
        [DescriptionRU("Классификатор изображений")]
        [DescriptionEN("Image classification")]
        ImageClassification,

        /// <summary>
        /// Класификатор текста
        /// </summary>
        [DescriptionRU("Класификатор текста")]
        [DescriptionEN("Text classification")]
        TextClassification,
    }
}
