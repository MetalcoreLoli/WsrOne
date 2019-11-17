using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Core.DialogServices
{
    public class MessageBoxService : IDialogService
    {
        public string Message { get; set; }

        public MessageBoxService(string message)
        {
            Message = message;
        }
        public void Show()
        {
            System.Windows.MessageBox.Show(Message);
        }
    }
}
