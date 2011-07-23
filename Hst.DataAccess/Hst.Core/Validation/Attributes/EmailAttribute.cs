using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hst.Core.Validation.Attributes
{
    [Serializable]
    public class EmailAttribute : RegexAttribute
    {
        public EmailAttribute()
            : base(@"^[\w-\.]{1,}\@([\w]{1,}\.){1,}[a-z]{2,4}$", RegexOptions.IgnoreCase)
        { }
    }
}
