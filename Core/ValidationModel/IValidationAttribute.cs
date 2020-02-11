using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Core.ValidationModel
{
    public interface IValidationAttribute
    {
        bool IsValid(object val);
    }
}
