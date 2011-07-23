using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hst.Core.Validation.Attributes
{
    [Serializable]
    public class StringRangeAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public StringRangeAttribute()
        {
            MinLength = 0;
            MaxLength = 0;
        }

        public override bool IsValid(object value)
        {
            return IsValid(value as string);
        }

        public bool IsValid(string value)
        {
            value = value ?? string.Empty;

            return (value.Length >= MinLength && value.Length <= MaxLength);
        }
    }
}
