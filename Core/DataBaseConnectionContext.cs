using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Core
{
    public class DataBaseConnectionContext
    {
        public static Models GetContext() => new Models();
    }
}
