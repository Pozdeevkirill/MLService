﻿using System.ComponentModel;

namespace MLService.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionRUAttribute : DescriptionAttribute
    {
        public DescriptionRUAttribute(string description) : base(description)
        {
        }
    }
}
