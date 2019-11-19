using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wsr1.Core;

namespace Wsr1.View.ManagerView
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        ViewModel.CoefficientViewModel context;
        public ManagerWindow()
        {
            InitializeComponent();
            MessageBox.Show("Hello, " + UserModelSingleton.Instance().FirstName);
            DataContext = context = new ViewModel.CoefficientViewModel();
            
        }
    }
}
