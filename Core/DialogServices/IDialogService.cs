using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Core.DialogServices
{
    interface IDialogService
    {
        void ShowMessage(string message);
        void ShowErrorMessage(string message);
    }
}
