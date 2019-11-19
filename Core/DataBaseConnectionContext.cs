using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsr1.Core.EnityModels;

namespace Wsr1.Core
{
    public class DataBaseConnectionContext
    {
        public static Models GetContext() => new Models();
    }
}
