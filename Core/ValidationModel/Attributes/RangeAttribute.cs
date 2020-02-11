using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Core.ValidationModel.Attributes
{
    public class RangeAttribute : Attribute, IValidationAttribute  
    {
        public float From { get; private set; }
        public float To { get; private set; }

        public RangeAttribute(float from, float to)
        {
            From = from;
            To = to;
        }
        public bool IsValid(object val) => (float)val >= From && (float)val <= To;
    }
}
