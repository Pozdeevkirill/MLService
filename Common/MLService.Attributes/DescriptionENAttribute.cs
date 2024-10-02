using System.ComponentModel;

namespace MLService.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionENAttribute : DescriptionAttribute
    {
        public DescriptionENAttribute(string description) : base(description)
        {
        }
    }
}
