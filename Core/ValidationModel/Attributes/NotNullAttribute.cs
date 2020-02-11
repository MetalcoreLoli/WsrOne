using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Core.ValidationModel.Attributes
{
    public class NotNullAttribute : Attribute, IValidationAttribute
    {
        public bool IsValid(object val) => (val != null) ? true : throw new NullReferenceException(); 
    }
}
