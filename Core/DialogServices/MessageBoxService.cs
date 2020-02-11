using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Core.DialogServices
{
    public class MessageBoxService : IDialogService
    {

        public void ShowErrorMessage(string message)
        {
            System.Windows.MessageBox.Show(message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }

        public void ShowMessage(string message)
        {
            System.Windows.MessageBox.Show(message);
        }
    }
}
