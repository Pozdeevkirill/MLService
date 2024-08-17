using System.ComponentModel;

namespace MLService.Enums
{   
    /// <summary>
    /// Machine type
    /// </summary>
    public enum MachineType
    {
        /// <summary>
        /// Undefined
        /// </summary>
        [Description("Не определено")]
        Undefined,

        /// <summary>
        /// Image classification machine
        /// </summary>
        [Description("Классификатор изображений")]
        ImageClassification,

        /// <summary>
        /// Text classification machine
        /// </summary>
        [Description("Класификатор текста")]
        TextClassification,
    }
}
